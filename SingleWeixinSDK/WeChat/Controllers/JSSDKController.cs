using BLL;
using BLL.Wechat;
using Deepleo.Weixin.SDK.Helpers;
using Deepleo.Weixin.SDK.JSSDK;
using Model;
using Model.RoomCenter;
using Model.WeiXin;
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
    public class JSSDKController : Controller
    {
        // GET: JSSDK
        public ActionResult Index()
        {
            return View();
        }
        [WeixinOAuthAuthorizeAttribute]
        public ActionResult PayMaster()
        {
            int storeid = 0;
            int.TryParse(Request.QueryString["storeid"], out storeid);
            string redirect_url = "/WeChatLogin/index?storeid=" + storeid;
            string openid = AuthorizationManager.GetOpenID;
            Model.VipCardInfoM cardM = new Model.VipCardInfoM();
            BLL.VipCardInfoB cardB = new BLL.VipCardInfoB();
            cardM = cardB.GetVipCardByStoreid(openid, storeid);
            if (cardM == null)
            {
                ///跳到绑定界面
                return new RedirectResult(redirect_url);
            }
            int id = 0;
            int.TryParse(Request.QueryString["masterid"], out id);
            ViewBag.rawurl = "/MyAccount/Order?storeid=" + storeid;
            JSPayMasterM model = new JSPayMasterM();
            //model.debug = 1;
            model.Ing_StoreID = storeid;
            model.dec_SurplusMoney = cardM.dec_SurplusMoney;
            model.Ing_Pk_VipCardId = cardM.Ing_Pk_VipCardId;
            model.str_paypassword = cardM.str_paypassword;
            model.dec_WechatPrice = cardM.dec_WechatPrice;
            BLL.Wechat.WeChatConfigB bllconfig = new WeChatConfigB();
            WeChatConfigM wechatconfig = bllconfig.GetWeixinConfig(storeid);
            var appId = wechatconfig.AppID;
            var nonceStr = Util.CreateNonce_str();
            var timestamp = Util.CreateTimestamp();
            var domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
            var url = domain + Request.Url.PathAndQuery;
            Boolean openJSSDK = false;
            if (wechatconfig.OpenJSSDK == 1)
            {
                openJSSDK = true;
            }
            TokenHelper tokenHelper = new TokenHelper(6000, wechatconfig.AppID, wechatconfig.AppSecret, openJSSDK);
            var jsTickect = tokenHelper.GetJSTickect(appId);
            var string1 = "";
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

            model.appId = appId;
            model.nonceStr = nonceStr;
            model.timestamp = timestamp;
            model.jsapiTicket = jsTickect;
            model.string1 = string1;
            model.signature = signature;
            model.userAgent = userAgent;
            model.userVersion = userVersion;
            model.openid = openid;
            model.Ing_type = 0;
            model.Ing_pkid = id;
            //model.debug = Public.ConfigValue.WxPayDebug;

            int IngVersion = -1;
            int.TryParse(userVersion, out IngVersion);
            //if (IngVersion <= 0)
            //{
            //    model.message = "抱歉，必须使用微信客户端打开才能使用微信支付。";
            //    return PartialView(model);
            //}

            //if (IngVersion < 5)
            //{
            //    model.message = "抱歉，您的微信版本不支持微信支付。";
            //    return PartialView(model);
            //}

            BLL.MasterB bll = new BLL.MasterB();
            MasterM masM = new MasterM();
            masM = bll.GetOne(id);

            if (masM == null)
            {
                model.message = "订单不存在";
                return PartialView(model);
            }

            //判断是否享受了首住优惠sue:测试,当前主单id:951690,首住主单id:951690,当前房型:DR,当前房型价格:88
            RoomTypeB roomB = new RoomTypeB();
            RoomTypeM roomM = roomB.GetRoomType(masM.Ing_StoreID ?? 0, masM.str_RoomType);
            Public.LogHelper.LogInfo(string.Format("sue:测试,当前主单id:{0},首住主单id:{1},当前房型:{2},当前房型价格:{3},会员卡id:{4}",
                       id, cardM.Ing_FirstMaster ?? 0, masM.str_RoomType, roomM.dec_FirstLivePrice ?? 0, masM.Ing_Fk_VipCardID));

            //if ((!cardM.Ing_FirstMaster.HasValue || cardM.Ing_FirstMaster.Value == 0 || cardM.Ing_FirstMaster.Value == masM.Ing_Pk_MasterID)
            //   && roomM != null && roomM.dec_FirstLivePrice.HasValue &&
            //    roomM.dec_FirstLivePrice.Value > 0 && (((masM.dt_ArrDate ?? DateTime.Now).Date - DateTime.Now.Date).Days == 0 && "I".Equals(masM.str_Sta) || "R".Equals(masM.str_Sta))
            //     && roomM.dec_FirstLivePrice == masM.dec_ActualRate)
            //{
            //    isFirst = true;//502484,首住主单id:502484,当前房型:DBR,当前房型价格:88
            //    Public.LogHelper.LogInfo(string.Format("主单:{0},享用首住优惠成功", masM.Ing_Pk_MasterID));
            //}
            //if (!isFirst) //如果没有首住优惠,判断是否使用了优选88
            //{
            //    CouponDetailsB coupondB = new CouponDetailsB();
            //    CouponDetailsM coupondM = coupondB.GetCouponDetail(id);
            //    if (coupondM != null && coupondM.dt_useTime.HasValue &&
            //        (coupondM.dt_useTime.Value.Date - DateTime.Now.Date).Days == 0) //说明享受了优选88
            //    {
            //        isFirst = true;
            //    }

            //}


            //if (isFirst) //如果享受了首住优惠,就不能用储值金,积分兑换,抵扣券
            //{
            //    model.dec_SurplusMoney = 0;

            //}

            decimal tempPrice = 0;//临时价
            model.dec_money = 0;//总房价
            MasterB masB = new MasterB();
            //房晚
            int dayNum = masM.dt_DepDate.Value.Date.Subtract(masM.dt_ArrDate.Value.Date).Days; // dtDep.Date.Subtract(dtArr.Date).Days;
            if (dayNum == 0 && !string.IsNullOrEmpty(masM.str_InterType) && masM.str_InterType.ToUpper().Equals("HOUR"))
            {
                model.dec_money = masM.dec_ActualRate ?? 0;
            }
            for (int i = 0; i < dayNum; i++)
            {
                // Public.LogHelper.LogInfo(string.Format("{0}|{1}|{2}|{3}|{4}", masM.Ing_StoreID, masM.dt_ArrDate.Value.AddDays(i), masM.str_RoomType, masM.str_RateID, masM.Ing_Fk_VipCardID ?? 0));
                RoomRateM rm2 = masB.GetRoomRate(masM.Ing_StoreID.Value, masM.dt_ArrDate.Value.AddDays(i), masM.str_RoomType, masM.str_RateID, masM.Ing_Fk_VipCardID ?? 0);
                if (rm2 != null)
                {

                    tempPrice = rm2.price;
                }
                if (i == 0)
                {
                    model.dec_money = masM.dec_ActualRate ?? 0 + ((masM.Ing_RoomNum ?? 0) - 1) * tempPrice;

                }
                else
                {
                    model.dec_money += tempPrice * masM.Ing_RoomNum ?? 0;
                }
            }

            if (masM.dec_credit.HasValue)
            {
                model.dec_money -= masM.dec_credit.Value;
            }
            if (model.dec_money < 0)
            {
                model.dec_money = 0;
            }


            ///查看续住的金额
            BLL.ContinueInterB conB = new BLL.ContinueInterB();
            ContinueInterM conM = new ContinueInterM();
            conM = conB.GetRecord(id, 0);
            bool IsContinue = false;
            ///没有续住记录
            if (conM == null)
            {
                goto common;
            }
            ///已经付款
            if (conM.Ing_PayType == 1)
            {
                goto common;
            }
            ///没有付款金额
            if (!conM.dec_price.HasValue)
            {
                goto common;
            }
            if (conM.dec_price.Value == 0)
            {
                goto common;
            }

            IsContinue = true;
            model.dec_money = conM.dec_price.Value;
            //model.dec_FirstLivePrice = 0;


            common:
            if (model.dec_money == 0)
            {
                model.message = "金额是0，不需支付";
                return PartialView(model);
            }

            bool isHour = false;
            /// 微信预订，半个小时内可以支付
            if (masM.str_InterType.ToString().ToUpper().Trim().Equals("HOUR"))
            {
                isHour = true;
                if (!masM.str_Channel.ToUpper().Trim().Equals("WEC"))
                {
                    model.message = "只有在微信上预订的钟点房才能使用在线支付";
                    return PartialView(model);
                }

                if (!masM.str_Sta.ToUpper().Equals("X"))
                {
                    model.message = "此状态的钟点房已经不允许在线支付";
                    return PartialView(model);
                }

                if (!masM.dt_restime.HasValue)
                {
                    model.message = "没有预订时间的钟点房已经不允许在线支付";
                    return PartialView(model);
                }

                if (masM.dt_restime.Value.AddMinutes(30) < DateTime.Now)
                {
                    model.message = "超过半小时的钟点房已经不允许在线支付";
                    return PartialView(model);
                }
            }
            else
            {
                bool VerifySta = false;
                if (masM.str_Sta.ToUpper().Equals("I"))
                {
                    if (IsContinue)
                    {
                        VerifySta = true;
                    }
                }
                else if (masM.str_Sta.ToUpper().Equals("R"))
                {
                    VerifySta = true;
                }
                else if (masM.str_Sta.ToUpper().Equals("X"))
                {
                    VerifySta = true;
                }
                if (!VerifySta)
                {
                    model.message = "此订单不允许在线支付";
                    return PartialView(model);
                }
            }

            model.isHour = isHour;



            if (masM.Ing_Fk_VipCardID != cardM.Ing_Pk_VipCardId)
            {
                model.message = "只有本人预订的订单才能在线支付";
                return PartialView(model);
            }



            model.dt_Arr = masM.dt_ArrDate ?? DateTime.Now;
            model.dt_Dep = masM.dt_DepDate ?? model.dt_Arr.AddDays(1);

            ///计算最多使用优惠券的数量
            model.couponMax = model.day;
            if (IsContinue)
            {
                model.couponMax = conM.Ing_days ?? 0;
            }


            //BLL.WxPayResultB bll1 = new BLL.WxPayResultB();
            //WxPayResultM resM = new WxPayResultM();
            //resM = bll1.GetMoelBypid(model.Ing_type, model.Ing_pkid);

            //if (resM != null)
            //{
            //    model.message = "该订单已经支付过，无需重新支付";
            //    return PartialView(model);
            //}

            BLL.StoreInfoB bll2 = new BLL.StoreInfoB();
            StoreInfoM infoM = bll2.GetOne(masM.Ing_StoreID ?? 0);
            if (infoM == null)
            {
                model.message = "该订单所在的门店信息错误，请稍后再试";
                return PartialView(model);
            }

            model.Ing_StoreID = infoM.Ing_StoreID;
            model.str_StoreName = infoM.str_StoreName;

            BLL.RoomTypeB bll3 = new BLL.RoomTypeB();
            RoomTypeM typeM = bll3.GetRoomType(masM.Ing_StoreID ?? 0, masM.str_RoomType);
            if (typeM == null)
            {
                model.message = "该订单对应的房型信息错误，请稍后再试";
                return PartialView(model);
            }
            model.str_RoomType = typeM.str_TypeName;

            model.body = string.Format("{0}预订 {1} {2}", model.str_StoreName, model.str_RoomType, isHour ? "钟点房" : "");
            model.detail = string.Format("入住：{0}  离期:{1}", model.dt_Arr.ToString("yyyy-MM-dd"), model.dt_Dep.ToString("yyyy-MM-dd"));

            ///如果是钟点房，只有  储值支付和微信支付
            if (isHour)
            {
                goto success;
            }
            BLL.CouponDetailsB bll4 = new BLL.CouponDetailsB();
            model.listcoupon = bll4.GetCouponByMasterID(id, 0);//获取优惠券
            if (model.listcoupon == null)
            {
                model.listcoupon = new List<ResultCouponM>();
            }
            //GetCouponByMasterID
            //if (isFirst)
            //{
            //    model.listcoupon = new List<ResultCouponM>();
            //    model.str_IntegralMessage = "已享受首住优惠/享受优选88,所以不支持,积分兑换,优惠券支付,储值支付";
            //    model.Ing_IntegralExchangeSta = 1;
            //    goto success;
            //}
            if (model.listcoupon != null && model.listcoupon.Count > 0) //筛选符合该房型的优惠券
            {


            }

            ///积分兑换的相关信息
            model.str_IntegralMessage = string.Empty;
            model.Ing_SurplusIntegral = cardM.Ing_SurplusIntegral;

            model.Ing_NeedIntegral = typeM.Ing_NeedIntegral;
            if (model.Ing_NeedIntegral == 0)
            {
                model.str_IntegralMessage = "该房型不支持积分兑换";
                model.Ing_IntegralExchangeSta = 1;
                goto success;
            }

            model.Ing_IntegralExchangeNight = Math.Min(model.Ing_SurplusIntegral / model.Ing_NeedIntegral, model.day);

            if (IsContinue) //如果是续住离期-当前时间
            {
                model.Ing_IntegralExchangeNight = Math.Min(model.Ing_SurplusIntegral / model.Ing_NeedIntegral, model.dt_Dep.Date.Subtract(DateTime.Now.Date).Days);
            }


            if (model.Ing_IntegralExchangeNight == 0)
            {
                model.str_IntegralMessage = "你的积分不足";
                model.Ing_IntegralExchangeSta = 1;
                goto success;
            }
            model.Ing_IntegralExchangeTotal = model.Ing_NeedIntegral * model.Ing_IntegralExchangeNight;


            ///取房价
            RoomRateM rm = new RoomRateM();
            rm = bll.GetRoomRate(model.Ing_StoreID, model.dt_Arr, masM.str_RoomType, masM.str_RateID, model.Ing_Pk_VipCardId);
            if (rm == null)
            {
                model.str_IntegralMessage = "房价异常，不能使用积分兑换";
                model.Ing_IntegralExchangeSta = 1;
                goto success;
            }

            model.dec_IntegralExchangeTotalMoney = model.Ing_IntegralExchangeNight * rm.price;
            if (model.dec_IntegralExchangeTotalMoney > model.dec_money)
            {
                model.dec_IntegralExchangeTotalMoney = model.dec_money;
            }

            success:
            if (!string.IsNullOrEmpty(model.message))
            {
                Public.LogHelper.LogInfo("错误消息为:" + model.message);
            }
            return PartialView(model);
        }
    }
}