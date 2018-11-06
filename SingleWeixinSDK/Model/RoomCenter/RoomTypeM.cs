using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.RoomCenter
{
    /// <summary>
    /// T_Room_Type
    /// </summary>
    public class RoomTypeM
    {
        ///<summary>
        ///自增
        /// </summary>
        public int Ing_Pk_RoomTypeID { get; set; }

        ///<summary>
        ///房类代码
        /// </summary>
        public string str_TypeCode { get; set; }

        ///<summary>
        ///房类名称
        /// </summary>
        public string str_TypeName { get; set; }

        ///<summary>
        ///房类名称（英）
        /// </summary>
        public string str_TypeNameEng { get; set; }

        ///<summary>
        ///房间数量
        /// </summary>
        public int? Ing_roomNum { get; set; }

        ///<summary>
        ///可超定数量
        /// </summary>
        public int? Ing_overNumber { get; set; }

        ///<summary>
        ///可调整数
        /// </summary>
        public int? Ing_adjNum { get; set; }

        ///<summary>
        ///房价码
        /// </summary>
        public string str_rateCode { get; set; }

        ///<summary>
        ///房价
        /// </summary>
        public decimal? dec_rate { get; set; }

        ///<summary>
        ///开始时间
        /// </summary>
        public DateTime? dt_BeginTime { get; set; }

        ///<summary>
        ///结束时间
        /// </summary>
        public DateTime? dt_EndTime { get; set; }

        ///<summary>
        ///大房类型
        /// </summary>
        public string str_Fk_GType { get; set; }

        ///<summary>
        ///大房类标记
        /// </summary>
        public string str_RmTag { get; set; }

        ///<summary>
        ///图片
        /// </summary>
        public string str_pic { get; set; }

        ///<summary>
        ///是否停用(0 :停用 1:正常)
        /// </summary>
        public int? Ing_halt { get; set; }

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modify { get; set; }

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_ModifyTime { get; set; }

        ///<summary>
        ///Ing_IsNinghtAudit
        /// </summary>
        public int? Ing_IsNinghtAudit { get; set; }

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID { get; set; }

        /// <summary>
        /// 积分兑换的时候，这个房型需要多少积分
        /// </summary>
        public int Ing_NeedIntegral { get; set; }


        /// <summary>
        /// 如果是默认房价，这个字段会有值，否则，为0，  只在列表查询的地方有用
        /// </summary>
        public int IngDefaultID { get; set; }


        /// <summary>
        /// 可以在微信做钟点房预订的房型
        /// </summary>
        public int Ing_ShowInHourWechat { get; set; }


        /// <summary>
        /// 会员首住的房价
        /// </summary>
        public decimal? dec_FirstLivePrice { get; set; }

        /// <summary>
        /// 默认房价码的标识
        /// </summary>
        public string strDefault
        {
            get
            {
                return IngDefaultID == 0 ? "" : "默认";
            }
        }
    }

    /// <summary>
    /// 简单的房类
    /// </summary>
    public class RoomTypeSimpleM
    {
        ///<summary>
        ///房类代码
        /// </summary>
        public string str_TypeCode { get; set; }

        ///<summary>
        ///房类名称
        /// </summary>
        public string str_TypeName { get; set; }
    }
}
