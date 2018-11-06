using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model 
{
    /// <summary>
    /// OrderDetailM
    /// </summary>
    public class OrderDetailM
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }


        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }


        /// <summary>
        /// 来期
        /// </summary>
        public DateTime dt_ArrDate { get; set; }


        /// <summary>
        /// 离期
        /// </summary>
        public DateTime dt_DepDate { get; set; }

        /// <summary>
        /// 天数
        /// </summary>
        public int day
        {
            get
            {
                TimeSpan ts1 = new TimeSpan(dt_ArrDate.Ticks);
                TimeSpan ts2 = new TimeSpan(dt_DepDate.Ticks);
                int days = (ts2.Days - ts1.Days);
                return days;
            }
        }


        /// <summary>
        /// 订房数
        /// </summary>
        public int Ing_RoomNum { get; set; }

        /// <summary>
        /// 房型编码
        /// </summary>
        public string RoomTypeCode { get; set; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string str_CusName { get; set; }


        /// <summary>
        /// 手机号
        /// </summary>
        public string str_mobile { get; set; }


        /// <summary>
        /// 图片
        /// </summary>
        public string strTopImg { get; set; }


        /// <summary>
        /// 非会员价格
        /// </summary>
        public decimal price { get; set; }


        /// <summary>
        /// 会员价
        /// </summary>
        public decimal VipPrice { get; set; }

        /// <summary>
        /// 会员房价码
        /// </summary>
        public string VipRateCode { get; set; }

        /// <summary>
        /// 非会员总价
        /// </summary>
        public decimal totalPrice { get; set; }

        /// <summary>
        /// 会员总价
        /// </summary>
        public decimal totalVipPrice { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int lngvipcardid { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }

    }
}
