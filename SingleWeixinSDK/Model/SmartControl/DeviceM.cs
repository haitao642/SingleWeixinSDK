using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SmartControl
{
    /// <summary>
    /// 遥控器model
    /// </summary>
    public class DeviceM
    {
        /// <summary>
        /// 网关id
        /// </summary>
        public string gatewayid { get; set; }
        /// <summary>
        /// 遥控器id
        /// </summary>
        public int controllerid { get; set; }
        /// <summary>
        /// 设备类型,1:电视,0:空调,-3:机顶盒-1：窗帘,-2:音响
        /// </summary>
        public int deviceid { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string time { get; set; }
    }
    /// <summary>
    /// 遥控器接口返回的数据
    /// </summary>
    public class DeviceResponseM
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
        /// 遥控器列表
        /// </summary>
        public List<DeviceM> info { get; set; }
    }
    /// <summary>
    /// 遥控器接口请求参数
    /// </summary>
    public class DeviceRequestM
    {
        /// <summary>
        /// 开始
        /// </summary>
        public int start { get; set; }
        /// <summary>
        /// 个数
        /// </summary>
        public int pageCount { get; set; }
        /// <summary>
        /// 网关id
        /// </summary>
        public string gatewayid { get; set; }
        /// <summary>
        /// 酒店id
        /// </summary>
        public string hotelid { get; set; }
        /// <summary>
        /// 房间id
        /// </summary>
        public string room { get; set; }

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
            return "start=" + start + "&pageCount=" + pageCount + "&gatewayid=" + 
                gatewayid + "&hotelid=" + hotelid ;
        }
    }
}
