using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Sys_Para
    /// </summary>
    public class SysParaM
    {
        ///<summary>
        ///Ing_pk_PID
        /// </summary>
        public int Ing_pk_PID {get;set;}

        ///<summary>
        ///参数类别
        /// </summary>
        public string str_ParaType {get;set;}

        ///<summary>
        ///参数代码（要求唯一）
        /// </summary>
        public string str_ParaCode {get;set;}

        ///<summary>
        ///参数名称
        /// </summary>
        public string str_ParaName {get;set;}

        ///<summary>
        ///参数值
        /// </summary>
        public string str_ParaData {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_Memo {get;set;}

        ///<summary>
        ///状态（0，允许设置，1，只读，2,不显示）
        /// </summary>
        public int? Ing_sta {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}



    }
}