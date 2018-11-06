using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipCard_ChargeMon
    /// </summary>
    public class VipCardChargeMonM
    {
        ///<summary>
        ///Ing_pk_VCMID
        /// </summary>
        public int Ing_pk_VCMID { get; set; }

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID { get; set; }

        ///<summary>
        ///Ing_Fk_VipCardID
        /// </summary>
        public int? Ing_Fk_VipCardID { get; set; }

        ///<summary>
        ///会员卡号
        /// </summary>
        public string str_VipCard { get; set; }

        ///<summary>
        ///str_pk_accnt
        /// </summary>
        public string str_pk_accnt { get; set; }

        ///<summary>
        ///消费金额
        /// </summary>
        public decimal? dec_ChargeMon { get; set; }

        ///<summary>
        ///充值金额
        /// </summary>
        public decimal? dec_CreditMon { get; set; }

        ///<summary>
        ///本期余额
        /// </summary>
        public decimal? dec_Balance { get; set; }

        ///<summary>
        ///充值类型
        /// </summary>
        public int? Ing_ChargeType { get; set; }

        ///<summary>
        ///是否有效 1为有效 0为无效
        /// </summary>
        public int? Ing_halt { get; set; }

        ///<summary>
        ///充值日期
        /// </summary>
        public DateTime? dt_ChargeDate { get; set; }

        ///<summary>
        ///充值操作员
        /// </summary>
        public string str_ChargeEmp { get; set; }

        ///<summary>
        ///赠送积分额
        /// </summary>
        public int? Ing_SendIntegral { get; set; }

        ///<summary>
        ///dt_Bdate
        /// </summary>
        public DateTime? dt_Bdate { get; set; }

        ///<summary>
        ///赠送金额过期日期
        /// </summary>
        public int? PayType { get; set; }

        ///<summary>
        ///备注
        /// </summary>
        public string str_Remark { get; set; }

        ///<summary>
        ///dt_ExpiredDate
        /// </summary>
        public DateTime? dt_ExpiredDate { get; set; }

        /// <summary>
        /// 可开发票金额
        /// </summary>
        public int Ing_Receipt { get; set; }

        /// <summary>
        /// 赠送的父id
        /// </summary>
        public int Ing_Pid { get; set; }



    }


    /// <summary>
    /// 储值列表的类
    /// </summary>
    public class ChargeMonResultM:BaseMyAccountM
    {
        /// <summary>
        /// 会员卡
        /// </summary>
        public VipCardInfoM cardM { get; set; }

        /// <summary>
        /// 储值使用情况
        /// </summary>
        public List<VipCardChargeMonM> list { get; set; }
    }
}