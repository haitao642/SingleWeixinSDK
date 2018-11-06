using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_TimeRoomRule
    /// </summary>
    public class TimeRoomRuleM
    {
        ///<summary>
        ///Ing_PID
        /// </summary>
        public int Ing_PID {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///房型，空表示全部
        /// </summary>
        public string str_RoomType {get;set;}

        ///<summary>
        ///会员卡类型，空表示全部
        /// </summary>
        public int Ing_VipCardType {get;set;}

        ///<summary>
        ///有效开始日期
        /// </summary>
        public DateTime? dt_BeginTime {get;set;}

        ///<summary>
        ///有效结束日期
        /// </summary>
        public DateTime? dt_EndTime {get;set;}

        ///<summary>
        ///起步价
        /// </summary>
        public decimal dec_StepRate {get;set;}

        ///<summary>
        ///起步时间
        /// </summary>
        public int Ing_StepHoure {get;set;}

        ///<summary>
        ///延时
        /// </summary>
        public int? Ing_DelayTime {get;set;}

        ///<summary>
        ///超过后每小时增加的房费
        /// </summary>
        public decimal dec_AddRateByHoure {get;set;}

        ///<summary>
        ///钟点房入住时长，超过将转为全天房
        /// </summary>
        public int? Ing_MustChangeHoure {get;set;}

        ///<summary>
        ///状态 1为可用 0 为不可用
        /// </summary>
        public int Ing_Sta {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_Remark {get;set;}

        ///<summary>
        ///开始时间
        /// </summary>
        public string str_B_Time {get;set;}

        ///<summary>
        ///结束时间
        /// </summary>
        public string str_E_Time {get;set;}

        ///<summary>
        ///优先级
        /// </summary>
        public int? Prior {get;set;}

        /// <summary>
        /// 客源编码
        /// </summary>
        public string ClockGuestMarket { get; set; }

        /// <summary>
        /// 客源
        /// </summary>
        public string marketName { get; set; }

        /// <summary>
        /// 会员卡类型
        /// </summary>
        public string CardTypeName { get; set; }

        /// <summary>
        /// 房型
        /// </summary>
        public string TypeName { get; set; }

    }

    /// <summary>
    /// 钟点房费规则的设置，查询时用到的参数
    /// </summary>
    public class ParaForSearchTimeRuleM
    {
        ///<summary>
        ///房型，空表示全部
        /// </summary>
        public string str_RoomType { get; set; }

        ///<summary>
        ///会员卡类型，0表示全部
        /// </summary>
        public int Ing_VipCardType { get; set; }

        ///<summary>
        ///状态 1为可用 0 为不可用
        /// </summary>
        public int Ing_Sta { get; set; }
    }
}