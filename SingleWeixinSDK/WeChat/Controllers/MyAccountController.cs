using BLL.Wechat;
using Deepleo.Weixin.SDK;
using Deepleo.Weixin.SDK.Helpers;
using Deepleo.Weixin.SDK.JSSDK;
using Model;
using Model.Cust;
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
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult Index()
        {

            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            LogHelper.LogInfo("openid:"+openid);
            MyAccountM model = new MyAccountM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            
            model.openid = openid;
            model.storeid = storeid;
            model.VipCardId = cardM.Ing_Pk_VipCardId;
            model.Ing_SurplusIntegral = cardM.Ing_SurplusIntegral;
            model.dec_SurplusMoney = cardM.dec_SurplusMoney;
            model.dec_WechatPrice = cardM.dec_WechatPrice;
            ///姓名，手机
            BLL.VipInfoB bll2 = new BLL.VipInfoB();
            VipInfoM model2 = new VipInfoM();
            model2 = bll2.GetOne(cardM.Ing_Fk_VipID);

            if (model2 != null && model2.Ing_Fk_CustID.HasValue)
            {
                BLL.CustB bll3 = new BLL.CustB();
                CustM model3 = new CustM();
                model3 = bll3.GetOne(model2.Ing_Fk_CustID.Value);
                if (model3 != null)
                {
                    model.str_CusName = model3.str_CusName;
                    model.mobile = model3.str_mobile;
                }
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
                Public.LogHelper.LogInfo("token:" + token + ",openid:" + openid);

                //TODO: 获取用户基本信息后，将用户信息存储在本地。
                var weixinInfo = UserAdminAPI.GetInfo(token, openid);//注意：订阅号没有此权限
                //Public.LogHelper.LogInfo("weixinInfo:" + weixinInfo);
                model.headerimg = weixinInfo.headimgurl;
            }
            catch { }

            BLL.CouponDetailsB bll4 = new BLL.CouponDetailsB();
            model.coupon = bll4.GetUseFulCount(model.VipCardId);


            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult Order()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            MyOrderM model = new MyOrderM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            ViewBag.rawurl = "/MyAccount/Index?storeid=" + storeid;
            
            model.openid = openid;
            model.storeid = storeid;
            //model.type = id;
            model.dec_SurplusMoney = cardM.dec_SurplusMoney;
            model.str_paypassword = cardM.str_paypassword;
            model.Ing_Pk_VipCardId = cardM.Ing_Pk_VipCardId;
            BLL.MasterB bll = new BLL.MasterB();
            model.list0 = bll.GetOrderbycardid(cardM.Ing_Pk_VipCardId, 0);
            model.list1 = bll.GetOrderbycardid(cardM.Ing_Pk_VipCardId, 1);
            model.list2 = bll.GetOrderbycardid(cardM.Ing_Pk_VipCardId, 2);
            ///离店的看看是不是已经评论过
            BLL.CommentsB bll1 = new BLL.CommentsB();
            BLL.ContinueInterB bll2 = new BLL.ContinueInterB();

            if (model.list0 != null)
            {
                foreach (OrderM m in model.list0)
                {

                    CommentsM m1 = bll1.GetRecordByMasID(m.Ing_Pk_MasterID);
                    if (m1 != null)
                    {
                        m.AlreadyComment = 1;
                    }
                }
            }

            if (model.list1 != null)
            {
                foreach (OrderM m in model.list1)
                {
                    if (m.str_Sta.ToUpper().Equals("I"))
                    {
                        ContinueInterM conM = bll2.GetRecord(m.Ing_Pk_MasterID, 0);
                        if (conM != null)
                        {
                            if (conM.Ing_PayType == 0 && conM.dec_price.HasValue && conM.dec_price.Value > 0)
                            {
                                m.CanPayXu = 1;
                            }
                        }
                    }

                }
            }
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult ChangePayPwd()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            ChangePayPwdM model = new ChangePayPwdM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            ViewBag.rawurl = "/MyAccount/Index?storeid=" + storeid;
            
            model.vipcardid = cardM.Ing_Pk_VipCardId;
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult ChangeVipPwd()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            ChangePayPwdM model = new ChangePayPwdM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            ViewBag.rawurl = "/MyAccount/Index?storeid=" + storeid;
            
            model.vipcardid = cardM.Ing_Pk_VipCardId;
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult MyInfo()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            MyInfoM model = new MyInfoM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            
            model.openid = openid;
            model.storeid = storeid;
            model.rawurl = "/MyAccount/Index?storeid=" + storeid;
            ///姓名，手机
            BLL.VipInfoB bll2 = new BLL.VipInfoB();
            VipInfoM model2 = new VipInfoM();
            model2 = bll2.GetOne(cardM.Ing_Fk_VipID);

            if (model2 != null && model2.Ing_Fk_CustID.HasValue)
            {
                BLL.CustB bll3 = new BLL.CustB();
                CustM model3 = new CustM();
                model3 = bll3.GetOne(model2.Ing_Fk_CustID.Value);
                if (model3 != null)
                {
                    model.mobile = model3.str_mobile;
                    model.ident = model3.str_ident;
                    model.cusname = model3.str_CusName;
                    model.custid = model3.Ing_Pk_CustID;
                }
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
                model.headerimg = weixinInfo.headimgurl;
                model.nickname = weixinInfo.nickname;
            }
            catch { }

            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult ChargeMon()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            ChargeMonResultM model = new ChargeMonResultM();
            BLL.StoreInfoB storeinfo1B = new BLL.StoreInfoB();
            StoreInfoM infoM = new StoreInfoM();
            infoM = storeinfo1B.GetOne(storeid);
            if (infoM == null)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }
            model.Str_StoreName = infoM.str_StoreName;
            model.storeid = storeid;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid, storeid);
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            model.cardM = cardM;
            model.rawurl = "/MyAccount/Index?storeid=" + storeid;
            BLL.VipCardChargeMonB inteB = new BLL.VipCardChargeMonB();
            model.list = inteB.GetListbyVipcardID(cardM.Ing_Pk_VipCardId);
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult Coupon()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            MyCouponM model = new MyCouponM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            ViewBag.rawurl = "/MyAccount/Index?storeid=" + storeid;
            
            BLL.CouponDetailsB bll = new BLL.CouponDetailsB();
            model.list0 = bll.GetListbytype(cardM.Ing_Pk_VipCardId, 0);
            model.list1 = bll.GetListbytype(cardM.Ing_Pk_VipCardId, 1);
            model.list2 = bll.GetListbytype(cardM.Ing_Pk_VipCardId, 2);
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult SurplusIntegral()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            ChargeIntegralResultM model = new ChargeIntegralResultM();
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            
            model.cardM = cardM;
            model.rawurl = "/MyAccount/Index?storeid=" + storeid;
            BLL.VipCardChargeIntegralB inteB = new BLL.VipCardChargeIntegralB();
            model.list = inteB.GetListbyVipcardid(cardM.Ing_Pk_VipCardId);


            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult WechatWallet()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            WechatWalletViewM model = new WechatWalletViewM();
            model.openid = openid;
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
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            BLL.WechatWalletB wallet = new BLL.WechatWalletB();
            model.list = wallet.GetWalletList(cardM.Ing_Pk_VipCardId);
            ViewBag.rawurl = "/MyAccount/Index?storeid=" + storeid;
            ViewBag.Price = cardM.dec_WechatPrice;
            return View(model);
        }
        /// <summary>
        /// 验证储值密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult VirifyPwd(string pwd,int vipcardid)
        {
            JsonResult json = new JsonResult();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            BaseResponseModel rev = bll.VirifyPwd(pwd, vipcardid);
            json.Data = rev;
            return json;
        }
        /// <summary>
        /// 验证会员密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult VirifyVipPwd(string pwd, int vipcardid)
        {
            JsonResult json = new JsonResult();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            BaseResponseModel rev = bll.VirifyVipPwd(pwd, vipcardid);
            json.Data = rev;
            return json;
        }
        /// <summary>
        /// 修改储值密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangePwd(string pwd, int vipcardid)
        {
            JsonResult json = new JsonResult();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            BaseResponseModel rev = bll.ChangePwd(pwd, vipcardid);
            json.Data = rev;
            return json;
        }
        /// <summary>
        /// 修改会员密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangeVipPwd(string pwd, int vipcardid)
        {
            JsonResult json = new JsonResult();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            BaseResponseModel rev = bll.ChangeVipPwd(pwd, vipcardid);
            json.Data = rev;
            return json;
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateX(cancelOrderM model)
        {
            JsonResult json = new JsonResult();
            
            BLL.MasterB masB = new BLL.MasterB();
            MasterM m = masB.GetOne(model.id);
            BLL.Wechat.WeChatConfigB bllconfig = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllconfig.GetWeixinConfig(m.Ing_StoreID.Value);
            Boolean openJSSDK = false;
            if (wechatconfig.OpenJSSDK == 1)
            {
                openJSSDK = true;
            }
            TokenHelper tokenHelper = new TokenHelper(6000, wechatconfig.AppID, wechatconfig.AppSecret, openJSSDK);
            model.token = tokenHelper.GetToken();
            BaseResponseModel mod = masB.UpdateX(model);

            json.Data = mod;

            return json;
        }
        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WXPay(ParaForCoponPayM model)
        {
            JsonResult json = new JsonResult();
            BLL.Wechat.WeChatConfigB bllconfig = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllconfig.GetWeixinConfig(model.Ing_StoreID);
            Boolean openJSSDK = false;
            if (wechatconfig.OpenJSSDK == 1)
            {
                openJSSDK = true;
            }
            TokenHelper tokenHelper = new TokenHelper(6000, wechatconfig.AppID, wechatconfig.AppSecret, openJSSDK);
            model.token = tokenHelper.GetToken();
            BLL.VipCardInfoB bll = new BLL.VipCardInfoB();
            BaseResponseModel rev = bll.WXPay(model);
            json.Data = rev;
            return json;
        }
        /// <summary>
        /// 储值充值
        /// </summary>
        /// <returns></returns>
        //[WeixinOAuthAuthorizeAttribute]
        public ActionResult ChargeMon1()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            JSPayChargeMonM model = new JSPayChargeMonM();
            BLL.StoreInfoB storeinfo1B = new BLL.StoreInfoB();
            StoreInfoM infoM = new StoreInfoM();
            infoM = storeinfo1B.GetOne(storeid);
            if (infoM == null)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }
            model.Str_StoreName = infoM.str_StoreName;
            model.Ing_StoreID = storeid;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid, storeid);
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            

            BLL.Wechat.WeChatConfigB bllconfig = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllconfig.GetWeixinConfig(storeid);
            var appId = wechatconfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            var url1 = domain + Request.Url.PathAndQuery;
            Boolean openJSSDK = false;
            if (wechatconfig.OpenJSSDK == 1)
            {
                openJSSDK = true;
            }
            TokenHelper tokenHelper = new TokenHelper(6000, wechatconfig.AppID, wechatconfig.AppSecret, openJSSDK);
            var jsTickect = tokenHelper.GetJSTickect(appId);
            var string1 = "";
            var signature = JSAPI.GetSignature(jsTickect, nonceStr, timestamp, url1, out string1);
            ///Mozilla/5.0 (iPhone; CPU iPhone OS 5_1 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Mobile/9B176 MicroMessenger/4.3.2 
            ///Mozilla/5.0 (iPhone; CPU iPhone OS 5_1 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko) Mobile/9B176 MicroMessenger/4.3.2 NetType/WIFI Language/zh_CN
            var userAgent = Request.UserAgent;

            string userVersion = "-1";
            string str = userAgent.ToLower();///转化为小写
            if (str.Contains("micromessenger"))
            {
                ///说明是微信浏览器
                str = str.Substring(str.IndexOf("micromessenger/") + "micromessenger/".Length);    ///取micromessenger/  后面的字符串
                str = str.Substring(0, str.IndexOf("."));   ///取到第一个点的字符串
                userVersion = str;//微信版本号高于或者等于5.0才支持微信支付
            }

            model.appId = appId;
            model.nonceStr = nonceStr;
            model.timestamp = timestamp;
            model.jsapiTicket = jsTickect;
            model.string1 = string1;
            model.signature = signature;
            model.userAgent = userAgent;
            model.userVersion = userVersion;
            model.openid = openid;
            model.Ing_type = 1;
            model.Ing_pkid = cardM.Ing_Pk_VipCardId;
            model.debug = Public.ConfigValue.WxPayDebug;

            int IngVersion = -1;
            int.TryParse(userVersion, out IngVersion);

            BLL.WxChargeMonB bll = new BLL.WxChargeMonB();
            model.list = bll.GetAll();
            ViewBag.url = "/MyAccount/ChargeMon?storeid=" + storeid;
            return PartialView(model);
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult MyComment()
        {
            int storeid = 0;
            int masterid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            int.TryParse(Request.QueryString["masterid"], out masterid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            MyCommentM model = new MyCommentM();
            BLL.StoreInfoB storeinfo1B = new BLL.StoreInfoB();
            StoreInfoM infoM = new StoreInfoM();
            infoM = storeinfo1B.GetOne(storeid);
            if (infoM == null)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }
            model.str_StoreName = infoM.str_StoreName;
            model.storeid = storeid;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid, storeid);
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }

            model.masid = masterid;
            model.vipcardid = cardM.Ing_Pk_VipCardId;

            BLL.MasterB bll1 = new BLL.MasterB();
            OrderM model1 = bll1.GetCommentRecordByMasID(masterid);
            if (model1 == null)
            {
                model.message = "没有该订单，或者该订单还没有离店";
                return PartialView(model);
            }
            model.masid = model1.Ing_Pk_MasterID;
            model.storeid = model1.Ing_StoreID;
            model.RoomType = model1.str_RoomType;
            model.RoomNo = model1.str_RoomNo;
            model.str_StoreName = model1.str_StoreName;

            BLL.CommentsB bll2 = new BLL.CommentsB();
            CommentsM model2 = bll2.GetRecordByMasID(model.masid);
            if (model2 != null)
            {
                model.message = "已经评论过了，不能重复评论";
                return PartialView(model);
            }

            return PartialView(model);
        }

        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveComment(CommentsM model)
        {
            JsonResult json = new JsonResult();
            BLL.CommentsB bll = new BLL.CommentsB();
            BaseResponseModel mod = bll.SaveOrUpdate(model);
            json.Data = mod;

            return json;
        }
       
    }
}