using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Public
{
    public class CommonFunc
    {
        /// <summary>
        /// 返回星期格式
        /// </summary>
        /// <returns></returns>
        public string GetDayName(DateTime today)
        {
            string result = "";

            if (today.DayOfWeek == DayOfWeek.Monday)
            {
                result = "周一";
            }
            else if (today.DayOfWeek == DayOfWeek.Tuesday)
            {
                result = "周二";
            }
            else if (today.DayOfWeek == DayOfWeek.Wednesday)
            {
                result = "周三";
            }
            else if (today.DayOfWeek == DayOfWeek.Thursday)
            {
                result = "周四";
            }
            else if (today.DayOfWeek == DayOfWeek.Friday)
            {
                result = "周五";
            }
            else if (today.DayOfWeek == DayOfWeek.Saturday)
            {
                result = "<b>周六</b>";
            }
            else if (today.DayOfWeek == DayOfWeek.Sunday)
            {
                result = "<b>周日</b>";
            }

            return result;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public DateTime? StampToDateTime(string timeStamp)
        {
            try
            {
                DateTime dateTimeStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
                long lTime = long.Parse(timeStamp + "0000000");
                TimeSpan toNow = new TimeSpan(lTime);
                return dateTimeStart.Add(toNow);
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// unix时间戳转时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public DateTime UnixToDateTime(string time)
        {
            long num = 0;
            long.TryParse(time, out num);
            DateTime start = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            return start.AddSeconds(num);
        }

        /// <summary>
        /// 时间戳转为C#格式时间,如果为null,就转为当前时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public DateTime StampToDateTime(string timeStamp, DateTime dtdefault)
        {
            DateTime? now = dtdefault;
            now = StampToDateTime(timeStamp);
            if (!now.HasValue)
            {
                now = dtdefault;
            }
            return now.Value;
        }

        /// <summary>
        /// 验证输入的是不是手机号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsMobilePhone(string input)
        {
            Regex regex = new Regex("^1\\d{10}$");
            return regex.IsMatch(input);
        }


        /// <summary>
        ///计算两点GPS坐标的距离
        /// </summary>
        /// <param name="n1">第一点的纬度坐标</param>
        /// <param name="e1">第一点的经度坐标</param>
        /// <param name="n2">第二点的纬度坐标</param>
        /// <param name="e2">第二点的经度坐标</param>
        /// <returns></returns>
        public double Distance(double n1, double e1, double n2, double e2)
        {
            double jl_jd = 102834.74258026089786013677476285;
            double jl_wd = 111712.69150641055729984301412873;
            double b = Math.Abs((e1 - e2) * jl_jd);
            double a = Math.Abs((n1 - n2) * jl_wd);
            return Math.Sqrt((a * a + b * b));

        }

        /// <summary>
        /// 取距离
        /// </summary>
        /// <param name="sn1"></param>
        /// <param name="se1"></param>
        /// <param name="sn2"></param>
        /// <param name="se2"></param>
        /// <returns></returns>
        public decimal GetDistance(string sn1, string se1, string sn2, string se2)
        {
            double n1, e1, n2, e2;
            if (!double.TryParse(sn1, out n1))
            {
                return -1;
            }
            if (!double.TryParse(se1, out e1))
            {
                return -1;
            }
            if (!double.TryParse(sn2, out n2))
            {
                return -1;
            }
            if (!double.TryParse(se2, out e2))
            {
                return -1;
            }
            double d = Distance(n1, e1, n2, e2);
            ///转为公里
            d = d / 1000;

            decimal dec = 0;
            decimal.TryParse(d.ToString("F2"), out dec);
            return dec;
        }




        /// <summary>
        /// 复制对象
        /// </summary>
        /// <param name="srcObj"></param>
        /// <param name="destObj"></param>
        /// <returns></returns>
        public int CopyData(object srcObj, object destObj)
        {
            if (srcObj == null || destObj == null)
                return 0;
            int nCounts = 0;

            Type srcType = srcObj.GetType();
            FieldInfo[] srcFieldInfos = srcType.GetFields();
            Type destType = destObj.GetType();
            foreach (FieldInfo fieldInfo in srcFieldInfos)
            {
                try
                {
                    FieldInfo destField = destType.GetField(fieldInfo.Name);
                    if (destField != null)
                    {
                        if (String.Compare(fieldInfo.FieldType.Name.ToLower().Trim(), destField.FieldType.Name.ToLower().Trim(), true) == 0)
                        {
                            destField.SetValue(destObj, fieldInfo.GetValue(srcObj));
                            nCounts++;
                        }
                    }
                    else
                    {
                        PropertyInfo destProp = destType.GetProperty(fieldInfo.Name);
                        if (destProp != null && String.Compare(fieldInfo.FieldType.Name.ToLower().Trim(), destProp.PropertyType.Name.ToLower().Trim(), true) == 0)
                        {
                            destProp.SetValue(destObj, fieldInfo.GetValue(srcObj), null);
                            nCounts++;
                        }
                    }
                }
                catch
                {
                }
            }

            PropertyInfo[] srcPropInfos = srcType.GetProperties();
            foreach (PropertyInfo propInfo in srcPropInfos)
            {
                try
                {
                    FieldInfo destField = destType.GetField(propInfo.Name);
                    if (destField != null)
                    {
                        if (String.Compare(propInfo.PropertyType.Name.ToLower().Trim(), destField.FieldType.Name.ToLower().Trim(), true) == 0)
                        {
                            destField.SetValue(destObj, propInfo.GetValue(srcObj, null));
                            nCounts++;
                        }
                    }
                    else
                    {
                        PropertyInfo destProp = destType.GetProperty(propInfo.Name);
                        if (destProp != null && String.Compare(propInfo.PropertyType.Name.ToLower().Trim(), destProp.PropertyType.Name.ToLower().Trim(), true) == 0)
                        {
                            destProp.SetValue(destObj, propInfo.GetValue(srcObj, null), null);
                            nCounts++;
                        }
                    }
                }
                catch
                {
                }
            }
            return nCounts;
        }



        /// <summary>  
        /// 验证身份证合理性  
        /// </summary>  

        /// <param name="Id"></param>  
        /// <returns></returns>  
        public bool CheckIDCard(string idNumber)
        {
            if (string.IsNullOrEmpty(idNumber))
            {
                return false;
            }
            if (idNumber.Length == 18)
            {
                bool check = CheckIDCard18(idNumber);
                return check;
            }
            else if (idNumber.Length == 15)
            {
                bool check = CheckIDCard15(idNumber);
                return check;
            }
            else
            {
                return false;

            }
        }


        /// <summary>  
        /// 18位身份证号码验证  
        /// </summary>  
        private bool CheckIDCard18(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber.Remove(17), out n) == false || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
            {
                return false;//数字验证  
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");

            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {

                return false;//生日验证  
            }
            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');

            char[] Ai = idNumber.Remove(17).ToCharArray();
            int sum = 0;
            for (int i = 0; i < 17; i++)
            {
                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());

            }
            int y = -1;
            Math.DivRem(sum, 11, out y);
            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())
            {
                return false;//校验码验证  

            }
            return true;//符合GB11643-1999标准  
        }


        /// <summary>  
        /// 16位身份证号码验证  
        /// </summary>  
        private bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证  
            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(idNumber.Remove(2)) == -1)
            {
                return false;//省份验证  
            }
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");

            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {

                return false;//生日验证  
            }
            return true;
        }
    }
}
