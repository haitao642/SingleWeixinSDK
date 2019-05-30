using Model;
using Model.ChuanJie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WeChat.Controllers
{
    public class ChuanJieController : Controller
    {
        // GET: ChuanJie
        public ActionResult Index()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            ChuanJieIndexModel model = new ChuanJieIndexModel();
            ///门店信息
            BLL.StoreInfoB bll1 = new BLL.StoreInfoB();
            StoreM m1 = bll1.GetStore(storeid);
            if (m1 == null)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            model.storeM = m1;
            return PartialView(model);
        }

        public ActionResult HotelSpringIndex()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            HotSpringIndexModel model = new HotSpringIndexModel();
            BLL.StoreInfoB bll1 = new BLL.StoreInfoB();
            StoreM m1 = bll1.GetStore(storeid);
            if (m1 == null)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            model.storeM = m1;
            return PartialView(model);
        }

    }
}