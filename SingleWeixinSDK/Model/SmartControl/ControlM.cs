using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SmartControl
{
    /// <summary>
    /// 控制设备界面的model
    /// </summary>
    public class ControlViewM
    {
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
        /// <summary>
        /// /遥控器支持列表
        /// </summary>
        public SupportKeyM response { get; set; }

    }
    /// <summary>
    /// 设备状态描述
    /// </summary>
    public class ControlM
    {
        /// <summary>
        /// 对于匹配模板得到的遥控器的keyid不为1的被控设备(空调设备)状态描述
        /// </summary>
        public string param { get; set; }
    }
    /// <summary>
    /// 控制遥控器接口返回参数
    /// </summary>
    public class ControlResponseM
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
        /// 对于匹配模板得到的遥控器的keyid不为1的被控设备(空调设备)状态描述
        /// </summary>
        public ControlM info { get; set; }

    }
    /// <summary>
    /// 控制遥控器接口请求参数
    /// </summary>
    public class ControlRequestM
    {
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
        /// 按键id
        /// </summary>
        public int keyid { get; set; }
        /// <summary>
        /// 对于当前设备状态的描述,AV类设备不需要关注该值,AC类的非学习设备在使用keyid为1的按键时不需要关注该值,其他按键需要使用返回值中param参数的值
        /// </summary>
        public string param { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "gatewayid=" + gatewayid + "&hotelid=" + hotelid +
                "&controllerid=" + contollerid + "&keyid=" + keyid + "&param=" + param;
        }
    }
    
}
