using BLL.Wechat;
using Deepleo.Weixin.SDK.Helpers;
using Deepleo.Weixin.SDK.JSSDK;
using Model;
using Model.Cust;
using Model.RoomCenter;
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
    public class HotelController : Controller
    {
        // GET: Hotel
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult Index()
        {
            
            string strarr = Request.QueryString["strarr"];
            string strdep = Request.QueryString["strdep"];
            //string strFront6Hour = Request.QueryString["Front6Hour"];

            DateTime dtarr = DateTime.Now;
            if(strarr!=null)
            DateTime.TryParse(strarr, out dtarr);
            
            DateTime dtdep = DateTime.Now.AddDays(1);
            if (strdep!=null)
            DateTime.TryParse(strdep, out dtdep);

            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            //int Front6Hour = 0;
            //int.TryParse(strFront6Hour, out Front6Hour);

            string openid = AuthorizationManager.GetOpenID;
            HotelDetailM model = new HotelDetailM();
            //model.showAddOneNight = 0;
            //model.Front6Hour = Front6Hour;
            //if (DateTime.Now.Hour < ConfigValue.AddOneNightHour)
            //{
            //    model.showAddOneNight = 1;
            //}
            //else
            //{
            //    model.Front6Hour = 0;
            //}
            model.listroomtype = new List<RoomType1M>();
            if (storeid == 0)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            WeChatConfigB bllwe = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllwe.GetWeixinConfig(storeid);
            HotelM searchM = new HotelM();
            searchM.openid = openid;
            searchM.dtArr = dtarr;
            searchM.dtDep = dtdep;
            model.searchM = searchM;
            ///门店信息
            BLL.StoreInfoB bll1 = new BLL.StoreInfoB();
            StoreM m1 = bll1.GetStore(storeid);
            if (m1 == null)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            model.storeDetailM = m1;
            ///房型
            BLL.RoomTypeB bll4 = new BLL.RoomTypeB();
            List<RoomType1M> list4 = new List<RoomType1M>();
            list4 = bll4.GetUseFulList(storeid, model.searchM.dtArr);
            if (list4 == null || list4.Count == 0)
            {
                model.message = "该酒店没有可用房型";
                return PartialView(model);
            }

            BLL.MasterB bll5 = new BLL.MasterB();
            int index = 0;
            foreach (RoomType1M m5 in list4)
            {
                index++;
                m5.display_order ="roomtype_" +index;
                m5.display_orderIcon = "roomIcon_" + index;
                m5.listimg = bll4.GetRoomTypeImg(storeid, m5.strRoomTypeCode);
                List<RoomCanUseM> cmList = bll5.GetRoomCanUse(storeid, model.searchM.dtArr, model.searchM.dtDep, m5.strRoomTypeCode);
                if (cmList == null || cmList.Count == 0)
                {
                    m5.CanUseRoom = 0;
                }

                RoomCanUseM cm = cmList.FirstOrDefault();
                if (cm != null)
                {
                    m5.CanUseRoom = cm.minnum;
                }

                //查出>0的，和天数比较
                if (cmList.Where(a => a.minnum > 0).Count() != (model.searchM.dtDep - model.searchM.dtArr.Date).Days)
                {
                    m5.CanUseRoom = 0;
                }


                if (model.Ing_FirstMaster > 0)
                {
                    m5.dec_FirstLivePrice = 0;
                }
            }
            model.listroomtype = list4;

            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult HourIndex()
        {
            string strarr = Request.QueryString["strarr"];
            string strtime = Request.QueryString["strtime"];
            DateTime now = DateTime.Now.AddHours(1);
            DateTime dtarr = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
            
            if(strarr!=null&& strtime!=null)
            DateTime.TryParse(string.Format("{0} {1}:00", strarr, strtime), out dtarr);
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string openid = AuthorizationManager.GetOpenID;
            HotelDetailM model = new HotelDetailM();
            //model.showAddOneNight = 0;
            //model.Front6Hour = Front6Hour;
            //if (DateTime.Now.Hour < ConfigValue.AddOneNightHour)
            //{
            //    model.showAddOneNight = 1;
            //}
            //else
            //{
            //    model.Front6Hour = 0;
            //}
            model.strtime = dtarr.Hour;
            model.listroomtype = new List<RoomType1M>();
            if (storeid == 0)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            WeChatConfigB bllwe = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllwe.GetWeixinConfig(storeid);
            HotelM searchM = new HotelM();
            searchM.openid = openid;
            searchM.dtArr = dtarr;
            searchM.dtDep = searchM.dtArr.AddHours(4);
            model.searchM = searchM;
            ///门店信息
            BLL.StoreInfoB bll1 = new BLL.StoreInfoB();
            StoreM m1 = bll1.GetStore(storeid);
            if (m1 == null)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            model.storeDetailM = m1;
            int start = wechatconfig.HourStart;
            int end = wechatconfig.HourEnd;
            model.HourStart = start;
            model.HourEnd = end;
            int cur = 0;
            int.TryParse(DateTime.Now.ToString("HHmm"), out cur);
            if (cur < start || cur >= end)
            {
                model.message = "不在时钟房的预订时间范围";
                return PartialView(model);
            }

            int.TryParse(dtarr.ToString("HHmm"), out cur);
            if (cur < start || cur > end)
            {
                model.message = "不在时钟房的预订时间范围";
                return PartialView(model);
            }

            ///房型
            BLL.RoomTypeB bll4 = new BLL.RoomTypeB();
            List<RoomType1M> list4 = new List<RoomType1M>();
            list4 = bll4.GetUseFulHourList(storeid, model.searchM.dtArr);
            if (list4 == null || list4.Count == 0)
            {
                model.message = "该酒店没有可用的钟点房房型";

                return PartialView(model);
            }

            BLL.MasterB bll5 = new BLL.MasterB();
            int index = 0;
            foreach (RoomType1M m5 in list4)
            {
                index++;
                m5.display_order = "roomtype_" + index;
                m5.display_orderIcon = "roomIcon_" + index;
                m5.listimg = bll4.GetRoomTypeImg(storeid, m5.strRoomTypeCode);
                ///没有配钟点房方案的
                if (m5.price0 == 0)
                {
                    continue;
                }
                ///有个20%的限制，  那么，小于总数小于5间的可以直接过滤
                if (m5.roomnum < 5)
                {
                    continue;
                }

                RoomCanUseM cm = new RoomCanUseM();
                cm = bll5.GetRoomCanUse(storeid, model.searchM.dtArr, model.searchM.dtDep, m5.strRoomTypeCode).FirstOrDefault();
                if (cm != null)
                {
                    if (cm.minnum <= 0)
                    {
                        continue;
                    }
                    if (cm.minnum < (m5.roomnum / 5))
                    {
                        continue;
                    }
                    m5.CanUseRoom = cm.minnum;
                }

            }
            model.listroomtype = list4;
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult HotelDetail()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string openid = AuthorizationManager.GetOpenID;
            LogHelper.LogInfo("HotelDetail:" + openid);
            HotelDetailM model = new HotelDetailM();
            if (storeid == 0)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            #region 获取当前位置要用到的代码
            BLL.Wechat.WeChatConfigB bllconfig = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllconfig.GetWeixinConfig(storeid);
            var appId = wechatconfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            var url = domain + Request.Url.PathAndQuery;
            LogHelper.LogInfo("url:" + url);
            Boolean openJSSDK = false;
            if (wechatconfig.OpenJSSDK == 1)
            {
                openJSSDK = true;
            }
            TokenHelper tokenHelper = new TokenHelper(6000, wechatconfig.AppID, wechatconfig.AppSecret, openJSSDK);
            var jsTickect = tokenHelper.GetJSTickect(appId);
            var string1 = "";
            LogHelper.LogInfo("jsTickect:" + jsTickect);
            var signature = JSAPI.GetSignature(jsTickect, nonceStr, timestamp, url, out string1);
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
            HotelM searchM = new HotelM();
            searchM.appId = appId;
            searchM.nonceStr = nonceStr;
            searchM.timestamp = timestamp;
            searchM.jsapiTicket = jsTickect;
            searchM.string1 = string1;
            searchM.signature = signature;
            searchM.userAgent = userAgent;
            searchM.userVersion = userVersion;
            #endregion
            searchM.openid = openid;
            model.searchM = searchM;

            ///门店信息
            BLL.StoreInfoB bll1 = new BLL.StoreInfoB();
            StoreM m1 = bll1.GetStore(storeid);
            if (m1 == null)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            model.searchM.cityname = m1.str_city;
            /////酒店图片
            model.listimg = bll1.GetStoreImg(storeid);



            ////酒店经纬度

            LogHelper.LogInfo("酒店经纬度:" + m1.str_port_y + "," + m1.str_port_x);

            if (string.IsNullOrEmpty(m1.str_port_y) || string.IsNullOrEmpty(m1.str_port_x))
            {
                m1.str_port_x = "117.719279";
                m1.str_port_y = "24.507606";
            }


            BLL.NearB func = new BLL.NearB();
            ///周边
            model.strtour = func.bindDz(m1.str_port_x, m1.str_port_y, "旅游景点", 7);
            model.strmarket = func.bindDz(m1.str_port_x, m1.str_port_y, "商场", 7);
            model.strbank = func.bindDz(m1.str_port_x, m1.str_port_y, "银行", 7);
            model.strdiet = func.bindDz(m1.str_port_x, m1.str_port_y, "美食", 7);

            model.storeDetailM = m1;
            BLL.CommentsB bll6 = new BLL.CommentsB();
            model.Ing_TotalComment = bll6.GetTotalByStoreID(storeid);
            model.Ing_GoodComment = bll6.GetGoodByStoreID(storeid);
            return PartialView(model);
        }
        public ActionResult HotelComments()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string openid = AuthorizationManager.GetOpenID;
            HotelDetailM model = new HotelDetailM();
            if (storeid == 0)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            //门店信息
            BLL.StoreInfoB bll1 = new BLL.StoreInfoB();
            StoreM m1 = bll1.GetStore(storeid);
            if (m1 == null)
            {
                model.message = "酒店信息不存在";
                return PartialView(model);
            }
            model.storeDetailM = m1;
            BLL.CommentsB bll6 = new BLL.CommentsB();
            model.Ing_TotalComment = bll6.GetTotalByStoreID(storeid);
            model.Ing_GoodComment = bll6.GetGoodByStoreID(storeid);
            return PartialView(model);
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult WriteOrder()
        {
            string rawurl = Request.RawUrl;
            rawurl = HttpUtility.UrlEncode(rawurl);
            string strarr = Request.QueryString["strarr"];
            string strdep = Request.QueryString["strdep"];
            //string strFront6Hour = Request.QueryString["Front6Hour"];

            DateTime dtarr = DateTime.Now;
            DateTime.TryParse(strarr, out dtarr);

            DateTime dtdep = DateTime.Now;
            DateTime.TryParse(strdep, out dtdep);

            int Ing_StoreID = 0;
            int.TryParse(Request.QueryString["storeid"], out Ing_StoreID);

            int roomtypeid = 0;
            int.TryParse(Request.QueryString["roomtypeid"], out roomtypeid);

            //int Front6Hour = 0;
            //int.TryParse(strFront6Hour, out Front6Hour);

            string openid = AuthorizationManager.GetOpenID;
            WriteOrderM model = new WriteOrderM();
            model.roomtypeid = roomtypeid;
            model.openid = openid;
            model.dtArr = dtarr;
            model.dtDep = dtdep;
            model.Ing_StoreID = Ing_StoreID;
            model.backurl = "/hotel";
            model.rawurl = rawurl;
            model.lngvipcardid = 1;

            if (Ing_StoreID == 0)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }

            BLL.StoreInfoB storeinfo1B = new BLL.StoreInfoB();
            StoreInfoM infoM = new StoreInfoM();
            infoM = storeinfo1B.GetOne(model.Ing_StoreID);
            if (infoM == null)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }
            model.str_StoreName = infoM.str_StoreName;
            model.str_StoreFullName = infoM.str_StoreFullName;

            model.backurl = "/Hotel/Index?strarr=" + strarr + "&strdep=" + strdep + "&storeid=" + Ing_StoreID;
            model.lngvipcardid = 0;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid,Ing_StoreID);
            //cardM = cardB.GetVipCardByStoreid(openid, Ing_StoreID);
            if (cardM == null)
            {
                model.message = "请先绑定，再进行预订操作";
                return PartialView(model);
            }
            model.lngvipcardid = cardM.Ing_Pk_VipCardId;
            ///房型
            BLL.RoomTypeB bll1 = new BLL.RoomTypeB();
            RoomTypeM model1 = new RoomTypeM();
            model1 = bll1.GetOne(roomtypeid);

            if (model1 == null)
            {
                model.message = "没有此房型";
                return PartialView(model);
            }
            model.RoomTypeCode = model1.str_TypeCode;
            model.RoomTypeName = model1.str_TypeName;
            ///姓名，手机
            BLL.VipInfoB bll2 = new BLL.VipInfoB();
            VipInfoM model2 = new VipInfoM();
            model2 = bll2.GetOne(cardM.Ing_Fk_VipID);

            if (model2 == null || !model2.Ing_Fk_CustID.HasValue)
            {
                model.message = "不存在此会员信息";
                return PartialView(model);
            }

            BLL.CustB bll3 = new BLL.CustB();
            CustM model3 = new CustM();
            model3 = bll3.GetOne(model2.Ing_Fk_CustID.Value);
            if (model3 == null)
            {
                model.message = "不存在此会员信息-档案";
                return PartialView(model);
            }
            model.str_CusName = model3.str_CusName;
            model.str_mobile = model3.str_mobile;
            model.Ing_RoomNum = 1;

            ///会员房价码
            BLL.MasterB masB = new BLL.MasterB();
            RoomRateDefaultM m2 = masB.GetRoomRateDefault(model.Ing_StoreID, dtarr, model.lngvipcardid);

            string viproomrate = string.Empty;
            if (m2 != null)
            {
                viproomrate = m2.str_RateID;
            }
            model.VipRateCode = viproomrate;
            ///可用数量
            List<RoomCanUseM> cmList = masB.GetRoomCanUse(model.Ing_StoreID, model.dtArr, model.dtDep, model.RoomTypeCode);
            if (cmList == null || cmList.Count == 0)
            {
                model.message = "客房已满";
                return PartialView(model);
            }
            if (cmList.Where(a => a.minnum > 0).Count() != (model.dtDep.Date - model.dtArr.Date).Days)
            {
                model.message = "客房已满";
                return PartialView(model);
            }
            RoomCanUseM cm = cmList.FirstOrDefault();
            model.CanUserNum = cm.kf;

            ///循环获取房价(每天房价可能不同)
            RoomRateM rm = new RoomRateM();
            for (int i = 0; i < model.day; i++)
            {
                DateTime dayTime = model.dtArr.AddDays(i);
                rm = masB.GetRoomRate(model.Ing_StoreID, dayTime, model.RoomTypeCode, viproomrate, model.lngvipcardid);
                if (rm != null)
                {
                    model.price = rm.price;
                }
                if (i == 0) //房价（主单上面房价显示第一天的）
                {
                    if (rm != null)
                    {
                        model.dec_ActualRate = rm.price;

                    }
                    //if (model.dec_FirstLivePrice > 0)
                    //{
                    //    model.dec_ActualRate = model.dec_FirstLivePrice;
                    //}
                }
                //if (model.dec_FirstLivePrice > 0 && i == 0)//如果有首住优惠，第一天的第一个房间的房价，按照首住优惠
                //{
                //    model.price = model.dec_FirstLivePrice + (model.Ing_RoomNum - 1) * model.price;

                //}
                //else
                //{
                    model.price = model.Ing_RoomNum * model.price;
                //}
                model.totalprice += model.price;

            }

            // LogHelper.LogInfo(string.Format("{0}会员,总价格:{1},门市价{2}",openid,model.totalprice,model.dec_ActualRate));
            return PartialView(model);
        }
        /// <summary>
        /// 钟点房预订页面
        /// </summary>
        /// <returns></returns>
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult WriteHourOrder()
        {
            string rawurl = Request.RawUrl;
            rawurl = HttpUtility.UrlEncode(rawurl);
            string strarr = Request.QueryString["strarr"];
            string strtime = Request.QueryString["strtime"];

            DateTime dtarr = DateTime.Now;
            DateTime.TryParse(string.Format("{0} {1}:00", strarr, strtime), out dtarr);



            int Ing_StoreID = 0;
            int.TryParse(Request.QueryString["storeid"], out Ing_StoreID);

            int roomtypeid = 0;
            int.TryParse(Request.QueryString["roomtypeid"], out roomtypeid);


            string openid = AuthorizationManager.GetOpenID;


            WriteOrderM model = new WriteOrderM();



            model.openid = openid;
            model.dtArr = dtarr;
            model.Ing_StoreID = Ing_StoreID;
            model.backurl = "/hotel";
            model.rawurl = rawurl;
            model.lngvipcardid = 1;

            if (Ing_StoreID == 0)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }

            BLL.StoreInfoB storeinfo1B = new BLL.StoreInfoB();
            StoreInfoM infoM = new StoreInfoM();
            infoM = storeinfo1B.GetOne(model.Ing_StoreID);
            if (infoM == null)
            {
                model.message = "门店信息不存在";
                return PartialView(model);
            }
            model.str_StoreName = infoM.str_StoreName;
            model.str_StoreFullName = infoM.str_StoreFullName;

            model.backurl = "/Hotel/HourIndex?strarr=" + strarr + "&strtime=" + strtime + "&storeid=" + Ing_StoreID;

            model.lngvipcardid = 0;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid, Ing_StoreID);
            if (cardM == null)
            {
                model.message = "请先绑定，再进行预订操作";
                return PartialView(model);
            }
            model.lngvipcardid = cardM.Ing_Pk_VipCardId;


            ///房型
            BLL.RoomTypeB bll1 = new BLL.RoomTypeB();
            RoomTypeM model1 = new RoomTypeM();
            model1 = bll1.GetOne(roomtypeid);


            if (model1 == null)
            {
                model.message = "没有此房型";
                return PartialView(model);
            }

            if (model1.Ing_ShowInHourWechat == 0)
            {
                model.message = "该房型不支持钟点房预订";
                return PartialView(model);
            }

            model.RoomTypeCode = model1.str_TypeCode;
            model.RoomTypeName = model1.str_TypeName;



            ///姓名，手机
            BLL.VipInfoB bll2 = new BLL.VipInfoB();
            VipInfoM model2 = new VipInfoM();
            model2 = bll2.GetOne(cardM.Ing_Fk_VipID);

            if (model2 == null || !model2.Ing_Fk_CustID.HasValue)
            {
                model.message = "不存在此会员信息";
                return PartialView(model);
            }

            BLL.CustB bll3 = new BLL.CustB();
            CustM model3 = new CustM();
            model3 = bll3.GetOne(model2.Ing_Fk_CustID.Value);
            if (model3 == null)
            {
                model.message = "不存在此会员信息-档案";
                return PartialView(model);
            }
            model.str_CusName = model3.str_CusName;
            model.str_mobile = model3.str_mobile;
            model.Ing_RoomNum = 1;

            ///会员房价码
            BLL.MasterB masB = new BLL.MasterB();
            RoomRateDefaultM m2 = masB.GetRoomRateDefault(model.Ing_StoreID, dtarr, model.lngvipcardid);

            string viproomrate = string.Empty;
            if (m2 != null)
            {
                viproomrate = m2.str_RateID;
            }
            model.VipRateCode = viproomrate;



            BLL.TimeRoomRuleB ruleB = new BLL.TimeRoomRuleB();
            List<TimeRoomRuleM> listrules = ruleB.GetRule(model.Ing_StoreID, model.RoomTypeCode);
            if (listrules == null || listrules.Count == 0)
            {
                model.message = "该房型没有对应的钟点房方案，不能预订";
                return PartialView(model);
            }
            ///先找  会员类型匹配的
            TimeRoomRuleM ruleM = listrules.Where(x => x.Ing_VipCardType == cardM.Ing_VipCardType).OrderBy(x => x.Prior).FirstOrDefault();
            if (ruleM == null)
            {
                ///再找  会员类型是全部的
                ruleM = listrules.Where(x => x.Ing_VipCardType == 0).OrderBy(x => x.Prior).FirstOrDefault();
            }

            if (ruleM == null)
            {
                model.message = "该房型没有对应的钟点房方案，不能预订";
                return PartialView(model);
            }

            DateTime dtdep = dtarr.AddHours(ruleM.Ing_StepHoure);
            model.dtDep = dtdep;
            model.HourID = ruleM.Ing_PID;

            model.price = ruleM.dec_StepRate;

            BLL.RoomNumB numB = new BLL.RoomNumB();
            int lngroomnum = numB.GetRoomNum(model.Ing_StoreID, model.RoomTypeCode);

            ///有20%的限制
            if (lngroomnum < 5)
            {
                model.message = "客房已满";
                return PartialView(model);
            }
            lngroomnum = lngroomnum / 5;

            ///可用数量
            RoomCanUseM cm = new RoomCanUseM();
            cm = masB.GetRoomCanUse(model.Ing_StoreID, model.dtArr, model.dtDep, model.RoomTypeCode).FirstOrDefault();
            if (cm == null || cm.minnum == 0)
            {
                model.message = "客房已满";
                return PartialView(model);
            }
            if (cm.minnum < lngroomnum)
            {
                model.message = "客房已满";
                return PartialView(model);
            }

            model.CanUserNum = cm.minnum;
            model.totalprice = model.price * model.Ing_RoomNum;

            return PartialView(model);

        }
        /// <summary>
        /// 保存预订
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveWriteOrder(WriteOrderM model)
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
            BLL.MasterB bll = new BLL.MasterB();
            json.Data = bll.SaveOrder(model);

            return json;

        }
        public ActionResult Complete(int id)
        {
            OrderSuccessM model = new OrderSuccessM();
            model.MasterID = id;

            BLL.MasterB bll1 = new BLL.MasterB();
            MasterM m1 = bll1.GetOne(id);

            if (m1 == null)
            {
                model.message = "此订单不存在";
                return PartialView(model);
            }
            if (m1.dt_ResDep.HasValue)
            {
                model.dt_Res = m1.dt_ResDep.Value;
            }
            else
            {
                model.dt_Res = DateTime.Now.Date.AddHours(19);
            }

            model.dec_ActualRate = m1.dec_ActualRate ?? 0;
            
            BLL.StoreInfoB bll2 = new BLL.StoreInfoB();
            StoreInfoM m2 = bll2.GetOne(m1.Ing_StoreID ?? 0);
            if (m2 == null)
            {
                model.message = "此订单对应的门店信息有误";
                return PartialView(model);
            }
            model.Ing_StoreID = m1.Ing_StoreID.Value;
            model.str_StoreFullName = m2.str_StoreFullName;
            model.str_StoreName = m2.str_StoreName;

            BLL.RoomTypeB bll3 = new BLL.RoomTypeB();
            RoomTypeM m3 = bll3.GetRoomType(m1.Ing_StoreID ?? 0, m1.str_RoomType);
            if (m3 == null)
            {
                model.message = "此订单对应的房型信息有误";
                return PartialView(model);
            }
            model.RoomTypeName = m3.str_TypeName;
            if (!string.IsNullOrEmpty(m1.str_InterType) && m1.str_InterType.ToUpper().Equals("HOUR"))
            {
                return PartialView(model);
            }

            //判断能否使用房费变价优惠券
            BLL.CouponDetailsB detailB = new BLL.CouponDetailsB();
            if (!detailB.CheckDayUser(m1.Ing_Pk_MasterID))
            {
                return PartialView(model);
            }

            //查出有效的优惠券
            model.CouponPirceList = detailB.GetCouponByMasterID(m1.Ing_Pk_MasterID, 1);

            return PartialView(model);
        }
        /// <summary>
        /// 获取总的评论
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetComment(AspNetPageM model)
        {
            JsonResult jr = new JsonResult();
            List<CommentsM> list = new List<CommentsM>();
            try
            {
                int storeid = model.Ing_StoreID;
                BLL.CommentsB bll = new BLL.CommentsB();
                list = bll.GetGoodRecordByStoreID(storeid);
                int totalNum = list.Count();
                int pageNum = model.CurrentPage;
                int rowCount = model.PageSize;
                list = list.Skip((pageNum - 1) * rowCount).Take(rowCount).ToList();
                jr.Data = new { total = totalNum, rows = list };
            }
            catch (Exception ex)
            {
                jr.Data = new { rows = list };
                LogHelper.LogInfo(ex.Message);
            }
            return jr;
        }
    }
}