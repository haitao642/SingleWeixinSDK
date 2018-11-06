using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_CouponType
    /// </summary>
    public class CouponTypeM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_CouponTypeID {get;set;}

        ///<summary>
        ///总的金额
        /// </summary>
        public decimal? dec_Amount {get;set;}

        ///<summary>
        ///优惠券金额，10|20 表示生成一张10， 一张20的，  如果空，则表示一张整的
        /// </summary>
        public string str_AmountType {get;set;}

        ///<summary>
        ///截止时间
        /// </summary>
        public DateTime? dt_CanUseTime {get;set;}

        ///<summary>
        ///可以使用次数
        /// </summary>
        public int? Ing_CanUseNum {get;set;}

        ///<summary>
        ///活动代码
        /// </summary>
        public string str_SendType {get;set;}

        ///<summary>
        ///活动名称
        /// </summary>
        public string str_PaperName {get;set;}

        ///<summary>
        ///状态  1：有效   0：无效
        /// </summary>
        public int? Ing_Sta {get;set;}

        ///<summary>
        ///发起门店
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///短信抬头
        /// </summary>
        public string str_SendContent {get;set;}

        ///<summary>
        ///门店使用范围
        /// </summary>
        public string str_UseArea {get;set;}

        ///<summary>
        ///是否可以补发  1：是   0：否
        /// </summary>
        public int? Ing_IsReSend {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_Remark {get;set;}

        ///<summary>
        ///优惠券编码前缀
        /// </summary>
        public string str_Prefix {get;set;}

        ///<summary>
        ///开始号码
        /// </summary>
        public int? Ing_StartNo {get;set;}

        ///<summary>
        ///结束号码
        /// </summary>
        public int? Ing_EndNo {get;set;}

        ///<summary>
        ///折扣率
        /// </summary>
        public decimal? dec_Discount {get;set;}

        ///<summary>
        ///销售金额
        /// </summary>
        public decimal? dec_SalePrice {get;set;}

        ///<summary>
        ///可以重复使用次数
        /// </summary>
        public int? Ing_RepeatUse {get;set;}

        ///<summary>
        ///门店是否可以销售
        /// </summary>
        public int? Ing_CanSale {get;set;}

        ///<summary>
        ///开始时间
        /// </summary>
        public DateTime? dt_CanUseCTime {get;set;}

        ///<summary>
        ///pccode
        /// </summary>
        public string str_Pccode {get;set;}

        ///<summary>
        ///使用规则
        /// </summary>
        public string str_rule {get;set;}


        /// <summary>
        /// 多少积分才能购买当前优惠券
        /// </summary>
        public int Ing_IntegralBuy { get; set; }


        /// <summary>
        /// 多少人民币才能购买
        /// </summary>
        public decimal dec_CashBuy { get; set; }
    }

    /// <summary>
    /// 生成优惠券的参数
    /// </summary>
    public class CreateCoupponM
    {
        /// <summary>
        /// 会员卡id
        /// </summary>
        public int vipCardInfoId { get; set; }

        /// <summary>
        /// 优惠券id  (如果为0是赠送优惠券)
        /// </summary>
        public int coupontypeId { get; set; }

        /// <summary>
        /// 优惠券有效期
        /// </summary>
        public int ingmonth { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 活动代码
        /// </summary>
        public string str_Activity { get; set; }
    }

    /// <summary>
    /// 微信积分兑换抵用券
    /// </summary>
    public class WechatCouponM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_CouponTypeID { get; set; }

        /// <summary>
        /// 活动
        /// </summary>
        public CouponTypeM typeM { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int VipcardID { get; set; }

        /// <summary>
        /// 兑换的张数
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 最多可以换几张
        /// </summary>
        public int TotalNumber { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string message { get; set; }
    }
}