using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipCard_Log
    /// </summary>
    public class VipCardLogM
    {
        ///<summary>
        ///Ing_LogID
        /// </summary>
        public int Ing_LogID {get;set;}

        ///<summary>
        ///门店号
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///会员ID
        /// </summary>
        public int? Ing_Fk_VipCardId {get;set;}

        ///<summary>
        ///变更类型
        /// </summary>
        public string str_LogType {get;set;}

        ///<summary>
        ///IP地址
        /// </summary>
        public string str_LogIP {get;set;}

        ///<summary>
        ///生成时间
        /// </summary>
        public DateTime? dt_LogDate {get;set;}

        ///<summary>
        ///日志内容
        /// </summary>
        public string str_LogDesc {get;set;}

        ///<summary>
        ///操作员
        /// </summary>
        public string str_UserNo {get;set;}

        ///<summary>
        ///老卡号
        /// </summary>
        public string str_OldVipCard {get;set;}

        ///<summary>
        ///新卡号
        /// </summary>
        public string str_NewVipCard {get;set;}



    }

    /// <summary>
    /// RecordLogM
    /// </summary>
    public class RecordLogM 
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string str_Code { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string str_Name { get; set; }
    }
}