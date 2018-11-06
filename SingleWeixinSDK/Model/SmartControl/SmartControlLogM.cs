using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SmartControl
{
    /// <summary>
    /// T_SmartControl_Log
    /// </summary>
    public class SmartControlLogM
    {
        /// <summary>
        /// id
        /// </summary>
        public int Ing_Pk_SmartControlLogID { get; set; }
        /// <summary>
        /// 门店ID
        /// </summary>
        public string str_HotelID { get; set; }
        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }
        /// <summary>
        /// 网关ID
        /// </summary>
        public string str_GatewayID { get; set;}
        /// <summary>
        /// 控制器ID
        /// </summary>
        public string str_ContollerID { get; set; }
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
        public string str_Type { get; set; }
        /// <summary>
        /// 按键id
        /// </summary>
        public int Ing_KeyID { get; set; }
        /// <summary>
        /// 请求参数
        /// </summary>
        public string str_RequestParam { get; set; }
        /// <summary>
        /// 接口名称
        /// </summary>
        public string str_RequestName { get; set; }
        /// <summary>
        /// 请求路径
        /// </summary>
        public string str_RequestUrl { get; set; }
        /// <summary>
        /// 接口返回结果值
        /// </summary>
        public string str_ResultCode { get; set; }
        /// <summary>
        /// 执行结果
        /// </summary>
        public string str_ResultName { get; set; }
        /// <summary>
        /// 接口返回内容
        /// </summary>
        public string str_Response { get; set; }
        /// <summary>
        /// 产生时间
        /// </summary>
        public DateTime? dt_CreateTime { get; set; }
    }
}
