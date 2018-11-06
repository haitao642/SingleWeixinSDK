using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SmartControl
{
    public class AirStatusInfoM
    {
        public AirStatusM info { get; set; }
    }
    /// <summary>
    /// 空调状态
    /// </summary>
    public class AirStatusM
    {
        /// <summary>
        /// 当前的keyid
        /// </summary>
        public int key_id { get; set; }
        /// <summary>
        /// power状态,"ON":开,"OFF":关
        /// </summary>
        public string stPower { get; set; }
        /// <summary>
        /// 风扇状态,"FAN AUTO":自动,"FAN LOW":低速,"FAN MID":中速,"FAN HI":高速
        /// </summary>
        public string stFan { get; set; }
        /// <summary>
        /// 模式状态,"COOL":制冷,"HEAT":制热,"FAN":吹风,"AUTO":自动,"DIY":除湿
        /// </summary>
        public string stMode { get; set; }
        /// <summary>
        /// 温度状态,数值型，范围大概是15-32
        /// </summary>
        public string stTemp { get; set; }
        /// <summary>
        /// 扫风状态,"ON":开,"OFF":关
        /// </summary>
        public string stSwing { get; set; }
    }
    /// <summary>
    /// 空调状态接口返回参数
    /// </summary>
    public class AirStatusResponseM
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
        /// 被控设备(空调设备)状态描述
        /// </summary>
        public AirStatusInfoM info { get; set; }
    }
    /// <summary>
    /// 空调状态接口请求参数
    /// </summary>
    public class AirStatusRequestM
    {
        /// <summary>
        /// 空调状态码
        /// </summary>
        public string param { get; set; }
        /// <summary>
        /// 网关id
        /// </summary>
        public string gatewayid { get; set; }
        /// <summary>
        /// 酒店id
        /// </summary>
        public int hotelid { get; set; }
        /// <summary>
        /// 遥控器id
        /// </summary>
        public int contollerid { get; set; }
        /// <summary>
        /// av和ac类区分 0:av 1:ac
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 遥控器名称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }
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
    }
}
