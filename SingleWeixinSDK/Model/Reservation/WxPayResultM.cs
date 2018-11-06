using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_WxPayResult
    /// </summary>
    public class WxPayResultM
    {
        ///<summary>
        ///自增ID
        /// </summary>
        public int Ing_ResultID {get;set;}

        ///<summary>
        ///分类：  0：预订支付    1:会员储值
        /// </summary>
        public int Ing_type {get;set;}

        ///<summary>
        ///对应的主键id,  如果是预订支付的，就是主单id
        /// </summary>s
        public int Ing_pkid {get;set;}

        ///<summary>
        ///备用主键id1
        /// </summary>
        public int Ing_pkid1 {get;set;}

        ///<summary>
        ///备用主键id2
        /// </summary>
        public int? Ing_pkid2 {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_Create {get;set;}

        ///<summary>
        ///商户订单号
        /// </summary>
        public string out_trade_no {get;set;}

        ///<summary>
        ///微信支付单号
        /// </summary>
        public string transaction_id {get;set;}

        ///<summary>
        ///付款时间
        /// </summary>
        public DateTime? dt_Pay {get;set;}

        ///<summary>
        ///最后操作时间
        /// </summary>
        public DateTime? dt_Modify {get;set;}

        ///<summary>
        ///金额
        /// </summary>
        public decimal dec_fee {get;set;}

        ///<summary>
        ///状态   0：未支付或者支付失败    1：支付成功  2:这笔支付撤销到储值余额里去了
        /// </summary>
        public int Ing_Sta {get;set;}

        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }


        /// <summary>
        /// 优惠券id  以逗号分隔的字符串
        /// </summary>
        public string PagerIDs { get; set; }

        /// <summary>
        /// 微信金额
        /// </summary>
        public decimal dec_WechatPrice { get; set; }

        ///<summary>
        ///储值余额
        /// </summary>
        public decimal dec_SurplusMoney { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string str_Token { get; set; }
    }
}