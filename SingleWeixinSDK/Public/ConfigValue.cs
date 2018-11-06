using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    public static class ConfigValue
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="s"></param>
        /// <param name="_input_charset"></param>
        /// <returns></returns>
        public static string GetMD5_32(string s, string _input_charset = "utf-8")
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 取appsetting里的值
        /// </summary>
        /// <param name="appkey"></param>
        /// <returns></returns>
        public static string GetValue(string appkey)
        {
            try
            {
                string rev = ConfigurationManager.AppSettings[appkey].ToString().Trim();
                return rev;
            }
            catch
            {

            }
            return string.Empty;
        }

        public static string SMSURL
        {
            get
            {
                return GetValue("SMSURL");
            }
        }
        /// <summary>
        /// 数据库链接串
        /// </summary>
        public static string ConnectString
        {
            get
            {
                return GetValue("ConnectionString");
            }
        }

        /// <summary>
        /// 微信数据库链接串
        /// </summary>
        public static string ConnectionStringBJWeChat
        {
            get
            {
                return GetValue("ConnectionStringBJWeChat");
            }
        }
        /// <summary>
        /// 服务器IP
        /// </summary>
        public static string ServerIP
        {
            get
            {
                return GetValue("ServerIP");
            }
        }
        /// <summary>
        /// 数据库名
        /// </summary>
        public static string DataBaseName
        {
            get
            {
                return GetValue("DataBaseName");
            }
        }
        /// <summary>
        /// 总后端接口地址
        /// </summary>
        public static string TotalServerUrl
        {
            get
            {
                return GetValue("TotalServerUrl");
            }
        }
        /// <summary>
        /// 智能酒店接口地址
        /// </summary>
        public static string SmartControlServerUrl
        {
            get
            {
                return GetValue("SmartControlServerUrl");
            }
        }
        /// <summary>
        /// 智能遥控器活动代码
        /// </summary>
        public static string SHActivity
        {
            get
            {
                return GetValue("SHActivity");
            }
        }
        /// <summary>
        /// 数据库错误，是否写日志
        /// </summary>
        public static bool DBLogErrors
        {
            get
            {
                string DBLogErrors = GetValue("DBLogErrors");
                return DBLogErrors.ToLower().Trim().Equals("true");
            }
        }

        /// <summary>
        /// 数据库错误的日志文件
        /// </summary>
        public static string DBLogName
        {
            get
            {
                return GetValue("DBLogName");
            }
        }


        /// <summary>
        /// 是否跟踪sql
        /// </summary>
        public static bool DBLogSQL
        {
            get
            {
                string DBLogErrors = GetValue("DBLogSQL");
                return DBLogErrors.ToLower().Trim().Equals("true");
            }
        }

        /// <summary>
        /// 跟踪sql的日志文件
        /// </summary>
        public static string DBLogSQLName
        {
            get
            {
                return GetValue("DBLogSQLName");
            }
        }

        /// <summary>
        /// 程序错误的日志文件
        /// </summary>
        public static string AppLogName
        {
            get
            {
                return GetValue("AppLogName");
            }
        }

        /// <summary>
        /// 业务逻辑，是否写日志
        /// </summary>
        public static bool DBAppErrors
        {
            get
            {
                string DBAppErrors = GetValue("DBAppErrors");
                return DBAppErrors.ToLower().Trim().Equals("true");
            }
        }

        /// <summary>
        /// 域名
        /// </summary>
        public static string GetDomain
        {
            get
            {
                return GetValue("Domain");
            }
        }


        /// <summary>
        /// 必须绑定会员才能操作的菜单
        /// </summary>
        public static List<string> GetFuncNeedBind
        {
            get
            {
                string rev = GetValue("FuncNeedBind").ToLower();
                return rev.Split(',').ToList();
            }
        }

        /// <summary>
        /// 网站域名，主要用来取酒店图片
        /// </summary>
        public static string GetWebroot
        {
            get
            {
                string url = GetValue("Webroot");
                if (!url.EndsWith("/")) url = string.Format("{0}/", url);
                return url;
            }
        }

        /// <summary>
        /// 常用城市
        /// </summary>
        public static string GetCommcity
        {
            get
            {
                return GetValue("Commcity");
            }
        }


        /// <summary>
        /// 测试用的openid,如果不为空，表示正式用的
        /// </summary>
        public static string GetOpenid
        {
            get
            {
                return GetValue("openid");
            }
        }

        /// <summary>
        /// 微信创建会员卡时的会员卡类型
        /// </summary>
        public static int GetCardTypeID
        {
            get
            {
                string rev = GetValue("CardTypeID");
                int typeid = 0;
                int.TryParse(rev, out typeid);
                return typeid;
            }
        }

        /// <summary>
        /// 如果为1，绑定的时候，可以随便输入验证码
        /// </summary>
        public static int VerifyCodeDebug
        {
            get
            {
                string rev = GetValue("VerifyCodeDebug");
                int typeid = 0;
                int.TryParse(rev, out typeid);
                return typeid;
            }
        }

        /// <summary>
        /// 如果为1， 微信支付的时候，支付1分
        /// </summary>
        public static int WxPayDebug
        {
            get
            {
                string rev = GetValue("WxPayDebug");
                int typeid = 0;
                int.TryParse(rev, out typeid);
                return typeid;
            }
        }


        /// <summary>
        /// AppID       
        /// </summary>
        /// <returns></returns>
        public static string AppID
        {
            get
            {
                return GetValue("AppID");
            }
        }


        /// <summary>
        /// AppSecret       
        /// </summary>
        /// <returns></returns>
        public static string AppSecret
        {
            get
            {
                return GetValue("AppSecret");
            }
        }
        public static string SmsAccount
        {
            get
            {
                return GetValue("SmsAccount");
            }
        }
        public static string SmsPwd
        {
            get
            {
                return GetValue("SmsPwd");
            }
        }
        /// <summary>
        /// 每条短信的字数
        /// </summary>
        public static int SMSLEN
        {
            get
            {
                int SMSLEN = 0;
                int.TryParse(GetValue("SMSLEN"), out SMSLEN);
                if (SMSLEN <= 0) SMSLEN = 100;
                return SMSLEN;
            }
        }

        /// <summary>
        /// 积分兑换抵用券的活动代码
        /// </summary>
        public static string WeChatCard
        {
            get
            {
                return GetValue("WeChatCard");
            }
        }


        /// <summary>
        /// 二维码绝对路径
        /// </summary>
        public static string QRcodePath
        {
            get
            {
                return GetValue("QRcodePath");
            }
        }

        /// <summary>
        /// 二维码相对路径
        /// </summary>
        public static string QRcodeUrl
        {
            get
            {
                return GetValue("QRcodeUrl");
            }
        }

        /// <summary>
        /// 几点之前来，算的房晚加一晚
        /// </summary>
        public static int AddOneNightHour
        {
            get
            {
                string rev = GetValue("AddOneNightHour");
                int AddOneNightHour = 0;
                int.TryParse(rev, out AddOneNightHour);
                return AddOneNightHour;
            }
        }

        /// <summary>
        /// 分享返佣的金额
        /// </summary>
        public static int ShareReturnMon
        {
            get
            {
                string rev = GetValue("ShareReturnMon");
                int ShareReturnMon = 0;
                int.TryParse(rev, out ShareReturnMon);
                return ShareReturnMon;
            }
        }

        /// <summary>
        /// 获取商城签名key
        /// </summary>
        public static string ShopKey
        {
            get
            {
                return GetValue("ShopKey");
            }
        }

        /// <summary>
        /// 获取微信推送消息的modelid
        /// </summary>
        /// <param name="type">1:绑定成功通知
        /// 2:支付房费成功
        /// 3:预订成功
        /// 4:取消预订
        /// 5:问题咨询处理进度提醒  客人与店长在评价方面的互动
        /// 6:客户主体储值余额变动提醒 
        /// 7:储值会员一天三单以上的订单提醒，会员提醒
        /// 8:离店通知
        /// 9：入住提醒
        /// </param>
        /// <returns></returns>
        public static string ModelID(int type)
        {
            //string rev = GetValue("WechatType");
            ///公众平台类型  0：泊捷   1：泊友会
            int WechatType = 0;
            //int.TryParse(rev, out WechatType);

            Dictionary<string, string> dict = new Dictionary<string, string>();

            ///泊捷的
            dict["key1-0"] = "npfFYrauiVIGOd3JEJNPMRyduqRlzoci6VjdxximjWc";  ///绑定成功通知
            dict["key2-0"] = "6EtrJ9v9tSBKHm909sJg9FMVzAHwcRK4tmooW76VueU";  ///支付房费成功
            dict["key3-0"] = "0lcz2BkOPTBImngFITDwB3Obl5V_RHwoBRGxmbIUV2s";  ///预订成功
            dict["key4-0"] = "4TBCjZKRusyyNbNNmWkn9W620kZwEuC0iaPI6mO1DH4";  ///取消预订
            dict["key5-0"] = "QyfB_Q8rDBgdD7OkrXL9z2Ou6B3C-O873tWecERvSuQ";  ///问题咨询处理进度提醒  客人与店长在评价方面的互动
            dict["key6-0"] = "kUEYvwk4vwMDJlmAfVFXUXoRcV0yYgtPM0WXsoDTa1Y";  ///客户主体储值余额变动提醒 
            dict["key7-0"] = "dqpzs82H6KFe_BUx0F1Ct6S9GqI3ZbEkqd30jtvaALA";  ///储值会员一天三单以上的订单提醒 
            dict["key8-0"] = "zJtiO9cn-bb_qX50YLDAxnUqgF26jA2x8QduLsl086w";  ///离店通知 
            dict["key9-0"] = "pdivADfry6IMeCDbNlgaghS_4tKia96RgHZL_byt9lI";  ///入住提醒

            ///泊友会的
            dict["key1-1"] = "-cg27Aggldn8WqvR8hXxYn89NHxj8Ovn6gv8xb0urbk";  ///绑定成功通知
            dict["key2-1"] = "sAaB5U3-Hez9Fk1NyN0arKqFolOEZ517DWvhmA9UcQE";  ///支付房费成功
            dict["key3-1"] = "D_1o-jHiYWzH0M5YQr8sHVfNH--uJZHFu2Axgp_0GNc";  ///预订成功
            dict["key4-1"] = "O6dXlDYMMgsorJWJicz7pWMD7aCZdH_HU_-lJR7Gjwc";  ///取消预订
            dict["key5-1"] = "VVGZDsyLuIyNaXvsKoU5mB2lbNVF80dtxQtNFWHmiso";  ///问题咨询处理进度提醒  客人与店长在评价方面的互动
            dict["key6-1"] = "KWXeP_EmXzwonRpnWrieQs0SCfKIaylUg43nZM54FaI";  ///客户主体储值余额变动提醒 
            dict["key7-1"] = "0Bk2wW1UMdMa-X2HQIGn9-THawwGFTF5lW_qg9_HLsM";  ///储值会员一天三单以上的订单提醒 
            dict["key8-1"] = "4pv_ZU3L8WzqoTV6h8K32ZKVbNqKqbKZD4NnsSb8U4A";  ///离店通知 
            dict["key9-1"] = "u5LtAdxaBZK31UYQym_GKC-4s9spi1hAzdHpQzlNqTs";  ///入住提醒

            string key = string.Format("key{0}-{1}", type, WechatType);

            if (!dict.ContainsKey(key))
            {
                return string.Empty;
            }

            return dict[key].Trim();
        }


        /// <summary>
        /// 钟点房预订的开始时间， HHmm
        /// </summary>
        public static int HourStart
        {
            get
            {
                string rev = GetValue("HourStart");
                int HourStart = 0;
                int.TryParse(rev, out HourStart);
                return HourStart;
            }
        }

        /// <summary>
        /// 钟点房预订的结束时间， HHmm
        /// </summary>
        public static int HourEnd
        {
            get
            {
                string rev = GetValue("HourEnd");
                int HourEnd = 0;
                int.TryParse(rev, out HourEnd);
                return HourEnd;
            }
        }

        /// <summary>
        /// 活动类型(0,中秋节，1国庆节)
        /// </summary>
        public static string ActivityType
        {
            get
            {
                string rev = GetValue("ActivityType");
                return rev;
            }
        }

    }
}
