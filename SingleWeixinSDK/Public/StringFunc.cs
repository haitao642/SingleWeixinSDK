using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Public
{
    /// <summary>
    /// 字符转换
    /// </summary>
    public static class StringFunc
    {
        /// <summary>
        /// 字符串转为int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            int rev = 0;
            int.TryParse(str, out rev);
            return rev;
        }

        /// <summary>
        /// 字符串转为int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rev">默认值</param>
        /// <returns></returns>
        public static int ToInt(this string str, int rev)
        {
            int.TryParse(str, out rev);
            return rev;
        }

        /// <summary>
        /// 字符串转为decimal
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str)
        {
            decimal rev = 0;
            decimal.TryParse(str, out rev);
            return rev;
        }

        /// <summary>
        /// 字符串转为decimal
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rev">默认值</param>
        /// <returns></returns>
        public static decimal ToDecimal(this string str, decimal rev)
        {
            decimal.TryParse(str, out rev);
            return rev;
        }

        /// <summary>
        /// 字符串转为时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            DateTime rev = DateTime.Now;
            DateTime.TryParse(str, out rev);
            return rev;
        }

        /// <summary>
        /// 字符串转为时间
        /// </summary>
        /// <param name="str"></param>
        /// <param name="rev">默认时间</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, DateTime rev)
        {
            DateTime.TryParse(str, out rev);
            return rev;
        }
    }
}
