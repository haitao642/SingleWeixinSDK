using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipCard_ChargeMonRule
    /// </summary>
    public class VipCardChargeMonRuleM
    {
        ///<summary>
        ///Ing_ChargeMonId
        /// </summary>
        public int Ing_ChargeMonId {get;set;}

        ///<summary>
        ///会员卡类型
        /// </summary>
        public int? Ing_CardType {get;set;}

        ///<summary>
        ///起效日期
        /// </summary>
        public DateTime? dt_BeginTime {get;set;}

        ///<summary>
        ///失效日期
        /// </summary>
        public DateTime? dt_EndTime {get;set;}

        ///<summary>
        ///最低充值金额，规则是大于等于最低充值金额
        /// </summary>
        public decimal? dec_MinMon {get;set;}

        ///<summary>
        ///最高充值金额，规则是小于最高充值金额
        /// </summary>
        public decimal? dec_MaxMon {get;set;}

        ///<summary>
        ///赠送值
        /// </summary>
        public decimal? dec_GiveMon {get;set;}

        ///<summary>
        ///充值方法 3为积分充值赠送积分比例, 5为储蓄充值赠送金额比例
        /// </summary>
        public int? Ing_ChargeType {get;set;}

        ///<summary>
        ///赠送方式，1表示按固定值赠送，2表示按比率赠送
        /// </summary>
        public int? SendType {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}



    }
}