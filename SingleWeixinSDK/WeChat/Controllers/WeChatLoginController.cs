using BLL;
using BLL.Wechat;
using Deepleo.Weixin.SDK;
using Deepleo.Weixin.SDK.Helpers;
using Model;
using Model.WeiXin;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChat.App_Start;
using WeChat.Attributes;
using WeChat.Services;

namespace WeChat.Controllers
{
    public class WeChatLoginController : Controller
    {
        // GET: WeChatLogin
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult Index()
        {
            string rawurl = Request.QueryString["rawurl"];
            int storeid = Convert.ToInt32(Request.QueryString["storeid"]);
            
            string openid = AuthorizationManager.GetOpenID;
            AddWeChatM model = new AddWeChatM();
            BLL.StoreInfoB storeinfo1B = new BLL.StoreInfoB();
            StoreInfoM infoM = new StoreInfoM();
            infoM = storeinfo1B.GetOne(storeid);
            if (infoM == null)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }
            model.Str_StoreName = infoM.str_StoreName;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid, storeid);



            model.openid = openid;
            if (cardM != null)
            {
                model.StoreID = storeid;
                model.VipCardID = cardM.Ing_Pk_VipCardId;
                model.rawurl = "/MyAccount/Index?storeid=" + storeid;
                return PartialView(model);
            }
            try
            {
                BLL.Wechat.WeChatConfigB bllconfig = new WeChatConfigB();
                WeChatConfigM wechatconfig = bllconfig.GetWeixinConfig(storeid);
                
                Boolean openJSSDK = false;
                if (wechatconfig.OpenJSSDK == 1)
                {
                    openJSSDK = true;
                }
                TokenHelper tokenHelper = new TokenHelper(6000, wechatconfig.AppID, wechatconfig.AppSecret, openJSSDK);
                
                var token = tokenHelper.GetToken(true);
                //TODO: 获取用户基本信息后，将用户信息存储在本地。
                var weixinInfo = UserAdminAPI.GetInfo(token, openid);//注意：订阅号没有此权限
                Public.LogHelper.LogInfo("weixinInfo:" + weixinInfo);
                model.headerimg = weixinInfo.headimgurl;
                model.nickname = weixinInfo.nickname;
                StoreInfoB infob = new StoreInfoB();
                model.companyimg = infob.GetStoreHeaderImg(storeid);
                //model.unionid = weixinInfo.unionid;

            }
            catch { }

            model.rawurl = "/MyAccount/Index?storeid=" + storeid;
            

            if (!string.IsNullOrEmpty(rawurl))
            {
                // rawurl = HttpUtility.HtmlDecode(rawurl);
                model.rawurl = rawurl;
            }
            model.StoreID = storeid;
            Public.LogHelper.LogInfo("storeid:" + storeid);
            return PartialView(model);
        }
        /// <summary>
        /// 发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WechatBindVirifyCode(string mobile, int storeid)
        {

            JsonResult json = new JsonResult();
            BaseResponseModel rev = new BaseResponseModel();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            ///随机数
            Random rd = new Random();
            int yzcode = rd.Next(1000, 9999);
            string yzstr = string.Format("{0}-{1}", mobile.Trim(), yzcode.ToString().Trim());
            yzstr = ConfigValue.GetMD5_32(yzstr);
            string Content = bll.WechatBindVirifyCode(mobile, yzcode, storeid);
            if (String.IsNullOrEmpty(Content))
            {
                rev.status = 1;
                json.Data = rev;
                return json;
            }
            else//发送短信
            {
                //SMSServiceReference.LinkWSSoapClient client = new SMSServiceReference.LinkWSSoapClient();
                SMSSendB smsbll = new SMSSendB();
                BaseResponseModel smsResult = smsbll.sendSms(Content, mobile, storeid);
                if (smsResult.status == 0)//发送成功
                {
                    smsbll.AddLog(smsResult.message, mobile, Content, storeid);
                    rev.status = 0;
                    rev.data = yzstr;
                }
                else
                {
                    rev.status = 1;
                }
                json.Data = rev;
                return json;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Post(AddWeChatM model)
        {
            JsonResult json = new JsonResult();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            BaseResponseModel rev = bll.BindOrAddWeChat(model.mobile, model.cusname, model.openid, model.yzcode, model.yzcode1, model.StoreID, model.ident);
            json.Data = rev;
            //if (rev.success)
            //{
            //    ///绑定成功，推送消息
            //    TemplateValue m = new TemplateValue();
            //    m.LylOrderID = 1;
            //    m.LylOpenID = model.openid;
            //    m.LylaccessToken = WeixinConfig.TokenHelper.GetToken();
            //    m.LylUrl = string.Format("{0}/home/Index", Public.ConfigValue.GetDomain);


            //    m.first = "您好！您的微信号与系统账号绑定成功";
            //    m.keyword1 = string.Format("{0}(手机号：{1})", model.cusname, model.mobile);
            //    m.keyword2 = "微信会员";
            //    m.keyword3 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //    m.remark = "非本人请联系系统管理员";

            //    TemplateSend.PushMessageBat(m);
            //}
            return json;
        }
    }
}