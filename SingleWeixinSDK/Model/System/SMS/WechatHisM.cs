using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_WechatHis
    /// </summary>
    public class WechatHisM
    {
        ///<summary>
        ///自增ID
        /// </summary>
        public int Ing_WechatHisID {get;set;}

        ///<summary>
        ///openid
        /// </summary>
        public string str_openid {get;set;}

        ///<summary>
        ///昵称
        /// </summary>
        public string str_nickname {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_Create {get;set;}

        ///<summary>
        ///事件类型   0:关注  1：取消关注   2:已经关注的扫描事件
        /// </summary>
        public int? Ing_EventType {get;set;}

        ///<summary>
        ///参数值
        /// </summary>
        public int? Ing_Para {get;set;}

        ///<summary>
        ///参数类型  0：空  1：门店ID   2:销售员ID
        /// </summary>
        public int? Ing_ParaType {get;set;}



    }
}