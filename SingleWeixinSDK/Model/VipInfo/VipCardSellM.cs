using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipCard_Sell
    /// </summary>
    public class VipCardSellM
    {
        ///<summary>
        ///Ing_pk_id
        /// </summary>
        public int Ing_pk_id {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///会员卡号
        /// </summary>
        public string str_fk_VipCardNo {get;set;}

        ///<summary>
        ///会员号
        /// </summary>
        public string str_fk_VipID {get;set;}

        ///<summary>
        ///销售金额
        /// </summary>
        public decimal? dec_selllMoney {get;set;}

        ///<summary>
        ///销售日期
        /// </summary>
        public DateTime? dt_sellDate {get;set;}

        ///<summary>
        ///佣金百分比
        /// </summary>
        public decimal sellper {get;set;}

        ///<summary>
        ///销售人员
        /// </summary>
        public string str_sellman {get;set;}

        ///<summary>
        ///str_memo
        /// </summary>
        public string str_memo {get;set;}

        ///<summary>
        ///dt_Bdate
        /// </summary>
        public DateTime? dt_Bdate {get;set;}

        ///<summary>
        ///str_Shift
        /// </summary>
        public string str_Shift {get;set;}



    }
}