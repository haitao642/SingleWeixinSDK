using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_WxChargeMon
    /// </summary>
    public class WxChargeMonM
    {
        public WxChargeMonM(int Ing_Pk_id,int Ing_ChareMon)
        {
            this.Ing_ChareMon = Ing_ChareMon;
            this.Ing_Pk_id = Ing_Pk_id;
            this.str_order = "WxChargeMon10" + Ing_Pk_id.ToString();
            str_memo = "储值充值:" + Ing_ChareMon.ToString() + "元";
        }
        public WxChargeMonM()
        {

        }
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_Pk_id {get;set;}

        ///<summary>
        ///充多少
        /// </summary>
        public int Ing_ChareMon {get;set;}

        ///<summary>
        ///送的金额
        /// </summary>
        public int Ing_SendMon {get;set;}

        ///<summary>
        ///描述
        /// </summary>
        public string str_memo {get;set;}

        ///<summary>
        ///排序
        /// </summary>
        public int Ing_order {get;set;}
        /// <summary>
        /// 排序
        /// </summary>
        public string str_order { get; set; }


    }
}