using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WeChat.Services
{
    public class AuthorizationManager
    {
        public static void SetTicket(bool remeberMe, int version, string identity, string displayName)
        {
            LogHelper.LogInfo("version:" + version + ",identity:" + identity + ",displayName:" + displayName);
            try
            {
                FormsAuthentication.SetAuthCookie(identity, remeberMe);
                if (string.IsNullOrEmpty(displayName))//displayName为空会导致cookies写入失败
                {
                    displayName = "匿名";
                }
                var authTicket = new FormsAuthenticationTicket(
                    version,
                    identity,
                    DateTime.Now,
                    DateTime.Now.AddHours(remeberMe ? 3 : 1),
                    remeberMe,
                    displayName, FormsAuthentication.FormsCookiePath);
                string encrytedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrytedTicket);
                authCookie.Expires = DateTime.Now.AddHours(remeberMe ? 3 : 1);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }catch(Exception ex)
            {
                LogHelper.LogInfo("error:" + ex.Message );
            }
        }

        /// <summary>
        /// 移除cookie
        /// </summary>
        public static void ClearTicket()
        {
            HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
        }
        /// <summary>
        /// 获取openid
        /// </summary>
        public static string GetOpenID
        {
            get
            {
                string openid = string.Empty;
                //测试
                openid = Public.ConfigValue.GetOpenid;
                if (!string.IsNullOrEmpty(openid))
                {
                    return openid;
                }
                if (HttpContext.Current.Request.IsAuthenticated)
                {
                    openid = HttpContext.Current.User.Identity.Name.Trim();
                }
                return openid;
            }
        }
    }
}