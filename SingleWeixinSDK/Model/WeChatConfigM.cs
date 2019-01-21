using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 单体版微信配置类   T_WeChat_Config
    /// </summary>
    
    public class WeChatConfigM
    {
        /// <summary>
        /// 主键
        /// </summary>
       
        public int Ing_Pk_ID { get; set; }
        /// <summary>
        /// 数据库ID
        /// </summary>
        
        public int Ing_Fk_DbID { get; set; }
        /// <summary>
        /// 酒店ID
        /// </summary>
        
        public int Ing_Fk_SPkID { get; set; }
        /// <summary>
        /// 门店名
        /// </summary>
        
        public string str_StoreName { get; set; }
        /// <summary>
        /// 公众号名称
        /// </summary>
        
        public string str_name { get; set; }
        /// <summary>
        /// 公众号加密token
        /// </summary>
        
        public string str_Token { get; set; }
        /// <summary>
        /// 公众号加密key
        /// </summary>
        
        public string str_EncodingAESKey { get; set; }
        /// <summary>
        /// 公众号appid
        /// </summary>
        
        public string str_AppID { get; set; }
        /// <summary>
        /// 公众号secret
        /// </summary>
        
        public string str_AppSecret { get; set; }
        /// <summary>
        /// 用于微信支付的PartnerKey
        /// </summary>
        
        public string str_PartnerKey { get; set; }
        /// <summary>
        /// 用于微信支付的商户号
        /// </summary>
        
        public string str_mch_id { get; set; }
        /// <summary>
        /// 用于微信支付的设备号
        /// </summary>
        
        public string str_device_info { get; set; }
        /// <summary>
        /// 绑定成功通知
        /// </summary>
        
        public string str_ModelIDBind { get; set; }
        /// <summary>
        /// 支付房费成功
        /// </summary>
        
        public string str_ModelIDPay { get; set; }
        /// <summary>
        /// 预订成功
        /// </summary>
        
        public string str_ModelIDOrder { get; set; }
        /// <summary>
        /// 取消预订
        /// </summary>
        
        public string str_ModelIDCancel { get; set; }
        /// <summary>
        /// 问题咨询处理进度提醒
        /// </summary>
        
        public string str_ModelIDQuestion { get; set; }
        /// <summary>
        /// 客户主体储值余额变动提醒
        /// </summary>
        
        public string str_ModelIDCharge { get; set; }
        /// <summary>
        /// 储值会员一天三单以上的订单提醒
        /// </summary>
        
        public string str_ModelIDThreeOrder { get; set; }
        /// <summary>
        /// 离店通知
        /// </summary>
        
        public string str_ModelIDLeave { get; set; }
        /// <summary>
        /// 入住提醒
        /// </summary>
        
        public string str_ModelIDCheckIn { get; set; }
        /// <summary>
        /// 用于微信支付的服务端IP地址
        /// </summary>
        
        public string str_spbill_create_ip { get; set; }
        /// <summary>
        /// 是否开启微信JS接口
        /// </summary>
        
        public int Ing_OpenJSSDK { get; set; }
        /// <summary>
        /// 短信地址
        /// </summary>
        
        public string str_SMSURL { get; set; }


        /// <summary>
        /// Api证书密码
        /// </summary>
        public string str_CertPwd { get; set; }
        /// <summary>
        /// 钟点房开始时间
        /// </summary>
        
        public int Ing_HourStart { get; set; }
        /// <summary>
        /// 钟点房结束时间
        /// </summary>
        
        public int Ing_HourEnd { get; set; }
        /// <summary>
        /// 是否删除（0：已删除，1：有效）
        /// </summary>
        
        public int is_Deleted { get; set; }
        /// <summary>
        /// 产生时间
        /// </summary>
        
        public DateTime dt_CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        
        public DateTime dt_ModifyTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        
        public string str_Modify { get; set; }



    }
    public class WeChatFileM
    {
        public int Ing_PK_FileID { get; set; }
        public int Ing_FK_ID { get; set; }

        public string str_StoreName { get; set; }
        public int Ing_Fk_SPkID { get; set; }
        public int Ing_Type { get; set; }
        public string str_FileName { get; set; }
        public string str_FileExt { get; set; }
        public string str_FileUrl { get; set; }
        public int is_Deleted { get; set; }
        public DateTime dt_CreateTime { get; set; }
        public DateTime dt_ModifyTime { get; set; }
        public string str_Modify { get; set; }
    }
}
