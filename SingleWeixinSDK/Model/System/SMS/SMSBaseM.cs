using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_SMSBase
    /// </summary>
    public class SMSBaseM
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
        ///str_SMSContent
        /// </summary>
        public string str_SMSContent {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_Memo {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}



    }
}