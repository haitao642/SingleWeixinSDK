using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Shop
{
    /// <summary>
    /// 商城返回
    /// </summary>
    public class BaseShopM
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string msg { get; set; }

    }

    /// <summary>
    /// 商城请求
    /// </summary>
    public class AskShopM
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// pms主键
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
    }
}
