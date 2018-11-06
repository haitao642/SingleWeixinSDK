using Deepleo.Weixin.SDK;
using Model.WeiXin;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WeChat.App_Start;
using WeChat.Attributes;
using WeChat.Services;

namespace WeChat.Controllers
{
    public class OAuthController : Controller
    {
        // GET: OAuth
        [WeixinOAuthAuthorize]
        public ActionResult Index()
        {
            ViewBag.openid = AuthorizationManager.GetOpenID;
            return View();
        }
        [HttpGet]
        public ActionResult Callback()
        {
            LogHelper.LogInfo("Callback:");
            var code = Request.QueryString.Get("code");
            LogHelper.LogInfo("url:"+Request.RawUrl);
            LogHelper.LogInfo("code:" + code);
            if (string.IsNullOrEmpty(code))//没有code表示授权失败
            {
                return RedirectToAction("Failed", "OAuth");
            }
            var state =Request.QueryString.Get("state");
            int index = state.LastIndexOf('/');
            string targeturl = state.Substring(0, index);
            LogHelper.LogInfo("targeturl:" + targeturl);
            int storeid = Convert.ToInt32(state.Substring(index+1, state.Length-index-1));
            
            LogHelper.LogInfo("storeid:" + storeid);
            //var cache_status =HttpRuntime.Cache.Get(state);
            //var redirect_url = state;//cache_status == null ? "/" : cache_status.ToString();//没有获取到state,就跳转到首页
            BLL.Wechat.WeChatConfigB wccb = new BLL.Wechat.WeChatConfigB();
            WeChatConfigM we = wccb.GetWeixinConfig(storeid);
            var scope = we.OauthScope;
            var access_token_scope = "";
            double expires_in = 0;
            var access_token = "";
            var openId = "";
            var token = OAuth2API.GetAccessToken(code, we.AppID, we.AppSecret);
            string nickname = "";
            dynamic userinfo;
            try
            {
                if (scope == "snsapi_userinfo")
                {
                    LogHelper.LogInfo("snsapi_userinfo");
                    var refreshAccess_token = OAuth2API.RefreshAccess_token(token.refresh_token, we.AppID);
                    access_token = refreshAccess_token.access_token;//通过code换取的是一个特殊的网页授权access_token，与基础支持中的access_token（该access_token用于调用其他接口）不同。
                    openId = refreshAccess_token.openid;
                    LogHelper.LogInfo("openId:"+openId);
                    access_token_scope = refreshAccess_token.scope;
                    expires_in = refreshAccess_token.expires_in;
                    userinfo = OAuth2API.GetUserInfo(access_token, openId);//snsapi_userinfo,可以用户在未关注公众号的情况下获取用户基本信息

                    ////给老会员增加unionid
                    //BLL.VipCardInfoB infoB = new BLL.VipCardInfoB();
                    //Model.VipCardInfoM mm = infoB.GetVipCardByopenID(openId);
                    //if (mm != null && string.IsNullOrEmpty(mm.str_Unionid)) //之前微信上z注册的会员
                    //{
                    //    mm.str_Unionid = userinfo.unionid;
                    //    infoB.UpdateVip(mm);
                    //}
                    //mm = null;
                    //string unionid = string.Empty;
                    //try
                    //{
                    //    unionid = userinfo.unionid;
                    //}
                    //catch (Exception)
                    //{

                    //}
                    //mm = infoB.GetVipCardByunionID(unionid);//小程序注册的会员,存的都是unionid,openid不保存
                    //if (mm != null && string.IsNullOrEmpty(mm.str_wcopenid))
                    //{
                    //    mm.str_wcopenid = userinfo.openid;
                    //    infoB.UpdateVip(mm);
                    //}
                }
                else
                {
                    access_token = WeixinConfig.TokenHelper.GetToken();//基础支持中的access_token
                    openId = token.openid;
                    expires_in = token.expires_in;
                    //TODO: 如果用户已经关注，可以用openid，获取用户信息。
                    userinfo = UserAdminAPI.GetInfo(access_token, openId);//如果本地已经存储了用户基本信息，建议在本地获取。

                    ////给老会员增加unionid
                    //BLL.VipCardInfoB infoB = new BLL.VipCardInfoB();
                    //Model.VipCardInfoM mm = infoB.GetVipCardByopenID(openId);
                    //if (mm != null && string.IsNullOrEmpty(mm.str_Unionid)) //之前微信上z注册的会员
                    //{
                    //    mm.str_Unionid = userinfo.unionid;
                    //    infoB.UpdateVip(mm);
                    //}
                    //mm = null;
                    //string unionid = string.Empty;
                    //try
                    //{
                    //    unionid = userinfo.unionid;
                    //}
                    //catch (Exception)
                    //{

                    //}
                    //mm = infoB.GetVipCardByunionID(unionid);//小程序注册的会员,存的都是unionid,openid不保存
                    //if (mm != null && string.IsNullOrEmpty(mm.str_wcopenid))
                    //{
                    //    mm.str_wcopenid = userinfo.openId;
                    //    infoB.UpdateVip(mm);
                    //}
                }

                if (userinfo != null)
                {
                    try
                    {
                        nickname = userinfo.nickname;
                    }
                    catch (Exception)
                    {
                        nickname = "匿名";
                    }
                }
                //写入cookies
                AuthorizationManager.SetTicket(true, 1, openId, nickname);
            }
            catch (Exception)
            {
                Public.LogHelper.LogInfo(string.Format("微信授权出现异常,微信openid:{0},跳转url:{1}", openId, ""));
                return new RedirectResult(targeturl, true);
            }
            Thread.Sleep(500);//暂停半秒钟，以等待IOS设置Cookies的延迟
            Public.LogHelper.LogInfo(string.Format("微信授权成功,微信openid:{0},跳转url:{1},缓存key;{2},缓存值:{3},缓存域id:{4}",
                openId, "", state, "", HttpRuntime.AppDomainId));
            return new RedirectResult(targeturl, true);
        }

        public ActionResult Failed()
        {
            ViewBag.message = "OAuth失败，您拒绝了授权申请或者公众号没有此权限.";
            return View();
        }
    }
}