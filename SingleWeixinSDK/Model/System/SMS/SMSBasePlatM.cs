using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_SMSBasePlat
    /// </summary>
    public class SMSBasePlatM
    {
        ///<summary>
        ///Ing_pk_sd
        /// </summary>
        public int Ing_pk_sd {get;set;}

        ///<summary>
        ///短信类别（唯一）
        /// </summary>
        public string str_SMSType {get;set;}

        ///<summary>
        ///短信类别名称
        /// </summary>
        public string str_SMSName {get;set;}

        ///<summary>
        ///状态（0:停用；1:启用）
        /// </summary>
        public int? Ing_sta {get;set;}

        ///<summary>
        ///发送短信的接口平台url
        /// </summary>
        public string str_SMSURL {get;set;}

        ///<summary>
        ///内容
        /// </summary>
        public string str_SMSContent {get;set;}

        ///<summary>
        ///str_Memo
        /// </summary>
        public string str_Memo {get;set;}

        ///<summary>
        ///执行的SQL语句
        /// </summary>
        public string str_Result {get;set;}

        ///<summary>
        ///执行的时间范围起
        /// </summary>
        public DateTime? dt_T1 {get;set;}

        ///<summary>
        ///执行的时间范围止
        /// </summary>
        public DateTime? dt_T2 {get;set;}

        ///<summary>
        ///str_Week1
        /// </summary>
        public string str_Week1 {get;set;}

        ///<summary>
        ///str_Week2
        /// </summary>
        public string str_Week2 {get;set;}

        ///<summary>
        ///str_Week3
        /// </summary>
        public string str_Week3 {get;set;}

        ///<summary>
        ///str_Week4
        /// </summary>
        public string str_Week4 {get;set;}

        ///<summary>
        ///str_Week5
        /// </summary>
        public string str_Week5 {get;set;}

        ///<summary>
        ///str_Week6
        /// </summary>
        public string str_Week6 {get;set;}

        ///<summary>
        ///str_Week7
        /// </summary>
        public string str_Week7 {get;set;}

        ///<summary>
        ///str_Mask1
        /// </summary>
        public string str_Mask1 {get;set;}

        ///<summary>
        ///str_Mask7
        /// </summary>
        public string str_Mask7 {get;set;}

        ///<summary>
        ///str_Mask6
        /// </summary>
        public string str_Mask6 {get;set;}

        ///<summary>
        ///str_Mask5
        /// </summary>
        public string str_Mask5 {get;set;}

        ///<summary>
        ///str_Mask4
        /// </summary>
        public string str_Mask4 {get;set;}

        ///<summary>
        ///str_Mask3
        /// </summary>
        public string str_Mask3 {get;set;}

        ///<summary>
        ///str_Mask2
        /// </summary>
        public string str_Mask2 {get;set;}

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modifier {get;set;}

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_ModifyTime {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}



    }
}