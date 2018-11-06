using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 获取房价
    /// </summary>
    public class RoomRateM
    {
        /// <summary>
        /// 房型
        /// </summary>
        public string RoomType { get; set; }


        /// <summary>
        /// 房价码
        /// </summary>
        public string RoomRateCode { get; set; }


        /// <summary>
        /// 价格
        /// </summary>
        public decimal price { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string str_feature { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string source { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string market { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string marketName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string packages { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string commCode { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public decimal RmPrice { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string Deposit { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string DepTime { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string ResTime { get; set; }


    }


    /// <summary>
    /// 散客预订里的可用房，最大，最小房数
    /// </summary>
    public class RoomCanUseM
    {
        /// <summary>
        /// 当前可用房数
        /// </summary>
        public int kf { get; set; }


        /// <summary>
        /// 最大房数
        /// </summary>
        public int maxnum { get; set; }


        /// <summary>
        /// 最小房数
        /// </summary>
        public int minnum { get; set; }
    }
}
