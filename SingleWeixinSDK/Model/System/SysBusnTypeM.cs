using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Sys_BusnType
    /// </summary>
    public class SysBusnTypeM
    {
        ///<summary>
        ///Ing_pk_TypeID
        /// </summary>
        public int Ing_pk_TypeID {get;set;}

        ///<summary>
        ///类别代码(同一门店不允许重复出现)
        /// </summary>
        public string str_TypeCode {get;set;}

        ///<summary>
        ///系统参数对照ID
        /// </summary>
        public string str_BusineTypeID {get;set;}

        ///<summary>
        ///类别名称
        /// </summary>
        public string str_TypeName {get;set;}

        ///<summary>
        ///英文类别名称
        /// </summary>
        public string str_TypeNameEng {get;set;}

        ///<summary>
        ///排序号
        /// </summary>
        public int? Ing_Seq {get;set;}

        ///<summary>
        ///是否可用（1:可用，0:不可用）
        /// </summary>
        public int? Ing_sta {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_Memo {get;set;}

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modify {get;set;}

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_ModifyTime {get;set;}

        ///<summary>
        ///str_ReferName
        /// </summary>
        public string str_ReferName {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}



    }

    /// <summary>
    /// 系统代码的简洁版
    /// </summary>
    public class SysBusnTypeSimpleM
    {
        ///<summary>
        ///Ing_pk_TypeID
        /// </summary>
        public int Ing_pk_TypeID { get; set; }


        ///<summary>
        ///类别代码(同一门店不允许重复出现)
        /// </summary>
        public string str_TypeCode { get; set; }

        ///<summary>
        ///系统参数对照ID
        /// </summary>
        public string str_BusineTypeID { get; set; }

        ///<summary>
        ///类别名称
        /// </summary>
        public string str_TypeName { get; set; }
    }
}