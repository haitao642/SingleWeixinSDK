using Model.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.Attributes
{
    public class ShopErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filter)
        {
            Exception ex = filter.Exception;
            string name = ex.GetType().ToString();
            filter.ExceptionHandled = true;//表示异常已处理
            if (name.Equals("Public.MessageException"))
            {
                if (filter.HttpContext.Request.IsAjaxRequest())
                {
                    filter.Result = new JsonResult { Data = new BaseShopM { code = "0", msg = ex.Message }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
                else
                {
                    filter.Result = new ContentResult { Content = ex.Message };
                }
            }



        }
    }
}