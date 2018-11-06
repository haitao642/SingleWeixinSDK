using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 
    /// </summary>
    public class JSSDKModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string appId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public long timestamp { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string nonceStr { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string jsapiTicket { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string signature { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string shareUrl { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string shareImg { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string string1 { set; get; }
    }

    /// <summary>
    /// 微信支付类
    /// </summary>
    public class JSPayModel
    {
        /// <summary>
        /// appID
        /// </summary>
        public string appId { set; get; }

        /// <summary>
        /// 时间
        /// </summary>
        public long timestamp { set; get; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonceStr { set; get; }

        /// <summary>
        /// jsapiTicket
        /// </summary>
        public string jsapiTicket { set; get; }

        /// <summary>
        /// 签名
        /// </summary>
        public string signature { set; get; }

        /// <summary>
        /// string1
        /// </summary>
        public string string1 { set; get; }

        /// <summary>
        /// userAgent
        /// </summary>
        public string userAgent { set; get; }

        /// <summary>
        /// 微信版本
        /// </summary>
        public string userVersion { set; get; }

        /// <summary>
        /// 商品简要描述
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// attach
        /// </summary>
        public string attach { get; set; }

        /// <summary>
        /// product_id
        /// </summary>
        public string product_id { get; set; }

        /// <summary>
        /// goods_tag
        /// </summary>
        public string goods_tag { get; set; }

        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal dec_money { get; set; }

        /// <summary>
        /// 精确到分的金额
        /// </summary>
        public int total_fee
        {
            get
            {
                decimal rev = dec_money * 100;
                if (debug == 1)
                {
                    rev = 1;
                }
                return (int)rev;
            }
        }

        /// <summary>
        /// 分类：  0：预订支付    1:会员储值
        /// </summary>
        public int Ing_type { get; set; }

        /// <summary>
        /// 对应的主键id,  如果是预订支付的，就是主单id
        /// </summary>
        public int Ing_pkid { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 是不是测试
        /// </summary>
        public int debug { get; set; }

    }


    /// <summary>
    /// 房费支付类
    /// </summary>
    public class JSPayMasterM : JSPayModel
    {
        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 房型
        /// </summary>
        public string str_RoomType { get; set; }

        /// <summary>
        /// 来期
        /// </summary>
        public DateTime dt_Arr { get; set; }


        /// <summary>
        /// 离期
        /// </summary>
        public DateTime dt_Dep { get; set; }

        /// <summary>
        /// 房晚
        /// </summary>
        public int day
        {
            get
            {
                int days=dt_Dep.Date.Subtract(dt_Arr.Date).Days;
                //如果是六点以前入住的，房晚加1
                if (dt_Arr.ToString("HHmm").Equals("0600"))
                {
                    days += 1;
                }
                return days;
            }
        }

        /// <summary>
        /// 最多能用几张优惠券
        /// </summary>
        public int couponMax
        {
            get;
            set;
        }

        /// <summary>
        /// 有效优惠券列表
        /// </summary>
        public List<ResultCouponM> listcoupon { get; set; }

        /// <summary>
        /// 有效优惠券的张数
        /// </summary>
        public int couponNum { get {
            if (listcoupon == null) return 0;
            return listcoupon.Count;
        } }

        ///<summary>
        ///会员卡ID
        /// </summary>
        public int Ing_Pk_VipCardId { get; set; }


        ///<summary>
        ///可用储值余额
        /// </summary>
        public decimal dec_SurplusMoney { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 储值支付密码
        /// </summary>
        public string str_paypassword { get;set; }


        ///<summary>
        ///最大可用积分
        /// </summary>
        public int Ing_SurplusIntegral { get; set; }


        /// <summary>
        /// 积分兑换的时候，这个房型需要多少积分
        /// </summary>
        public int Ing_NeedIntegral { get; set; }

        /// <summary>
        /// 积分兑换的错误信息
        /// </summary>
        public string str_IntegralMessage { get; set; }

        /// <summary>
        /// 积分兑换的状态  0： 可以积分兑换
        /// </summary>
        public int Ing_IntegralExchangeSta { get; set; }

        /// <summary>
        /// 积分兑换的房晚
        /// </summary>
        public int Ing_IntegralExchangeNight { get; set; }

        /// <summary>
        /// 积分兑换总共花了多少积分
        /// </summary>
        public int Ing_IntegralExchangeTotal { get; set; }

        /// <summary>
        /// 积分兑换的金额
        /// </summary>
        public decimal dec_IntegralExchangeTotalMoney { get; set; }


        /// <summary>
        /// 会员首住的房价
        /// </summary>
        public decimal dec_FirstLivePrice { get; set; }

        /// <summary>
        /// 是不事钟点房
        /// </summary>
        public bool isHour { get; set; }

        /// <summary>
        /// 微信钱包金额
        /// </summary>
        public decimal dec_WechatPrice { get; set; }
    }


    /// <summary>
    /// 微信储值充值类
    /// </summary>
    public class JSPayChargeMonM : JSPayModel
    {
        /// <summary>
        /// 选择了哪种充值类型
        /// </summary>
        public int Ing_typeID { get; set; }
        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string Str_StoreName { get; set; }

        /// <summary>
        /// 充值类型列表
        /// </summary>
        public List<WxChargeMonM> list { get; set; }
    }


    /// <summary>
    /// 支付成功后，接收url中的参数类
    /// </summary>
    public class JSPayNOticeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string appId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string bank_type { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int cash_fee { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string fee_type { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string is_subscribe { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string mch_id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string nonce_str { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string openid { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string out_trade_no { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string result_code { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string return_code { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string sign { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string time_end { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int total_fee { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string trade_type { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string transaction_id { set; get; }
    }
}
