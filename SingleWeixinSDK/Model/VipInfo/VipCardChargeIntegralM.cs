using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipCard_ChargeIntegral
    /// </summary>
    public class VipCardChargeIntegralM
    {
        ///<summary>
        ///Ing_pk_CintID
        /// </summary>
        public int Ing_pk_CintID {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///Ing_Fk_VipCardID
        /// </summary>
        public int? Ing_Fk_VipCardID {get;set;}

        ///<summary>
        ///卡号
        /// </summary>
        public string str_VipCard {get;set;}

        ///<summary>
        ///充值编号 用于和应收帐关联
        /// </summary>
        public string str_Pk_Accnt {get;set;}

        ///<summary>
        ///消费积分
        /// </summary>
        public int Ing_ChargeIntegral {get;set;}

        ///<summary>
        ///充值积分
        /// </summary>
        public int Ing_CreditIntegral {get;set;}

        ///<summary>
        ///本期余额
        /// </summary>
        public int? Ing_Balance {get;set;}

        ///<summary>
        ///充值理由
        /// </summary>
        public int? Ing_ChargeResone {get;set;}

        ///<summary>
        ///充值类型
        /// </summary>
        public int? Ing_ChargeType {get;set;}

        ///<summary>
        ///是否有效 1为有效 0 为无效
        /// </summary>
        public int? Ing_halt {get;set;}

        ///<summary>
        ///充值日期
        /// </summary>
        public DateTime? dt_ChargeDate {get;set;}

        ///<summary>
        ///充值人 webAdmin为网上充值 其他为门店员工编号
        /// </summary>
        public string str_ChargeEmp {get;set;}

        ///<summary>
        ///dt_Bdate
        /// </summary>
        public DateTime? dt_Bdate {get;set;}

        ///<summary>
        ///PayType
        /// </summary>
        public int? PayType {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_remark {get;set;}

        ///<summary>
        ///str_easyflag
        /// </summary>
        public string str_easyflag {get;set;}

        ///<summary>
        ///str_OldCardID
        /// </summary>
        public string str_OldCardID {get;set;}

        ///<summary>
        ///过期日期
        /// </summary>
        public DateTime? dt_ExpiredDate {get;set;}



    }

    /// <summary>
    /// 积分列表的类
    /// </summary>
    public class ChargeIntegralResultM : BaseMyAccountM
    {
        /// <summary>
        /// 会员卡
        /// </summary>
        public VipCardInfoM cardM { get; set; }

        /// <summary>
        /// 积分使用情况
        /// </summary>
        public List<VipCardChargeIntegralM> list { get; set; }
    }
}