using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_WechatPosition
    /// </summary>
    public class WechatPositionM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_PositionID {get;set;}

        ///<summary>
        ///openid
        /// </summary>
        public string openid {get;set;}

        ///<summary>
        /// 纬度
        /// </summary>
        public string latitude {get;set;}

        ///<summary>
        ///经度
        /// </summary>
        public string longitude {get;set;}

        ///<summary>
        ///省
        /// </summary>
        public string province {get;set;}

        ///<summary>
        ///市
        /// </summary>
        public string cityname {get;set;}

        ///<summary>
        ///区
        /// </summary>
        public string district {get;set;}

        ///<summary>
        ///街道
        /// </summary>
        public string street {get;set;}

        ///<summary>
        ///门牌
        /// </summary>
        public string street_number {get;set;}

        ///<summary>
        ///完整地址
        /// </summary>
        public string formatted_address {get;set;}

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime dt_Create { get; set; }
    }
}