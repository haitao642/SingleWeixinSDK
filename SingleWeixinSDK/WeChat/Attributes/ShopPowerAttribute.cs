using Deepleo.Weixin.SDK.Pay;
using Model.Shop;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.Attributes
{
    /// <summary>
    /// 商城签名验证
    /// </summary>
    public class ShopPowerAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //获取url
            string url = httpContext.Request.Url.AbsoluteUri;//http://localhost:1993/ShopService/UserInfo?mobile=15027075513&&openid=sue&sign=sdfajfjljfiwoj

            //把url生成签名
            string strsign = url.Substring(url.IndexOf("?") + 1);//mobile=15027075513&&openid=sue
            if (string.IsNullOrEmpty(strsign) || strsign.Length == url.Length) //判断url是否正确
            {
                return false;
            }
            strsign = strsign.Replace("&&", "&");//为了防止出错,做下替换

            Dictionary<string, string> list = new Dictionary<string, string>();//存入字典类里
            foreach (string li in strsign.Split('&'))
            {
                if (string.IsNullOrEmpty(li)) continue;
                string[] temp = li.Split('=');
                if (string.IsNullOrEmpty(temp[0]) || string.IsNullOrEmpty(temp[1])) continue;
                list.Add(temp[0], temp[1]);
            }

            if (list.Count == 0) return false;

            string sign = WxPayAPI.Sign(list, Public.ConfigValue.ShopKey);//生成签名

            LogHelper.LogInfo(string.Concat("客户端签名:", httpContext.Request.QueryString["sign"], " 服务器签名:" + sign, "客户端rul:", url));

            if (!sign.Equals(httpContext.Request.QueryString["sign"])) return false;//比对签名是否一致

            return true;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filter)
        {
            if (filter.HttpContext.Request.IsAjaxRequest())
            {
                filter.Result = new JsonResult { Data = new BaseShopM { code = "0", msg = "签名效验失败" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                filter.Result = new ContentResult { Content = "签名效验失败" };
            }
        }
    }
}