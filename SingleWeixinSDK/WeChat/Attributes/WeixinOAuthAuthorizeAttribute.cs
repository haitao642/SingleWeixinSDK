using Model.WeiXin;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChat.App_Start;
using WeChat.Services;

namespace WeChat.Attributes
{
    /// <summary>
    /// 微信OAuth
    /// </summary>
    public class WeixinOAuthAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var target_uri = httpContext.Request.RawUrl;
            var identity = httpContext.User.Identity;
            try
            {
                LogHelper.LogInfo("identity:" + identity.Name.Trim());
            }catch(Exception ex)
            {
                LogHelper.LogInfo(ex.Message);
            }
            //用来测试
            //if (!string.IsNullOrEmpty(AuthorizationManager.GetOpenID) &&
            //    "ofJKEv87HL0HJgImZFcHmHdbhGvI,ofJKEv_F74hFCO7z5DrdnMRDNvQw,ofJKEvy-AKRPX8HGg8yZy-tUAIYg,ofJKEv8bh82Rj2aFpFN_4_iWYSy0,ofJKEv32ir81hIzVZ0KA8RfV629M".Contains(AuthorizationManager.GetOpenID))
            //{ 
            //   if(HttpRuntime.Cache.Get(AuthorizationManager.GetOpenID)!=null)return true;

            //   //清除cookie
            //   AuthorizationManager.ClearTicket();

            //   HttpRuntime.Cache.Insert(AuthorizationManager.GetOpenID, target_uri, null, DateTime.Now.AddMinutes(3), TimeSpan.Zero, CacheItemPriority.Normal, null);

            //  //重新授权
            //    return false;
            //}
            //如果测试的openid,就通过
            if (!string.IsNullOrEmpty(AuthorizationManager.GetOpenID)) return true;

            return false;

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];

            ///target_uri加入storeid
            var target_uri = filterContext.HttpContext.Request.Url.AbsoluteUri;
            int storeid = Convert.ToInt32(filterContext.HttpContext.Request.QueryString["storeid"]);
            LogHelper.LogInfo("HandleUnauthorizedRequest"+storeid.ToString());
            target_uri += "/" + storeid;
            var userAgent = filterContext.RequestContext.HttpContext.Request.UserAgent;
            var redirect_uri = string.Format("{0}/OAuth/Callback", domain);//这里需要完整url地址，对应Controller里面的OAuthController的Callback
            BLL.Wechat.WeChatConfigB wccb = new BLL.Wechat.WeChatConfigB();
            WeChatConfigM we = wccb.GetWeixinConfig(storeid);
            var scope = we.OauthScope;
            // var state = DateTime.Now.ToString("yyyyMMddHHmmss") + (new Random().Next(100, 999)).ToString();//state保证唯一即可,可以用其他方式生成

            //这里为了实现简单，将state和target_uri保存在Cache中，并设置过期时间为2分钟。您可以采用其他方法!!!
            // HttpRuntime.Cache.Insert(state, target_uri, null,DateTime.Now.AddMinutes(3), TimeSpan.Zero, CacheItemPriority.Normal, null);
            var weixinOAuth2Url = string.Format(
                     "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}#wechat_redirect",
                      we.AppID, redirect_uri, scope, target_uri);
            LogWriter.Default.WriteInfo(string.Format("小程序获取客户微信资料,{0},缓存key:{1},缓存value:{2},缓存域id:{3}", weixinOAuth2Url, "", target_uri, HttpRuntime.AppDomainId));
            filterContext.Result = new RedirectResult(weixinOAuth2Url);
        }


    }
}