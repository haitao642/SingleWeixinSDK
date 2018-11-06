using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_ContinueInter
    /// </summary>
    public class ContinueInterM
    {
        ///<summary>
        ///自增主键
        /// </summary>
        public int Ing_pkid {get;set;}

        ///<summary>
        ///门店ID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///主单ID
        /// </summary>
        public int Ing_MasterID {get;set;}

        ///<summary>
        ///原来的离期
        /// </summary>
        public DateTime? dt_Odepdate {get;set;}

        ///<summary>
        ///新的离期
        /// </summary>
        public DateTime? dt_depdate {get;set;}

        ///<summary>
        ///续住几天
        /// </summary>
        public int? Ing_days {get;set;}

        ///<summary>
        ///此次续住产生的价格
        /// </summary>
        public decimal? dec_price {get;set;}

        ///<summary>
        ///0:续住   1：退房
        /// </summary>
        public int Ing_type {get;set;}

        ///<summary>
        ///阅读标志   0：未阅读    1：已阅读
        /// </summary>
        public int Ing_ReadFlag {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime dt_Create {get;set;}

        ///<summary>
        ///续住付款标识  0：未付款   1：已付款
        /// </summary>
        public int Ing_PayType {get;set;}



    }


    /// <summary>
    /// 续住页面显示用的model
    /// </summary>
    public class ContinueInterDisplay {

        /// <summary>
        /// 主单ID
        /// </summary>
        public int Ing_MasterID { get; set; }


        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 入住人
        /// </summary>
        public string str_cusname { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string str_mobile { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 一天的价格
        /// </summary>
        public decimal dec_priceOneNight { get; set; }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal dec_price { get; set; }

        /// <summary>
        /// 续住的天数
        /// </summary>
        public int Ing_ContinueDays { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string str_Accnt { get; set; }


        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }

        /// <summary>
        /// 房型
        /// </summary>
        public string str_roomtype1 { get; set; }

        /// <summary>
        /// 房间数
        /// </summary>
        public int Ing_RoomNum { get; set; }

        /// <summary>
        /// 原来的来期
        /// </summary>
        public DateTime dtArr { get; set; }


        /// <summary>
        /// 原来的离期
        /// </summary>
        public DateTime dtDep { get; set; }

        /// <summary>
        /// 原来的房晚数
        /// </summary>
        public int Ing_OldNight { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
    }



    /// <summary>
    /// 选择  退房  还是   续住
    /// </summary>
    public class SelectContinueM
    {
        /// <summary>
        /// 主单ID
        /// </summary>
        public int Ing_MasterID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string str_Cusname { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string message { get; set; }
    }
}