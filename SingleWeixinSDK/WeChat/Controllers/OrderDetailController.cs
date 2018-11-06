using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Complete(int id)
        {
            BLL.MasterB bll = new BLL.MasterB();
            MasterM model = new MasterM();
            model = bll.GetOne(id);
            if (model == null)
            {
                return View(model);
            }

            //string openid = AuthorizationManager.GetOpenID;

            /////绑定成功，推送消息
            //TemplateValue m = new TemplateValue();
            //m.LylOrderID = 2;
            //m.LylOpenID = openid;
            //m.LylaccessToken = WeixinConfig.TokenHelper.GetToken();
            //m.LylUrl = string.Format("{0}/OrderList/Index", Public.ConfigValue.GetDomain);


            //m.first = "您的订单已提交成功";
            //m.orderID = model.str_Pk_Accnt;
            //if (model.dec_ActualRate.HasValue)
            //{
            //    m.orderMoneySum = model.dec_ActualRate.Value.ToString("F0");
            //}
            //else
            //{
            //    m.orderMoneySum = "0";
            //}
            //m.backupFieldName = "入住时间";
            //m.backupFieldData = string.Format("{0}-{1}", model.dt_ArrDate.Value.ToString("MM/dd"), model.dt_DepDate.Value.ToString("MM/dd"));
            //m.remark = "如有问题请致电4008-060-888或直接在微信留言，客服将第一时间为您服务！";

            //TemplateSend.PushMessageBat(m);

            return View(model);
        }
    }
}