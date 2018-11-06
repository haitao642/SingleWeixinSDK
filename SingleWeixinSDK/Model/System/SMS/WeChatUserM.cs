using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_WeChat_User
    /// </summary>
    public class WeChatUserM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_WeChat_UserID {get;set;}

        ///<summary>
        ///门店ID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///微信id
        /// </summary>
        public string OpenID {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_memo {get;set;}

        ///<summary>
        ///发送类型
        /// </summary>
        public int Ing_type {get;set;}

        ///<summary>
        ///发送类型
        /// </summary>
        public string str_type {get;set;}


        /// <summary>
        /// 状态   0：禁用  1：启用  2：待确认
        /// </summary>
        public int Ing_sta { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime dt_Create { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime dt_Modify { get; set; }

    }
}