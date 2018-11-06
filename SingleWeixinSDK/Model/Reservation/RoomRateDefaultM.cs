using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 默认房价码
    /// </summary>
    public class RoomRateDefaultM
    {
        /// <summary>
        /// 默认房型
        /// </summary>
        public string str_TypeCode { get; set; }

        /// <summary>
        /// 默认房型中文名
        /// </summary>
        public string str_TypeName { get; set; }


        /// <summary>
        /// 默认房价码
        /// </summary>
        public string str_RateID { get; set; }


        /// <summary>
        /// 默认房价
        /// </summary>
        public decimal price { get; set; }


        /// <summary>
        /// 特征
        /// </summary>
        public string str_feature { get; set; }


        /// <summary>
        /// 来源
        /// </summary>
        public string source { get; set; }


        /// <summary>
        /// 市场码
        /// </summary>
        public string str_market { get; set; }


        /// <summary>
        /// 市场名称
        /// </summary>
        public string str_marketName { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string packages { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string commCode { get; set; }


        /// <summary>
        /// 默认价格
        /// </summary>
        public decimal RmPrice { get; set; }


        /// <summary>
        /// 押金  |
        /// </summary>
        public string Deposit { get; set; }

        /// <summary>
        /// 默认入住时的押金
        /// </summary>
        public string sDeposit
        {
            get
            {
                if (string.IsNullOrEmpty(Deposit))
                {
                    return Deposit;
                }
                if (!Deposit.Contains('|'))
                {
                    return Deposit;
                }
                return Deposit.Split('|')[0];
            }
        }

        /// <summary>
        /// 默认续住时的押金
        /// </summary>
        public string sDeposit1
        {
            get
            {
                if (string.IsNullOrEmpty(Deposit))
                {
                    return Deposit;
                }
                if (!Deposit.Contains('|'))
                {
                    return Deposit;
                }
                return Deposit.Split('|')[1];
            }
        }

        /// <summary>
        /// 默认离期
        /// </summary>
        public string DepTime { get; set; }


        /// <summary>
        /// 默认保留时间
        /// </summary>
        public string ResTime { get; set; }

        /// <summary>
        /// 页面刷新时的离期
        /// </summary>
        public DateTime dt_depdate {
            get
            {
                DateTime dt = DateTime.Now.AddDays(1);
                if (DateTime.TryParse(string.Format("{0} {1}", dt.ToString("yyyy-MM-dd"), DepTime),out dt))
                { 
                return dt;
                }
                return DateTime.Now.AddDays(1).Date.AddHours(13);
            }
        }


    }
}
