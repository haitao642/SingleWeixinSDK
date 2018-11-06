using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Acc
    /// </summary>
    public class AccM
    {
        ///<summary>
        ///Ing_Acc_Id
        /// </summary>
        public int Ing_Acc_Id {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///主单id
        /// </summary>
        public int Ing_Fk_MasterID { get; set; }

        ///<summary>
        ///房号
        /// </summary>
        public string str_RoomNo {get;set;}

        ///<summary>
        ///主单号
        /// </summary>
        public string str_Pk_Accnt {get;set;}

        ///<summary>
        ///物理序号
        /// </summary>
        public int Ing_Pk_number {get;set;}

        ///<summary>
        ///分帐号
        /// </summary>
        public int Ing_SubAccnt {get;set;}

        ///<summary>
        ///关联序号
        /// </summary>
        public int Ing_Serialnumber {get;set;}

        ///<summary>
        ///生成日期(系统当前日期)
        /// </summary>
        public DateTime dt_ModifyDate {get;set;}

        ///<summary>
        ///营业日期(以夜审为标准的日期，不包含时间)
        /// </summary>
        public DateTime dt_BDate {get;set;}

        ///<summary>
        ///业务日期(系统时间,以夜审为标准)
        /// </summary>
        public DateTime? dt_CreateDate {get;set;}

        ///<summary>
        ///营业代码
        /// </summary>
        public string str_PcCode {get;set;}

        ///<summary>
        ///账单编码
        /// </summary>
        public string str_ArgCode {get;set;}

        ///<summary>
        ///数量
        /// </summary>
        public int Ing_Qty {get;set;}

        ///<summary>
        ///实收金额
        /// </summary>
        public decimal? dec_TotalCharge {get;set;}

        ///<summary>
        ///门市价
        /// </summary>
        public decimal? dec_BaseCharge {get;set;}

        ///<summary>
        ///返还金额
        /// </summary>
        public decimal? dec_Preferential {get;set;}

        ///<summary>
        ///服务费
        /// </summary>
        public decimal? dec_ServerCharge {get;set;}

        ///<summary>
        ///附加费
        /// </summary>
        public decimal dec_AffixCharge {get;set;}

        ///<summary>
        ///其他费
        /// </summary>
        public decimal? dec_OtherCharge {get;set;}

        ///<summary>
        ///实际使用包
        /// </summary>
        public decimal? dec_TrueUserPack {get;set;}

        ///<summary>
        ///允许使用包
        /// </summary>
        public decimal dec_AllowPackaged {get;set;}

        ///<summary>
        ///包实际金额
        /// </summary>
        public decimal? dec_TruePackaged {get;set;}

        ///<summary>
        ///押金
        /// </summary>
        public decimal? dec_Credit {get;set;}

        ///<summary>
        ///余额
        /// </summary>
        public decimal? dec_Balance {get;set;}

        ///<summary>
        ///班次
        /// </summary>
        public string str_Shift {get;set;}

        ///<summary>
        ///用户
        /// </summary>
        public string str_Empno {get;set;}

        ///<summary>
        ///财务标志
        /// </summary>
        public string str_Crradjt {get;set;}

        ///<summary>
        ///刷卡行
        /// </summary>
        public string str_Waiter {get;set;}

        ///<summary>
        ///市场码
        /// </summary>
        public string str_MarketID {get;set;}

        ///<summary>
        ///原因
        /// </summary>
        public string str_Reason {get;set;}

        ///<summary>
        ///转账方向
        /// </summary>
        public string str_ToFrom {get;set;}

        ///<summary>
        ///转账来源
        /// </summary>
        public string str_AccnToF {get;set;}

        ///<summary>
        ///转账分账户
        /// </summary>
        public int Ing_SubAccnToF {get;set;}

        ///<summary>
        ///描述
        /// </summary>
        public string str_desc {get;set;}

        ///<summary>
        ///单号
        /// </summary>
        public string str_SingleNum {get;set;}

        ///<summary>
        ///摘要
        /// </summary>
        public string str_Abstract {get;set;}

        ///<summary>
        ///团号
        /// </summary>
        public string str_GroupNo {get;set;}

        ///<summary>
        ///房费模式
        /// </summary>
        public string str_Mode {get;set;}

        ///<summary>
        ///账单号
        /// </summary>
        public int Ing_Billno {get;set;}

        ///<summary>
        ///账单类型
        /// </summary>
        public int? Ing_AccTypeID {get;set;}

        ///<summary>
        ///是否有效 1为有效，0为无效
        /// </summary>
        public int? Ing_sta {get;set;}

        ///<summary>
        ///结帐单号
        /// </summary>
        public string str_CheckoutNo {get;set;}

        ///<summary>
        ///银行卡号
        /// </summary>
        public int? Ing_bankCardNo {get;set;}

        ///<summary>
        ///积分比例
        /// </summary>
        public decimal? dec_IntegralSum {get;set;}

        ///<summary>
        ///添加房费类型
        /// </summary>
        public string str_RateType {get;set;}

        ///<summary>
        ///str_OldAccnt
        /// </summary>
        public string str_OldAccnt {get;set;}

        ///<summary>
        ///str_rem
        /// </summary>
        public string str_rem {get;set;}

        ///<summary>
        ///str_intertype
        /// </summary>
        public string str_intertype {get;set;}

        ///<summary>
        ///str_SplitOldAccnt
        /// </summary>
        public string str_SplitOldAccnt {get;set;}

        ///<summary>
        ///str_VipCard
        /// </summary>
        public string str_VipCard {get;set;}

        /// <summary>
        /// 会员卡主键
        /// </summary>
        public int Ing_Fk_VipCardID { get; set; }

        /// <summary>
        /// T_Item_Acc的主键
        /// </summary>
        public int Ing_ItemAccID { get; set; }

    }
}