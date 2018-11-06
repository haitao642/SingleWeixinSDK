using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Store_Info
    /// </summary>
    public class StoreInfoM
    {
        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///str_GroupCmpyID
        /// </summary>
        public string str_GroupCmpyID {get;set;}

        ///<summary>
        ///酒店代号
        /// </summary>
        public string str_StoreNo {get;set;}

        ///<summary>
        ///分店对应NC接口账号
        /// </summary>
        public string str_StoreNoForNC {get;set;}

        ///<summary>
        ///分店简称
        /// </summary>
        public string str_StoreName {get;set;}

        ///<summary>
        ///分店简称首字母
        /// </summary>
        public string str_StoreNameEng {get;set;}

        ///<summary>
        ///分店全称
        /// </summary>
        public string str_StoreFullName {get;set;}

        ///<summary>
        ///分店英文名
        /// </summary>
        public string str_StoreFullNameEng {get;set;}

        ///<summary>
        ///地址
        /// </summary>
        public string str_Address {get;set;}

        ///<summary>
        ///邮编
        /// </summary>
        public string str_Zip {get;set;}

        ///<summary>
        ///网址
        /// </summary>
        public string str_Website {get;set;}

        ///<summary>
        ///电邮
        /// </summary>
        public string str_email {get;set;}

        ///<summary>
        ///传真
        /// </summary>
        public string str_FAX {get;set;}

        ///<summary>
        ///负责人（店长）店经理
        /// </summary>
        public string str_chargeName {get;set;}

        ///<summary>
        ///店长座机
        /// </summary>
        public string str_chargePhone {get;set;}

        ///<summary>
        ///店长手机
        /// </summary>
        public string str_chargeMobil {get;set;}

        ///<summary>
        ///服务电话
        /// </summary>
        public string str_hotTel {get;set;}

        ///<summary>
        ///所在区域（华东、华南）
        /// </summary>
        public string str_Region {get;set;}

        ///<summary>
        ///省份
        /// </summary>
        public string str_Provinces {get;set;}

        ///<summary>
        ///城市
        /// </summary>
        public string str_city {get;set;}

        ///<summary>
        ///区/县
        /// </summary>
        public string str_district {get;set;}

        ///<summary>
        ///城市等级(A类，B类..)
        /// </summary>
        public string str_SLevel {get;set;}

        ///<summary>
        ///地段
        /// </summary>
        public string str_area {get;set;}

        ///<summary>
        ///品牌
        /// </summary>
        public string str_brand {get;set;}

        ///<summary>
        ///连锁类型(直营,加盟)
        /// </summary>
        public string str_InnType {get;set;}

        ///<summary>
        ///管理性质（直营，加盟管理，共同管理）
        /// </summary>
        public string str_MangerType {get;set;}

        ///<summary>
        ///商圈
        /// </summary>
        public string str_CBD {get;set;}

        ///<summary>
        ///门店面积
        /// </summary>
        public string str_squaremeter {get;set;}

        ///<summary>
        ///状态（启用，注销）（1，0）
        /// </summary>
        public int? Ing_State {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_memo {get;set;}

        ///<summary>
        ///财务编号
        /// </summary>
        public string str_FinancialNO {get;set;}

        ///<summary>
        ///业务电话
        /// </summary>
        public string str_ServerTel {get;set;}

        ///<summary>
        ///业务传真
        /// </summary>
        public string str_ServerFax {get;set;}

        ///<summary>
        ///业务联系人
        /// </summary>
        public string str_ServerPerson {get;set;}

        ///<summary>
        ///送货到火车站
        /// </summary>
        public string str_TrainStation {get;set;}

        ///<summary>
        ///开户银行
        /// </summary>
        public string str_bank {get;set;}

        ///<summary>
        ///开户名称
        /// </summary>
        public string str_bankAccount {get;set;}

        ///<summary>
        ///银行账号
        /// </summary>
        public string str_bankNO {get;set;}

        ///<summary>
        ///税号
        /// </summary>
        public string str_tariffline {get;set;}

        ///<summary>
        ///营业时间
        /// </summary>
        public string str_BusinessHours {get;set;}

        ///<summary>
        ///建店日期
        /// </summary>
        public string str_CreatStore {get;set;}

        ///<summary>
        ///试营业日期
        /// </summary>
        public string str_SoftOpening {get;set;}

        ///<summary>
        ///验收人
        /// </summary>
        public string str_Acceptor {get;set;}

        ///<summary>
        ///验收日期
        /// </summary>
        public string str_AccepTime {get;set;}

        ///<summary>
        ///保证金
        /// </summary>
        public string str_Margin {get;set;}

        ///<summary>
        ///法人
        /// </summary>
        public string str_legalperson {get;set;}

        ///<summary>
        ///行业资质
        /// </summary>
        public string str_Aptitudes {get;set;}

        ///<summary>
        ///解约日期
        /// </summary>
        public string str_cancellation {get;set;}

        ///<summary>
        ///发票类别
        /// </summary>
        public string str_invType {get;set;}

        ///<summary>
        ///中心库1
        /// </summary>
        public string str_CenterStorage {get;set;}

        ///<summary>
        ///中心库2
        /// </summary>
        public string str_CenterStorage1 {get;set;}

        ///<summary>
        ///中心库3
        /// </summary>
        public string str_CenterStorage2 {get;set;}

        ///<summary>
        ///门店对应的供应商列表
        /// </summary>
        public string str_FK_SupIdStr {get;set;}

        ///<summary>
        ///管理费
        /// </summary>
        public decimal? Maintenance {get;set;}

        ///<summary>
        ///管理费率
        /// </summary>
        public decimal? tariff {get;set;}

        ///<summary>
        ///促销奖励资金
        /// </summary>
        public decimal? award {get;set;}

        ///<summary>
        ///促销奖励资金百分比
        /// </summary>
        public decimal? awardpcnt {get;set;}

        ///<summary>
        ///调级日期
        /// </summary>
        public string str_tunedstageDate {get;set;}

        ///<summary>
        ///调级后的费用
        /// </summary>
        public decimal? tunedstageFee {get;set;}

        ///<summary>
        ///调级后的管理费率
        /// </summary>
        public decimal? tunedstagetariff {get;set;}

        ///<summary>
        ///门店等级
        /// </summary>
        public string str_StoreGrade {get;set;}

        ///<summary>
        ///收货地址
        /// </summary>
        public string str_ReceiveAddr {get;set;}

        ///<summary>
        ///收货单位
        /// </summary>
        public string str_ReceiveUnit {get;set;}

        ///<summary>
        ///收货邮编
        /// </summary>
        public string str_ReceiveZip {get;set;}

        ///<summary>
        ///收货传真
        /// </summary>
        public string str_ReceiveFax {get;set;}

        ///<summary>
        ///收货人
        /// </summary>
        public string str_Receiver {get;set;}

        ///<summary>
        ///收货人电子邮件
        /// </summary>
        public string str_ReceiverEmail {get;set;}

        ///<summary>
        ///收货人座机
        /// </summary>
        public string str_ReceiverPhone {get;set;}

        ///<summary>
        ///收货人手机
        /// </summary>
        public string str_ReceiverMobile {get;set;}

        ///<summary>
        ///主要界面房态图
        /// </summary>
        public int? Ing_fK_RSRID {get;set;}

        ///<summary>
        ///正常入住时间（开张时间）
        /// </summary>
        public string str_OpenTime {get;set;}

        ///<summary>
        ///默认退房时间
        /// </summary>
        public string str_CloseTime {get;set;}

        ///<summary>
        ///入住后几小时收费
        /// </summary>
        public string str_HrFee {get;set;}

        ///<summary>
        ///押金默认数
        /// </summary>
        public decimal? deposit {get;set;}

        ///<summary>
        ///信用授权金额
        /// </summary>
        public decimal? DepositCredit {get;set;}

        ///<summary>
        ///允许有钟点房(0:没有 1:有)
        /// </summary>
        public int? IsHrsRm {get;set;}

        ///<summary>
        ///修改说明
        /// </summary>
        public string str_ModifyMark {get;set;}

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modify {get;set;}

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_ModifyTime {get;set;}

        ///<summary>
        ///str_StateExc
        /// </summary>
        public string str_StateExc {get;set;}

        ///<summary>
        ///str_Zcode
        /// </summary>
        public string str_Zcode {get;set;}

        /// <summary>
        /// 是否开启公安上传功能
        /// </summary>
        public int Ing_policeSta { get; set; }

        /// <summary>
        /// 公安上传用户名
        /// </summary>
        public string str_policeusername { get; set; }

        /// <summary>
        /// 公安上传密码
        /// </summary>
        public string str_policepassword { get; set; }

        /// <summary>
        /// 公安上传地址
        /// </summary>
        public string str_policeurl { get; set; }

        /// <summary>
        /// 公安上传的旅馆编号
        /// </summary>
        public string str_policeno { get; set; }

        /// <summary>
        /// 标识需要几点钟夜审的
        /// </summary>
        public int Ing_AuditHour { get; set; }


        /// <summary>
        /// 夜审后是否执行了交班,1表示未交班，0表示已经交班
        /// </summary>
        public int Ing_AfterAuditChangeRank { get; set; }

        
    }


    /// <summary>
    /// 门店列表
    /// </summary>
    public class StoreM
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }


        /// <summary>
        /// 门店名称 
        /// </summary>
        public string str_StoreName { get; set; }


        /// <summary>
        /// 门店全称 
        /// </summary>
        public string str_StoreFullName { get; set; }

        /// <summary>
        /// 区 
        /// </summary>
        public string str_district { get; set; }

        /// <summary>
        ///城市
        /// </summary>
        public string str_city { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string str_Address { get; set; }


        /// <summary>
        /// 最低的价格
        /// </summary>
        public decimal VipPrice { get; set; }


        ///<summary>
        /// 纬度
        /// </summary>
        public string str_port_y { get; set; }

        ///<summary>
        ///经度
        /// </summary>
        public string str_port_x { get; set; }

        /// <summary>
        /// 距离
        /// </summary>
        public decimal distance { get; set; }

        /// <summary>
        /// 门店图片
        /// </summary>
        public string headerimg { get; set; }

        /// <summary>
        /// 停车场标记
        /// </summary>
        public int Ing_Park { get; set; }


        /// <summary>
        /// wifi标记
        /// </summary>
        public int Ing_wifi { get; set; }
        /// <summary>
        /// 餐饮
        /// </summary>
        public int Ing_Restaurant { get; set; }


        ///<summary>
        ///预定电话
        /// </summary>
        public string str_hotTel { get; set; }


        public string str_LockStoreNo { get; set; }

        /// <summary>
        /// 短信余额数量
        /// </summary>
        public int Ing_SmsNumber { get; set; }
    }


    /// <summary>
    /// 门店
    /// </summary>
    public class StoreListM
    {
        /// <summary>
        /// 统计
        /// </summary>
        public StoreSumM sum { get; set; }

        /// <summary>
        /// 门店列表
        /// </summary>
        public List<StoreM> list { get; set; }
    }


    /// <summary>
    /// 门店信息
    /// </summary>
    public class StoreDetailM
    {
        /// <summary>
        /// 门店id
        /// </summary>
        public int Ing_SotreID { get; set; }

        /// <summary>
        /// 网站根地址
        /// </summary>
        public string Webroot { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int lngvipcardid { get; set; }

        /// <summary>
        /// 来期
        /// </summary>
        public DateTime dtArr { get; set; }

        /// <summary>
        /// 离期
        /// </summary>
        public DateTime dtDept { get; set; }

        /// <summary>
        /// 旅游信息
        /// </summary>
        public string strtour { get; set; }

        /// <summary>
        /// 商场
        /// </summary>
        public string strmarket { get; set; }

        /// <summary>
        /// 医疗
        /// </summary>
        public string strhospital { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        public string strbank { get; set; }


        /// <summary>
        /// 美食
        /// </summary>
        public string strdiet { get; set; }

        /// <summary>
        /// 头上的第一张图片
        /// </summary>
        public string strtopImg { get; set; }


        /// <summary>
        /// 交通
        /// </summary>
        public string strtraffic { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public StoreDetailInfoM detailM { get; set; }


        /// <summary>
        /// 门店信息
        /// </summary>
        public StoreInfoM infoM { get; set; }

        /// <summary>
        /// 房型列表
        /// </summary>
        public List<FitReservationM> RoomtypeList { get; set; }

        /// <summary>
        /// 门店图片
        /// </summary>
        public List<StoreImgM> StoreImgList { get; set; }


        /// <summary>
        /// 评论列表
        /// </summary>
        public List<UserCommentsM> commentList { get; set; }


    
    }
    /// <summary>
    /// 
    /// </summary>
    public class OutStoreInfoM
    {
        ///<summary>
        ///Ing_SPkID
        /// </summary>
        public int Ing_SPkID { get; set; }

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID { get; set; }

        ///<summary>
        ///酒店代号
        /// </summary>
        public string str_StoreNo { get; set; }

        ///<summary>
        ///分店简称
        /// </summary>
        public string str_StoreName { get; set; }

        ///<summary>
        ///分店简称首字母
        /// </summary>
        public string str_StoreNameEng { get; set; }

        ///<summary>
        ///分店全称
        /// </summary>
        public string str_StoreFullName { get; set; }

        ///<summary>
        ///分店英文名
        /// </summary>
        public string str_StoreFullNameEng { get; set; }


        ///<summary>
        ///状态（启用，注销）（1，0）
        /// </summary>
        public int? Ing_State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int? Ing_fk_DbID { get; set; }
        public virtual string DbName { get; set; }
        public virtual int Ing_Pk_ServerID { get; set; }
        public virtual string ServerName { get; set; }
        public virtual int Ing_Pk_SqlID { get; set; }
        public virtual string SqlName { get; set; }
        /// <summary>
        /// 数据库登陆名称
        /// </summary>
        public string SqlUid { get; set; }
        /// <summary>
        /// 数据库登陆密码
        /// </summary>
        public string SqlPwd { get; set; }
        /// <summary>
        /// 数据库类型(sql server;orcal...)
        /// </summary>
        public string SqlType { get; set; }

        /// <summary>
        /// 访问服务器网址
        /// </summary>
        public string HttpUrl { get; set; }
    }
    public class RequestParamModel
    {
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string SqlName { get; set; }

        /// <summary>
        /// 库名称
        /// </summary>
        public string DbName { get; set; }

        /// <summary>
        /// 传入值
        /// </summary>
        public string ObjectKey { get; set; }
    }

}