using Model.ErrorMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 错误model
    /// </summary>
    public static partial class ErrorModel
    {
        /// <summary>
        /// 错误枚举
        /// </summary>
        public static List<ErrorItem> errors
        {
            get
            {
                List<ErrorItem> list = new List<ErrorItem>();
                list.Add(new ErrorItem(100001, "逻辑判断", "逻辑判断"));


                list.Add(new ErrorItem(900100, "数据库操作错误", "数据库操作错误"));
                list.Add(new ErrorItem(900401, "没有权限", "没有权限"));
                return list;
            }
        }
    }
}
