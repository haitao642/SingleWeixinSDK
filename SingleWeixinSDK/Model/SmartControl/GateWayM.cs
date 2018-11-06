using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SmartControl
{
    /// <summary>
    /// 网关model
    /// </summary>
    public class GateWayM
    {
        /// <summary>
        /// 网关id
        /// </summary>
        public string gateway_id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string nickname { get; set; }
        /// <summary>
        /// 是否在线 	1：在线，0：不在线
        /// </summary>
        public int online { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string init_time { get; set; }
    }
    /// <summary>
    /// 网关接口返回的数据
    /// </summary>
    public class GateWayResponseM
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
        /// 网关列表
        /// </summary>
        public List<GateWayM> info { get; set; }
    }
    /// <summary>
    /// 请求参数
    /// </summary>
    public class GateWayRequestM
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
        /// 酒店id
        /// </summary>
        public int hotelid { get; set; }
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
        public override string ToString()
        {
            return "start="+start+ "&pageCount=" + pageCount + "&hotelid=" + hotelid + "&room=" + room;
        }
    }
}
