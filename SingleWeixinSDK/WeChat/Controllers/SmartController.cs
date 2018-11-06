using Model;
using Model.Cust;
using Model.SmartControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChat.Services;
using WeChat.Attributes;

namespace WeChat.Controllers
{
    public class SmartController : Controller
    {
        // GET: Smart
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult Index()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            BLL.SmartControl.SmartControlB smartB = new BLL.SmartControl.SmartControlB();
            string rawurl = Request.RawUrl;
            SmartM model = new SmartM();
            rawurl = HttpUtility.UrlEncode(rawurl);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            //LogHelper.LogInfo("smart:" + openid);
            model.openid = openid;
            model.isOnline = false;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByopenID(openid);
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url, true);
            }
            model.vipcardid = cardM.Ing_Pk_VipCardId;
            model.vipid = cardM.Ing_Fk_VipID;
            ////获取会员信息
            BLL.VipInfoB bll2 = new BLL.VipInfoB();
            VipInfoM model2 = new VipInfoM();
            model2 = bll2.GetOne(cardM.Ing_Fk_VipID);
            if (model2 != null && model2.Ing_Fk_CustID.HasValue)
            {
                model.custid = (int)model2.Ing_Fk_CustID;
                BLL.CustB bll3 = new BLL.CustB();
                CustM model3 = new CustM();
                model3 = bll3.GetOne(model2.Ing_Fk_CustID.Value);
                model.custName = model3.str_CusName;
                if (model3 != null)
                {
                    BLL.MasterB bll4 = new BLL.MasterB();
                    ///获取在住订单
                    List<OrderM> orderlist = bll4.GetOrderbycardid(cardM.Ing_Pk_VipCardId, 1);
                    if (orderlist == null || orderlist.Count == 0)
                    {

                        model.isOnline = false;
                        return PartialView(model);
                    }
                    foreach (OrderM orderm in orderlist)
                    {
                        if (orderm.str_Sta.Equals("I"))//根据在住订单获取设备列表
                        {
                            model.isOnline = true;
                            model.masterid = orderm.Ing_Pk_MasterID;
                            model.roomNo = orderm.str_RoomNo;
                            BLL.StoreInfoB bll6 = new BLL.StoreInfoB();
                            string str_LockStoreNo = bll6.GetStore(orderm.Ing_StoreID).str_LockStoreNo;
                            int lockstoreid = 0;
                            int.TryParse(str_LockStoreNo, out lockstoreid);
                            model.ing_storeID = lockstoreid;//转换成维护平台的门店id
                            BLL.SmartControl.SmartControlB bll5 = new BLL.SmartControl.SmartControlB();
                            model.info = bll5.getDeviceListByRoom(orderm.str_RoomNo, lockstoreid, model3.Ing_Pk_CustID, model3.str_CusName, openid, orderm.Ing_Pk_MasterID);
                            model.storename = bll6.GetStore(orderm.Ing_StoreID).str_StoreName;
                            break;
                        }
                    }

                }
            }
            return PartialView(model);


        }
        //[WeixinOAuthAuthorizeAttribute]
        public ActionResult Curtain()
        {
            string gatewayid = Request.QueryString["gatewayid"];
            string controllerid = Request.QueryString["controllerid"];
            string storeid = Request.QueryString["storeid"];
            string nickname = Request.QueryString["nickname"];
            string openid = Request.QueryString["openid"];
            string custid = Request.QueryString["custid"];
            string custName = Request.QueryString["custName"];
            string roomNo = Request.QueryString["roomNo"];
            string masterid = Request.QueryString["masterid"];
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = gatewayid;
            request.hotelid = storeid;
            request.controllerid = controllerid;
            request.type = 0;
            request.str_NickName = nickname;
            request.str_OpenID = openid;
            request.Ing_CustID = Convert.ToInt32(custid);
            request.str_CustName = custName;
            request.str_RoomNo = roomNo;
            request.Ing_MasterID = Convert.ToInt32(masterid);
            SupportKeyM response = bll.getSupportKey(request);
            if (response == null)
            {
                response = new SupportKeyM();
            }
            ControlViewM model = new ControlViewM();
            model.contollerid = Convert.ToInt32(controllerid);
            model.gatewayid = gatewayid;
            model.hotelid = Convert.ToInt32(storeid);
            model.nickname = nickname;
            model.response = response;
            model.Ing_CustID = Convert.ToInt32(custid);
            model.Ing_MasterID = Convert.ToInt32(masterid);
            model.str_CustName = custName;
            model.str_OpenID = openid;
            model.str_RoomNo = roomNo;
            return PartialView(model);
        }
        /// <summary>
        /// 按键控制
        /// </summary>
        /// <param name="requestM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ControlDevice(ControlRequestM requestM)
        {
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            ControlResponseM model = new ControlResponseM();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = requestM.gatewayid;
            request.hotelid = requestM.hotelid.ToString();
            request.controllerid = requestM.contollerid.ToString();
            request.type = requestM.type;
            request.str_NickName = requestM.nickname;
            request.str_OpenID = requestM.str_OpenID;
            request.Ing_CustID = requestM.Ing_CustID;
            request.str_CustName = requestM.str_CustName;
            request.str_RoomNo = requestM.str_RoomNo;
            request.Ing_MasterID = requestM.Ing_MasterID;
            //SupportKeyM response = bll.getSupportKey(request);
            //if (response == null) { }
            //else
            //{
            //    if (!response.keylabel7.KeyLabel7.ContainsKey(requestM.keyid.ToString()))
            //    {
            //        model.result = "2002";
            //        model.msg = "不支持该按键";
            //        JsonResult jre = new JsonResult();
            //        jre.Data = model;
            //        return jre;
            //    }
            //}
            JsonResult jr = new JsonResult();
            model = bll.controlDevice(requestM);
            jr.Data = model;
            return jr;
        }

        /// <summary>
        /// 获取空调状态
        /// </summary>
        /// <param name="requestM"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetStatus(AirStatusRequestM requestM)
        {
            JsonResult jr = new JsonResult();
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            AirStatusResponseM model = bll.airStatus(requestM);
            jr.Data = model;
            return jr;
        }
        public ActionResult BesTv()
        {
            string gatewayid = Request.QueryString["gatewayid"];
            string controllerid = Request.QueryString["controllerid"];
            string storeid = Request.QueryString["storeid"];
            string nickname = Request.QueryString["nickname"];
            string openid = Request.QueryString["openid"];
            string custid = Request.QueryString["custid"];
            string custName = Request.QueryString["custName"];
            string roomNo = Request.QueryString["roomNo"];
            string masterid = Request.QueryString["masterid"];
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = gatewayid;
            request.hotelid = storeid;
            request.controllerid = controllerid;
            request.type = 0;
            request.str_NickName = nickname;
            request.str_OpenID = openid;
            request.Ing_CustID = Convert.ToInt32(custid);
            request.str_CustName = custName;
            request.str_RoomNo = roomNo;
            request.Ing_MasterID = Convert.ToInt32(masterid);
            SupportKeyM response = bll.getSupportKey(request);
            if (response == null)
            {
                response = new SupportKeyM();
            }
            ControlViewM model = new ControlViewM();
            model.contollerid = Convert.ToInt32(controllerid);
            model.gatewayid = gatewayid;
            model.hotelid = Convert.ToInt32(storeid);
            model.nickname = nickname;
            model.response = response;
            model.Ing_CustID = Convert.ToInt32(custid);
            model.Ing_MasterID = Convert.ToInt32(masterid);
            model.str_CustName = custName;
            model.str_OpenID = openid;
            model.str_RoomNo = roomNo;
            return PartialView(model);
        }
        public ActionResult KLAir()
        {
            string gatewayid = Request.QueryString["gatewayid"];
            string controllerid = Request.QueryString["controllerid"];
            string storeid = Request.QueryString["storeid"];
            string nickname = Request.QueryString["nickname"];
            string openid = Request.QueryString["openid"];
            string custid = Request.QueryString["custid"];
            string custName = Request.QueryString["custName"];
            string roomNo = Request.QueryString["roomNo"];
            string masterid = Request.QueryString["masterid"];
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = gatewayid;
            request.hotelid = storeid;
            request.controllerid = controllerid;
            request.type = 1;
            request.str_NickName = nickname;
            request.str_OpenID = openid;
            request.Ing_CustID = Convert.ToInt32(custid);
            request.str_CustName = custName;
            request.str_RoomNo = roomNo;
            request.Ing_MasterID = Convert.ToInt32(masterid);
            SupportKeyM response = bll.getSupportKey(request);
            if (response == null)
            {
                response = new SupportKeyM();
            }
            ControlViewM model = new ControlViewM();
            model.contollerid = Convert.ToInt32(controllerid);
            model.gatewayid = gatewayid;
            model.hotelid = Convert.ToInt32(storeid);
            model.nickname = nickname;
            model.response = response;
            model.Ing_CustID = Convert.ToInt32(custid);
            model.Ing_MasterID = Convert.ToInt32(masterid);
            model.str_CustName = custName;
            model.str_OpenID = openid;
            model.str_RoomNo = roomNo;
            return PartialView(model);
        }
        public ActionResult CHTv()
        {
            string gatewayid = Request.QueryString["gatewayid"];
            string controllerid = Request.QueryString["controllerid"];
            string storeid = Request.QueryString["storeid"];
            string nickname = Request.QueryString["nickname"];
            string openid = Request.QueryString["openid"];
            string custid = Request.QueryString["custid"];
            string custName = Request.QueryString["custName"];
            string roomNo = Request.QueryString["roomNo"];
            string masterid = Request.QueryString["masterid"];
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = gatewayid;
            request.hotelid = storeid;
            request.controllerid = controllerid;
            request.type = 0;
            request.str_NickName = nickname;
            request.str_OpenID = openid;
            request.Ing_CustID = Convert.ToInt32(custid);
            request.str_CustName = custName;
            request.str_RoomNo = roomNo;
            request.Ing_MasterID = Convert.ToInt32(masterid);
            SupportKeyM response = bll.getSupportKey(request);
            if (response == null)
            {
                response = new SupportKeyM();
            }
            ControlViewM model = new ControlViewM();
            model.contollerid = Convert.ToInt32(controllerid);
            model.gatewayid = gatewayid;
            model.hotelid = Convert.ToInt32(storeid);
            model.nickname = nickname;
            model.response = response;
            model.Ing_CustID = Convert.ToInt32(custid);
            model.Ing_MasterID = Convert.ToInt32(masterid);
            model.str_CustName = custName;
            model.str_OpenID = openid;
            model.str_RoomNo = roomNo;
            return PartialView(model);
        }
        public ActionResult CHTv2()
        {
            string gatewayid = Request.QueryString["gatewayid"];
            string controllerid = Request.QueryString["controllerid"];
            string storeid = Request.QueryString["storeid"];
            string nickname = Request.QueryString["nickname"];
            string openid = Request.QueryString["openid"];
            string custid = Request.QueryString["custid"];
            string custName = Request.QueryString["custName"];
            string roomNo = Request.QueryString["roomNo"];
            string masterid = Request.QueryString["masterid"];
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = gatewayid;
            request.hotelid = storeid;
            request.controllerid = controllerid;
            request.type = 0;
            request.str_NickName = nickname;
            request.str_OpenID = openid;
            request.Ing_CustID = Convert.ToInt32(custid);
            request.str_CustName = custName;
            request.str_RoomNo = roomNo;
            request.Ing_MasterID = Convert.ToInt32(masterid);
            SupportKeyM response = bll.getSupportKey(request);
            if (response == null)
            {
                response = new SupportKeyM();
            }
            ControlViewM model = new ControlViewM();
            model.contollerid = Convert.ToInt32(controllerid);
            model.gatewayid = gatewayid;
            model.hotelid = Convert.ToInt32(storeid);
            model.nickname = nickname;
            model.response = response;
            model.Ing_CustID = Convert.ToInt32(custid);
            model.Ing_MasterID = Convert.ToInt32(masterid);
            model.str_CustName = custName;
            model.str_OpenID = openid;
            model.str_RoomNo = roomNo;
            return PartialView(model);
        }
        public ActionResult Sound()
        {
            string gatewayid = Request.QueryString["gatewayid"];
            string controllerid = Request.QueryString["controllerid"];
            string storeid = Request.QueryString["storeid"];
            string nickname = Request.QueryString["nickname"];
            string openid = Request.QueryString["openid"];
            string custid = Request.QueryString["custid"];
            string custName = Request.QueryString["custName"];
            string roomNo = Request.QueryString["roomNo"];
            string masterid = Request.QueryString["masterid"];
            BLL.SmartControl.SmartControlB bll = new BLL.SmartControl.SmartControlB();
            SupportRequestM request = new SupportRequestM();
            request.gatewayid = gatewayid;
            request.hotelid = storeid;
            request.controllerid = controllerid;
            request.type = 0;
            request.str_NickName = nickname;
            request.str_OpenID = openid;
            request.Ing_CustID = Convert.ToInt32(custid);
            request.str_CustName = custName;
            request.str_RoomNo = roomNo;
            request.Ing_MasterID = Convert.ToInt32(masterid);
            SupportKeyM response = bll.getSupportKey(request);
            if (response == null)
            {
                response = new SupportKeyM();
            }
            ControlViewM model = new ControlViewM();
            model.contollerid = Convert.ToInt32(controllerid);
            model.gatewayid = gatewayid;
            model.hotelid = Convert.ToInt32(storeid);
            model.nickname = nickname;
            model.response = response;
            model.Ing_CustID = Convert.ToInt32(custid);
            model.Ing_MasterID = Convert.ToInt32(masterid);
            model.str_CustName = custName;
            model.str_OpenID = openid;
            model.str_RoomNo = roomNo;
            return PartialView(model);
        }
    }
}