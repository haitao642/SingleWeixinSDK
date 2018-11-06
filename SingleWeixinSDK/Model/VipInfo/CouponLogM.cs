using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_CouponLog
    /// </summary>
    public class CouponLogM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_LogID {get;set;}

        ///<summary>
        ///优惠券主键
        /// </summary>
        public int? Ing_PaperID {get;set;}

        ///<summary>
        ///优惠券编码
        /// </summary>
        public string str_PaperCode {get;set;}

        ///<summary>
        ///使用门店
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///主单
        /// </summary>
        public int? Ing_MasterID {get;set;}

        ///<summary>
        ///主单账号
        /// </summary>
        public string str_PK_Accnt {get;set;}

        ///<summary>
        ///这张优惠券使用产生的账务id
        /// </summary>
        public int? Ing_AccID {get;set;}

        ///<summary>
        ///是否使用   1,未使用,2使用
        /// </summary>
        public int? Ing_useSta {get;set;}

        ///<summary>
        ///房间号
        /// </summary>
        public string str_RoomNo {get;set;}

        ///<summary>
        ///使用时间
        /// </summary>
        public DateTime? dt_useTime {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_remark {get;set;}

        ///<summary>
        ///使用者
        /// </summary>
        public string str_Empno {get;set;}


        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 状态中文
        /// </summary>
        public string StrStaName { get; set; }

    }
}