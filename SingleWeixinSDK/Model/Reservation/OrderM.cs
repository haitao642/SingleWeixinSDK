using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 订单信息的model
    /// </summary>
    public class OrderM
    {
        /// <summary>
        /// 主单id
        /// </summary>
        public int Ing_Pk_MasterID { get; set; }


        /// <summary>
        /// 主单账号
        /// </summary>
        public string str_Pk_Accnt { get; set; }


        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }


        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }


        /// <summary>
        /// 预订类型
        /// </summary>
        public string str_ResType { get; set; }


        /// <summary>
        /// 来期
        /// </summary>
        public DateTime? dt_ArrDate { get; set; }

        /// <summary>
        /// 来期的字符串
        /// </summary>
        public string strarr {
            get {
                if (!dt_ArrDate.HasValue)
                {
                    return string.Empty;
                }
                return dt_ArrDate.Value.ToString("MM月dd日");
            }
        }

        /// <summary>
        /// 能否取消
        /// </summary>
        public bool CanCancel
        {
            get {
                //只有 预订状态的才能取消
                if (!str_Sta.ToUpper().Trim().Equals("R"))
                {
                    return false;
                }

                //没有来期
                if (!dt_ArrDate.HasValue)
                {
                    return false;
                }

                //判断钟点房的可取消状态
                if (str_InterType.ToUpper().Trim().Equals("HOUR"))
                {
                    if (!dt_restime.HasValue)
                    {
                        return false;
                    }
                    if (dt_ArrDate.Value < DateTime.Now)
                    {
                        return false;
                    }
                    return true;
                }

                string strdate = string.Format("{0} 18:00:00",dt_ArrDate.Value.ToString("yyyy-MM-dd"));

                DateTime dtdate = DateTime.Now;
                if (!DateTime.TryParse(strdate, out dtdate))
                {
                    return false;
                }

                bool rev = true;//true表示17:30点之前,false表示17:30点之后
                if (dt_ArrDate > dtdate.AddMinutes(-30)) 
                {
                    rev = false;
                }
                if (!rev && (DateTime.Now - dt_ArrDate.Value).TotalMinutes > 30) //17:30点之后的订单,半小时之后,不能取消
                {
                    return false;
                }

                //18点之前的订单 超过来期日的18点，不能取消
                if (rev && DateTime.Now > dtdate)
                {
                    return false;
                }                
                
                return true;
            }
        }


        /// <summary>
        /// 离期
        /// </summary>
        public DateTime? dt_DepDate { get; set; }

        /// <summary>
        /// 来期的字符串
        /// </summary>
        public string strdep
        {
            get
            {
                if (!dt_DepDate.HasValue)
                {
                    return string.Empty;
                }
                return dt_DepDate.Value.ToString("MM月dd日");
            }
        }

        /// <summary>
        /// 取消时间
        /// </summary>
        public DateTime? dt_CancelTime { get; set; }

        /// <summary>
        /// 天数
        /// </summary>
        public int day {
            get {
                if (!dt_ArrDate.HasValue)
                {
                    return 1;
                }
                if (!dt_DepDate.HasValue)
                {
                    return 1;
                }

                TimeSpan ts1 = new TimeSpan(dt_ArrDate.Value.Ticks);
                TimeSpan ts2 = new TimeSpan(dt_DepDate.Value.Ticks);
                int days = (ts2.Days - ts1.Days);

                if (string.Compare(dt_ArrDate.Value.ToString("HHmm"), "0600")<=0)
                {
                    days++;
                }
                return days;
            }
        }

        /// <summary>
        /// 总房价
        /// </summary>
        public decimal totalprice
        {
            get {
                return dec_ActualRate * day * Ing_RoomNum;
            }
        }


        /// <summary>
        /// 门店地址
        /// </summary>
        public string str_Address { get; set; }


        /// <summary>
        /// 房价
        /// </summary>
        public decimal dec_ActualRate { get; set; }

        /// <summary>
        /// 押金
        /// </summary>
        public decimal dec_credit { get; set; }


        /// <summary>
        /// 订房数
        /// </summary>
        public int Ing_RoomNum { get; set; }

        /// <summary>
        /// 房型编码
        /// </summary>
        public string str_RoomType { get; set; }

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
        /// 预订时间
        /// </summary>
        public DateTime? dt_restime { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public string str_Sta { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        public string StaName {
            get {
                switch (str_Sta)
                {
                    case "R": return "预订";
                    case "I": return "在住";
                    case "X": return "已取消";
                    case "N": return "应到未到";
                    case "D":
                    case "O": return "离店";
                    default: return "";
                }
            }
        }

        /// <summary>
        /// 是否已经评论过  1：评论过了
        /// </summary>
        public int AlreadyComment { get; set; }

        /// <summary>
        /// 在住状态的，能不能点支付按钮，  0：不能，  1:能
        /// </summary>
        public int CanPayXu { get; set; }

        /// <summary>
        /// 入住类型
        /// </summary>
        public string str_InterType { get; set; }

        /// <summary>
        /// 是否能能够续住
        /// </summary>
        public bool CanXu {
            get {
                //入住类型为空
                if (string.IsNullOrEmpty(str_InterType))
                {
                    return false;
                }

                //不是全天房
                if (!str_InterType.ToUpper().Trim().Equals("ALL"))
                {
                    return false;
                }

                //状态为空
                if (string.IsNullOrEmpty(str_Sta))
                {
                    return false;
                }

                //不是在住的
                if(!str_Sta.ToUpper().Trim().Equals("I"))
                {
                    return false;
                }

                //没有离期
                if (!dt_DepDate.HasValue)
                {
                    return false;
                }

                //不是今天离期的
                if (!dt_DepDate.Value.ToString("yyyyMMdd").Equals(DateTime.Now.ToString("yyyyMMdd")))
                {
                    return false;
                }

                return true;
            }
        }


    }

    /// <summary>
    /// 订单列表的页面
    /// </summary>
    public class OrderListM
    {
        /// <summary>
        /// 订单列表
        /// </summary>
        public List<OrderM> list { get; set; }
    }
}
