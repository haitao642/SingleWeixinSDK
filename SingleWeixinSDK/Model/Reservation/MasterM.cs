using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Master
    /// </summary>
    public class MasterM
    {
        ///<summary>
        ///Ing_Pk_MasterID
        /// </summary>
        public int Ing_Pk_MasterID {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///房号
        /// </summary>
        public string str_RoomNo {get;set;}

        ///<summary>
        ///账号
        /// </summary>
        public string str_Pk_Accnt {get;set;}

        ///<summary>
        ///客户号
        /// </summary>
        public int? Ing_FK_CustID {get;set;}

        ///<summary>
        ///团队账号
        /// </summary>
        public string str_GroupNo {get;set;}

        /// <summary>
        /// 团队名称
        /// </summary>
        public string str_GroupName { get; set; }

        ///<summary>
        ///房类
        /// </summary>
        public string str_RoomType {get;set;}

        ///<summary>
        ///原房类
        /// </summary>
        public string str_ORoomType {get;set;}

        ///<summary>
        ///升级类型
        /// </summary>
        public string str_UpRoomType {get;set;}

        ///<summary>
        ///升级理由
        /// </summary>
        public string str_UpRoomTypeReson {get;set;}

        ///<summary>
        ///订房数
        /// </summary>
        public int? Ing_RoomNum {get;set;}

        ///<summary>
        ///原订房数
        /// </summary>
        public int? Ing_ORoomNum {get;set;}

        ///<summary>
        ///原房号
        /// </summary>
        public string str_ORoomNo {get;set;}

        ///<summary>
        ///营业时间
        /// </summary>
        public DateTime? dt_OperatDate {get;set;}

        ///<summary>
        ///房态
        /// </summary>
        public string str_Sta {get;set;}

        ///<summary>
        ///原房态
        /// </summary>
        public string str_OSta {get;set;}

        ///<summary>
        ///保留房态
        /// </summary>
        public string str_ResSta {get;set;}

        ///<summary>
        ///预留状态
        /// </summary>
        public string str_ExpSta {get;set;}

        ///<summary>
        ///夜审标记
        /// </summary>
        public string str_StaTm {get;set;}

        ///<summary>
        ///房帐标志
        /// </summary>
        public string str_RmPostSta {get;set;}

        ///<summary>
        ///是否入房帐
        /// </summary>
        public string str_RmPosted {get;set;}

        ///<summary>
        ///到达时间
        /// </summary>
        public DateTime? dt_ArrDate {get;set;}

        ///<summary>
        ///离店时间
        /// </summary>
        public DateTime? dt_DepDate {get;set;}

        ///<summary>
        ///保留离日
        /// </summary>
        public DateTime? dt_ResDep {get;set;}

        ///<summary>
        ///原到达时间
        /// </summary>
        public DateTime? dt_OArrDate {get;set;}

        ///<summary>
        ///原离开时间
        /// </summary>
        public DateTime? dt_ODepDate {get;set;}

        ///<summary>
        ///旅行社代号
        /// </summary>
        public string str_AgentID {get;set;}

        ///<summary>
        ///协议公司代号
        /// </summary>
        public string str_AgreeCompnyID {get;set;}

        /// <summary>
        /// 协议单位名称
        /// </summary>
        public string str_AgreeCompnyName { get; set; }

        ///<summary>
        ///订房中心
        /// </summary>
        public string str_RmResCentre {get;set;}

        ///<summary>
        ///帐户类别
        /// </summary>
        public string str_AccntType {get;set;}

        ///<summary>
        ///来源
        /// </summary>
        public string str_Source {get;set;}

        ///<summary>
        ///市场码
        /// </summary>
        public string str_Markets {get;set;}

        ///<summary>
        ///预定类型
        /// </summary>
        public string str_ResType {get;set;}

        ///<summary>
        ///渠道
        /// </summary>
        public string str_Channel {get;set;}

        ///<summary>
        ///ar类型1
        /// </summary>
        public string str_Artag1 {get;set;}

        ///<summary>
        ///ar类型2
        /// </summary>
        public string str_Artag2 {get;set;}

        ///<summary>
        ///共享
        /// </summary>
        public string str_Share {get;set;}

        ///<summary>
        ///人数
        /// </summary>
        public int? Ing_GstNum {get;set;}

        ///<summary>
        ///儿童
        /// </summary>
        public int? Ing_ChildrenNum {get;set;}

        ///<summary>
        ///换房理由
        /// </summary>
        public string str_ExcRmReason {get;set;}

        ///<summary>
        ///房价码
        /// </summary>
        public string str_RateID {get;set;}

        ///<summary>
        ///包价
        /// </summary>
        public string str_Packages {get;set;}

        ///<summary>
        ///固定房价
        /// </summary>
        public decimal? dec_FixRate {get;set;}

        ///<summary>
        ///协议房价
        /// </summary>
        public decimal? dec_AgreeRmRate {get;set;}

        ///<summary>
        ///门市价
        /// </summary>
        public decimal? dec_StandardRate {get;set;}

        ///<summary>
        ///实际房价
        /// </summary>
        public decimal? dec_ActualRate {get;set;}

        ///<summary>
        ///优惠理由
        /// </summary>
        public string str_PreferentReason {get;set;}

        ///<summary>
        ///折扣1
        /// </summary>
        public decimal? dec_discount {get;set;}

        ///<summary>
        ///折扣2
        /// </summary>
        public decimal? dec_discount1 {get;set;}

        ///<summary>
        ///加床数
        /// </summary>
        public int? Ing_AddBedNum {get;set;}

        ///<summary>
        ///加床价格
        /// </summary>
        public decimal? dec_AddBedRate {get;set;}

        ///<summary>
        ///婴儿床数
        /// </summary>
        public int? Ing_crib {get;set;}

        ///<summary>
        ///婴儿床价格
        /// </summary>
        public decimal? dec_CribRate {get;set;}

        ///<summary>
        ///付款方式
        /// </summary>
        public string str_PayType {get;set;}

        ///<summary>
        ///限额
        /// </summary>
        public decimal? dec_limit {get;set;}

        ///<summary>
        ///信用卡
        /// </summary>
        public string str_CredID {get;set;}

        ///<summary>
        ///担保人
        /// </summary>
        public string str_CredMan {get;set;}

        ///<summary>
        ///担保单位
        /// </summary>
        public string str_CredUnit {get;set;}

        ///<summary>
        ///str_idcls
        /// </summary>
        public string str_idcls {get;set;}

        ///<summary>
        ///str_ident
        /// </summary>
        public string str_ident {get;set;}

        ///<summary>
        ///str_street
        /// </summary>
        public string str_street {get;set;}

        ///<summary>
        ///str_nation
        /// </summary>
        public string str_nation {get;set;}

        ///<summary>
        ///str_cusname
        /// </summary>
        public string str_cusname {get;set;}

        ///<summary>
        ///str_gender
        /// </summary>
        public string str_gender {get;set;}

        ///<summary>
        ///dt_birth
        /// </summary>
        public DateTime? dt_birth {get;set;}

        ///<summary>
        ///预订人
        /// </summary>
        public string str_ApplName {get;set;}

        ///<summary>
        ///预订单位
        /// </summary>
        public string str_Applicant {get;set;}

        ///<summary>
        ///ar帐户
        /// </summary>
        public string str_ARAccnt {get;set;}

        ///<summary>
        ///电话
        /// </summary>
        public string str_phone {get;set;}

        ///<summary>
        ///传真
        /// </summary>
        public string str_fax {get;set;}

        ///<summary>
        ///邮件
        /// </summary>
        public string str_email {get;set;}

        ///<summary>
        ///来地
        /// </summary>
        public string str_WhereFrom {get;set;}

        ///<summary>
        ///去地
        /// </summary>
        public string str_whereto {get;set;}

        ///<summary>
        ///目的
        /// </summary>
        public string str_purpose {get;set;}

        ///<summary>
        ///到达信息
        /// </summary>
        public string str_ArrInfo {get;set;}

        ///<summary>
        ///接机
        /// </summary>
        public string str_ArrCar {get;set;}

        ///<summary>
        ///接机价格
        /// </summary>
        public decimal? dec_ArrRate {get;set;}

        ///<summary>
        ///离开信息
        /// </summary>
        public string str_DepInfo {get;set;}

        ///<summary>
        ///送机
        /// </summary>
        public string str_DepCar {get;set;}

        ///<summary>
        ///送机价格
        /// </summary>
        public decimal? dec_DepRate {get;set;}

        ///<summary>
        ///是否退房  0 退房 其他为在住
        /// </summary>
        public string str_extra {get;set;}

        ///<summary>
        ///费用
        /// </summary>
        public decimal? dec_charge {get;set;}

        ///<summary>
        ///款项
        /// </summary>
        public decimal? dec_credit {get;set;}

        ///<summary>
        ///信用
        /// </summary>
        public decimal? dec_accredit {get;set;}

        ///<summary>
        ///特殊要求id
        /// </summary>
        public string str_srqs {get;set;}

        ///<summary>
        ///客房布置
        /// </summary>
        public string str_amenities {get;set;}

        ///<summary>
        ///主账号
        /// </summary>
        public string str_parentAccnt {get;set;}

        ///<summary>
        ///客房资源标记
        /// </summary>
        public string str_saccnt {get;set;}

        ///<summary>
        ///联房(主账号)
        /// </summary>
        public string str_pcrec {get;set;}

        ///<summary>
        ///联房包价
        /// </summary>
        public string str_pcrec_pkg {get;set;}

        ///<summary>
        ///预订号
        /// </summary>
        public string str_ResNo {get;set;}

        ///<summary>
        ///中央预定号
        /// </summary>
        public string str_Crsno {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_memo {get;set;}

        ///<summary>
        ///结帐提示
        /// </summary>
        public string str_comsg {get;set;}

        ///<summary>
        ///卡号
        /// </summary>
        public string str_CardID {get;set;}

        ///<summary>
        ///销售员
        /// </summary>
        public string str_saleid {get;set;}

        ///<summary>
        ///佣金码
        /// </summary>
        public string str_cmscode {get;set;}

        ///<summary>
        ///Ing_Fk_VipID
        /// </summary>
        public int? Ing_Fk_VipID {get;set;}

        ///<summary>
        ///Ing_Fk_VipCardID
        /// </summary>
        public int? Ing_Fk_VipCardID {get;set;}

        ///<summary>
        ///str_VipCard
        /// </summary>
        public string str_VipCard {get;set;}

        ///<summary>
        ///预订人
        /// </summary>
        public string str_resby {get;set;}

        ///<summary>
        ///预订时间
        /// </summary>
        public DateTime? dt_restime {get;set;}

        ///<summary>
        ///登记人
        /// </summary>
        public string str_ciby {get;set;}

        ///<summary>
        ///登记时间
        /// </summary>
        public DateTime? dt_citime {get;set;}

        ///<summary>
        ///结算人
        /// </summary>
        public string str_coby {get;set;}

        ///<summary>
        ///结算时间
        /// </summary>
        public DateTime? dt_cotime {get;set;}

        ///<summary>
        ///离店操作人
        /// </summary>
        public string str_depby {get;set;}

        ///<summary>
        ///离店操作时间
        /// </summary>
        public DateTime? dt_deptime {get;set;}

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modify {get;set;}

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_ModifyTime {get;set;}

        ///<summary>
        ///特征
        /// </summary>
        public string str_feature {get;set;}

        ///<summary>
        ///入住类型
        /// </summary>
        public string str_InterType {get;set;}

        ///<summary>
        ///保密
        /// </summary>
        public string str_secret {get;set;}

        ///<summary>
        ///类别
        /// </summary>
        public string str_Cusclass {get;set;}

        ///<summary>
        ///str_pcrecaccnt
        /// </summary>
        public string str_pcrecaccnt {get;set;}

        ///<summary>
        ///是否有借用（Y是N不是）
        /// </summary>
        public int? Borrowing {get;set;}

        ///<summary>
        ///原房类
        /// </summary>
        public string str_Oldrmtype {get;set;}

        ///<summary>
        ///退房营业日期
        /// </summary>
        public DateTime? dt_OutBdate {get;set;}

        ///<summary>
        ///策略号
        /// </summary>
        public int? Ing_Fk_Policyid {get;set;}

        ///<summary>
        ///str_rsvno
        /// </summary>
        public string str_rsvno {get;set;}

        ///<summary>
        ///str_ptrv
        /// </summary>
        public string str_ptrv {get;set;}

        ///<summary>
        ///str_Owned
        /// </summary>
        public string str_Owned {get;set;}

        ///<summary>
        ///str_Owner
        /// </summary>
        public string str_Owner {get;set;}

        ///<summary>
        ///dt_CancelTime
        /// </summary>
        public DateTime? dt_CancelTime {get;set;}

        ///<summary>
        ///Ing_IsVflag
        /// </summary>
        public int? Ing_IsVflag {get;set;}

        ///<summary>
        ///79元特权
        /// </summary>
        public int? Ing_IsTq {get;set;}

        ///<summary>
        ///Ing_IsLock
        /// </summary>
        public int? Ing_IsLock {get;set;}

        ///<summary>
        ///str_FConFirm
        /// </summary>
        public string str_FConFirm {get;set;}

        ///<summary>
        ///dt_FConFirmTime
        /// </summary>
        public DateTime? dt_FConFirmTime {get;set;}

        ///<summary>
        ///Ing_IsHour
        /// </summary>
        public int? Ing_IsHour {get;set;}

        ///<summary>
        ///Ing_hideonWechat
        /// </summary>
        public int? Ing_hideonWechat {get;set;}

        /// <summary>
        /// 早餐份数
        /// </summary>
        public int? Ing_breakfast { get; set; }


        /// <summary>
        /// 档案号
        /// </summary>
        public string str_CustomerNo { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string str_mobile { get; set; }


        /// <summary>
        /// 是否开具发票
        /// </summary>
        public int Ing_IsInvoice { get; set; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string str_StoreName { get; set; }

    }
}