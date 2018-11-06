using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_UsersGrp
    /// </summary>
    public class UsersGrpM
    {
        ///<summary>
        ///流水号
        /// </summary>
        public int Ing_pk_UID { get; set; }

        ///<summary>
        ///工号
        /// </summary>
        public string str_EmpNo { get; set; }

        ///<summary>
        ///登录名
        /// </summary>
        public string str_UserName { get; set; }

        ///<summary>
        ///真实姓名
        /// </summary>
        public string str_RealName { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string str_openid { get; set; }
    }
}
