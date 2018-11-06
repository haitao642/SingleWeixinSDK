using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model.WeiXin
{
    [Serializable]
    public class WeChatConfigM
    {
        //   <ID>7</ID>
        // <Name>泊捷酒店华都店</Name>
        // <!--微信Token-->
        // <Token>i787f58P6Gla44EV51JfvzgG5d445E6</Token>
        // <!--微信消息体加密对应的EncodingAESKey-->
        // <EncodingAESKey>EPtyFwqgACaVlMthN8CFO7o2ShEOlsp1A6XZEyGfFAk</EncodingAESKey>
        // <!--微信AppId-->
        // <AppID>wxf7bd3c3f942fcfee</AppID>
        // <!--微信AppSecret-->
        // <AppSecret>f1a2c5742a9b705ca7b2683784cc56e9</AppSecret>
        // <!--用于微信支付的PartnerKey-->
        // <PartnerKey>F6EF67A613924A1590AB5E9618CAC225</PartnerKey>
        // <!--用于微信支付的商户号-->
        // <mch_id>1315231901</mch_id>
        // <!--用于微信支付的设备号-->
        // <device_info></device_info>
        // <!--用于微信支付的服务端IP地址-->
        // <spbill_create_ip></spbill_create_ip>
        // <!--微信Oauth: 
        //snsapi_base:      不弹出授权页面，直接跳转，只能获取用户openid;
        //snsapi_userinfo:  出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息.-->
        // <OauthScope>snsapi_userinfo</OauthScope>
        // <!--是否开启微信JS接口，1：开启，0：不开启（由于开启JS功能需要定时获取jstickect,会消耗一部分性能，所以不需要JS接口的请写0）-->
        // <OpenJSSDK>1</OpenJSSDK>
        // <!--短信配置-->
        // <SMSURL></SMSURL>
        /// <summary>
        /// 门店ID
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public int ID { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// 微信Token
        /// </summary>
        [XmlAttribute(AttributeName = "Token")]
        public string Token { get; set; }
        /// <summary>
        /// 微信消息体加密对应的EncodingAESKey
        /// </summary>
        [XmlAttribute(AttributeName = "EncodingAESKey")]
        public string EncodingAESKey { get; set; }
        /// <summary>
        /// 微信AppId
        /// </summary>
        [XmlAttribute(AttributeName = "AppID")]
        public string AppID { get; set; }
        /// <summary>
        /// 微信AppSecret
        /// </summary>
        [XmlAttribute(AttributeName = "AppSecret")]
        public string AppSecret { get; set; }
        /// <summary>
        /// 用于微信支付的PartnerKey
        /// </summary>
        [XmlAttribute(AttributeName = "PartnerKey")]
        public string PartnerKey { get; set; }
        /// <summary>
        /// 用于微信支付的商户号
        /// </summary>
        [XmlAttribute(AttributeName = "mch_id")]
        public string mch_id { get; set; }
        /// <summary>
        /// 用于微信支付的设备号
        /// </summary>
        [XmlAttribute(AttributeName = "device_info")]
        public string device_info { get; set; }
        /// <summary>
        /// 用于微信支付的服务端IP地址
        /// </summary>
        [XmlAttribute(AttributeName = "spbill_create_ip")]
        public string spbill_create_ip { get; set; }
        /// <summary>
        /// 微信Oauth: 
        ///snsapi_base:      不弹出授权页面，直接跳转，只能获取用户openid;
        ///snsapi_userinfo:  出授权页面，可通过openid拿到昵称、性别、所在地。并且，即使在未关注的情况下，只要用户授权，也能获取其信息.
        /// </summary>
        [XmlAttribute(AttributeName = "OauthScope")]
        public string OauthScope { get; set; }
        /// <summary>
        /// 是否开启微信JS接口，1：开启，0：不开启（由于开启JS功能需要定时获取jstickect,会消耗一部分性能，所以不需要JS接口的请写0）
        /// </summary>
        [XmlAttribute(AttributeName = "OpenJSSDK")]
        public int OpenJSSDK { get; set; }
        /// <summary>
        /// 短信配置
        /// </summary>
        [XmlAttribute(AttributeName = "SMSURL")]
        
        public string SMSURL { get; set; }
        /// <summary>
        /// 钟点房开始时间
        /// </summary>
        [XmlAttribute(AttributeName = "HourStart")]
        public int HourStart { get; set; }
        /// <summary>
        /// 钟点房结束时间
        /// </summary>
        [XmlAttribute(AttributeName = "HourEnd")]
        public int HourEnd { get; set; }
    }
}
