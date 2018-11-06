using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipCard_Type
    /// </summary>
    public class VipCardTypeM
    {
        ///<summary>
        ///卡类型编号
        /// </summary>
        public int Ing_CardTypeID {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///卡类型
        /// </summary>
        public string str_CardTypeName {get;set;}

        ///<summary>
        ///是否有效 0 为无效，1 为有效
        /// </summary>
        public int Ing_Halt {get;set;}


        ///<summary>
        ///是否有效
        /// </summary>
        public string str_Halt { get {
            return Ing_Halt == 1 ? "有效" : "无效";
        
        } }

        ///<summary>
        ///策略编号
        /// </summary>
        public int Ing_PolicyNumber {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_remark {get;set;}

        ///<summary>
        ///排序
        /// </summary>
        public int? Ing_Seq {get;set;}

        ///<summary>
        ///上级卡类型编号
        /// </summary>
        public int? Ing_UpLevlvID {get;set;}

        ///<summary>
        ///下级卡类型编号
        /// </summary>
        public int? Ing_DowmLevlvID {get;set;}

        ///<summary>
        ///升级条件
        /// </summary>
        public string str_UpStrWhere {get;set;}

        ///<summary>
        ///降级条件
        /// </summary>
        public string str_DowmWhere {get;set;}

        ///<summary>
        ///str_RateCode
        /// </summary>
        public string str_RateCode {get;set;}

        ///<summary>
        ///dec_PriceFee
        /// </summary>
        public decimal? dec_PriceFee {get;set;}

        ///<summary>
        ///开始卡号
        /// </summary>
        public string str_VipCardStart {get;set;}

        ///<summary>
        ///结束卡号
        /// </summary>
        public string str_VipCardEnd {get;set;}

        ///<summary>
        ///此卡类是储值卡,0表示否,1表示是
        /// </summary>
        public int? IsDepositable {get;set;}

        ///<summary>
        ///初始积分
        /// </summary>
        public int? Ing_InitScore {get;set;}

        ///<summary>
        ///加收半天房费退房时间
        /// </summary>
        public string str_HalfCheckoutTime {get;set;}

        ///<summary>
        ///加收全天房费退房时间
        /// </summary>
        public string str_FullCheckoutTime {get;set;}

        ///<summary>
        ///每分对应的人民币数
        /// </summary>
        public decimal? dec_RmbPerScore {get;set;}

        ///<summary>
        ///客源市场编码
        /// </summary>
        public string str_Mcode {get;set;}

        ///<summary>
        ///OpenContent
        /// </summary>
        public int? OpenContent {get;set;}

        ///<summary>
        ///销售价格
        /// </summary>
        public decimal? dec_SalePrice {get;set;}

        ///<summary>
        ///续费价格
        /// </summary>
        public decimal? dec_ContinuePrice {get;set;}

        ///<summary>
        ///有效期月
        /// </summary>
        public int? ValidMonthLength {get;set;}

        ///<summary>
        ///此卡类为网络注册时的默认卡
        /// </summary>
        public int? IsForRegister {get;set;}

        ///<summary>
        ///储值卡消费时需使用密码
        /// </summary>
        public int? UsingConsumePwd {get;set;}

        ///<summary>
        ///必须使用读卡器读取卡号
        /// </summary>
        public int? UsingCardReader {get;set;}

        ///<summary>
        ///此卡类需要先开卡，再激活
        /// </summary>
        public int? NeedInitCard {get;set;}

        ///<summary>
        ///禁止会员办多张卡（本卡类内）
        /// </summary>
        public int? CardUserUnique {get;set;}

        ///<summary>
        ///禁止前台修改销售价格
        /// </summary>
        public int? FixPrice {get;set;}

        ///<summary>
        ///积分支付只允许本人使用,0表示否,1表示是
        /// </summary>
        public int? SelfScore {get;set;}

        ///<summary>
        ///储值支付只允许本人使用,0表示否,1表示是
        /// </summary>
        public int? SelfDeposit {get;set;}

        ///<summary>
        ///是否是公司卡
        /// </summary>
        public int? IsForCompany {get;set;}

        ///<summary>
        ///推荐本类新用户的奖励积分
        /// </summary>
        public int? IntroScore {get;set;}

        ///<summary>
        ///可以手工输入卡号
        /// </summary>
        public int? ManualInput {get;set;}

        ///<summary>
        ///会员卡申请打印备注
        /// </summary>
        public string PrintNote {get;set;}

        ///<summary>
        ///Noshow扣除积分数额
        /// </summary>
        public int? NoshowScore {get;set;}

        ///<summary>
        ///手机号必填
        /// </summary>
        public int? RequireMobile {get;set;}

        ///<summary>
        ///至少消费多少元才发送积分支付短信
        /// </summary>
        public decimal? dec_SmsScoreFactor {get;set;}

        ///<summary>
        ///至少消费多少元才发送储值短信
        /// </summary>
        public decimal? dec_SmsDepositFactor {get;set;}

        ///<summary>
        ///生日祝福要求，积分至少多少
        /// </summary>
        public decimal? dec_BirSmsScoreTop {get;set;}

        ///<summary>
        ///生日祝福要求，入住次数至少多少
        /// </summary>
        public int? BirSmsNumTop {get;set;}

        ///<summary>
        ///生日祝福要求，月内入住次数至少多少
        /// </summary>
        public int? BirSmsMonthNumTop {get;set;}

        ///<summary>
        ///生日祝福短信内容
        /// </summary>
        public string BirSmsContent {get;set;}

        ///<summary>
        ///生日祝福提前天数
        /// </summary>
        public int? BirSmsAdvDays {get;set;}

        ///<summary>
        ///储值充值时赠送金额或积分,1表示金额,2表示积分
        /// </summary>
        public int? DepositSendType {get;set;}

        ///<summary>
        ///预订上限，0表示不限制
        /// </summary>
        public int? OrderMaxNum {get;set;}

        ///<summary>
        ///预订单保留时间
        /// </summary>
        public int? OrderReserveHour {get;set;}

        ///<summary>
        ///储值卡结账是否产生积分,0表示不产生,1表示产生
        /// </summary>
        public int? DepositCreateScore {get;set;}

        ///<summary>
        ///用户发布点评奖励积分
        /// </summary>
        public int? Ing_CommentScore {get;set;}

        ///<summary>
        ///禁止会员办多张卡（全部卡类）
        /// </summary>
        public int? CardUserUniqueAll {get;set;}

        ///<summary>
        ///str_PayPcode
        /// </summary>
        public string str_PayPcode {get;set;}

        ///<summary>
        ///str_IncomePcode
        /// </summary>
        public string str_IncomePcode {get;set;}

        ///<summary>
        ///dec_PresentCost
        /// </summary>
        public decimal? dec_PresentCost {get;set;}

        ///<summary>
        ///Ing_WXScore
        /// </summary>
        public int? Ing_WXScore {get;set;}

        ///<summary>
        ///Ing_PayScore
        /// </summary>
        public int? Ing_PayScore {get;set;}

        ///<summary>
        ///Ing_Fk_RateID
        /// </summary>
        public int? Ing_Fk_RateID {get;set;}

        /// <summary>
        /// 积分
        /// </summary>
        public int? Ing_jifen { get; set; }

        /// <summary>
        /// 优惠券类型id
        /// </summary>
        public int? Ing_CouponTypeID { get; set; }

        
        /// <summary>
        /// 是否支持首住优惠
        /// </summary>
        public int Ing_FirstCheck { get; set; }
    }
}