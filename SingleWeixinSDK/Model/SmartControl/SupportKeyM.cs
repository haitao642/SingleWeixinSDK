using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace Model.SmartControl
{
    /// <summary>
    /// 
    /// </summary>
    public class SupportKeyM
    {
        /// <summary>
        /// 
        /// </summary>
        public KeyLabel7M keylabel7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SupportKeyM()
        {
            keylabel7 = new KeyLabel7M();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class KeyLabel7M
    {
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> KeyLabel7 = new Dictionary<string, object>();
    }
    /// <summary>
    /// 
    /// </summary>

    /// <summary>
    /// 支持按键接口返回
    /// </summary>
    public class SupportResponseM
    {
        /// <summary>
        /// 接口状态:200,500
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public SupportKeyM info { get; set; }

    }
    /// <summary>
    /// 支持按键接口请求实体
    /// </summary>
    public class SupportRequestM
    {
        /// <summary>
        /// 网关id
        /// </summary>
        public string gatewayid { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public string hotelid { get; set; }
        /// <summary>
        /// 控制器id
        /// </summary>
        public string controllerid { get; set; }
        /// <summary>
        /// 控制器别名
        /// </summary>
        public string str_NickName { get; set; }
        /// <summary>
        /// 档案ID
        /// </summary>
        public int Ing_CustID { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string str_CustName { get; set; }
        /// <summary>
        /// openid
        /// </summary>
        public string str_OpenID { get; set; }
        /// <summary>
        /// 主单号
        /// </summary>
        public int Ing_MasterID { get; set; }
        /// <summary>
        /// av和ac类区分 0:av 1:ac
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "gatewayid=" + gatewayid + "&hotelid=" + hotelid + "&controllerid=" + controllerid;
        }
    }
}
