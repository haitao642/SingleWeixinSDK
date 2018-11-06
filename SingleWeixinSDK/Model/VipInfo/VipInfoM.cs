using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Vip_Info
    /// </summary>
    public class VipInfoM
    {
        ///<summary>
        ///Ing_Pk_VipID
        /// </summary>
        public int Ing_Pk_VipID {get;set;}

        ///<summary>
        ///会员号
        /// </summary>
        public string str_VipID {get;set;}

        ///<summary>
        ///Ing_Fk_CustID
        /// </summary>
        public int? Ing_Fk_CustID {get;set;}

        ///<summary>
        ///会员类型
        /// </summary>
        public int? Ing_VipType {get;set;}

        ///<summary>
        ///会员等级
        /// </summary>
        public int? Ing_VipLevel {get;set;}

        ///<summary>
        ///总共积分
        /// </summary>
        public int? Ing_TotalIntegral {get;set;}

        ///<summary>
        ///消费积分
        /// </summary>
        public int? Ing_ExchangeIntegral {get;set;}

        ///<summary>
        ///剩余积分
        /// </summary>
        public int? Ing_SurplusIntegral {get;set;}

        ///<summary>
        ///剩余金额
        /// </summary>
        public decimal? dec_SurplusMoney {get;set;}

        ///<summary>
        ///dec_PersentMoney
        /// </summary>
        public decimal? dec_PersentMoney {get;set;}

        ///<summary>
        ///间夜积分
        /// </summary>
        public decimal? dec_RoomNightScore {get;set;}

        ///<summary>
        ///钟点房入住次数
        /// </summary>
        public int? Ing_ClockRoomCount {get;set;}

        ///<summary>
        ///是否停用 1为不停用 0 为停用
        /// </summary>
        public int? Ing_halt {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_Remark {get;set;}

        ///<summary>
        ///卡密码（明码）最大16位
        /// </summary>
        public string str_pwd {get;set;}

        ///<summary>
        ///会员登录名
        /// </summary>
        public string str_loginName {get;set;}

        ///<summary>
        ///会员登录密码
        /// </summary>
        public string str_loginPwd {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_CreateTime {get;set;}

        ///<summary>
        ///str_ptrv
        /// </summary>
        public string str_ptrv {get;set;}

        ///<summary>
        ///str_easyflag
        /// </summary>
        public string str_easyflag {get;set;}

        ///<summary>
        ///Ing_IsGroup
        /// </summary>
        public int? Ing_IsGroup {get;set;}

        ///<summary>
        ///79元特权
        /// </summary>
        public int? Ing_IsTq {get;set;}

        ///<summary>
        ///ATC用到
        /// </summary>
        public int? Ing_IsVflag {get;set;}

        ///<summary>
        ///str_RegisterChannel
        /// </summary>
        public string str_RegisterChannel {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}


    }
}