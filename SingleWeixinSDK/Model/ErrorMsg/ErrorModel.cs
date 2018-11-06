using Model.ErrorMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static partial class ErrorModel
    {
        /// <summary>
        /// 获取单一记录
        /// </summary>
        /// <param name="errId"></param>
        /// <returns></returns>
        public static ErrorItem GetErrorItem(int errId)
        {
            return errors.Where(e => e.errorId == errId).FirstOrDefault();
        }


        #region  list the detail error
        /// <summary>
        /// 逻辑判断
        /// </summary>
        public static ErrorItem WrongLogic
        {
            get
            {
                return GetErrorItem(100001);
            }
        }

        /// <summary>
        /// 没有权限
        /// </summary>
        public static ErrorItem NoAuthorize
        {
            get
            {
                return GetErrorItem(900401);
            }
        }

        /// <summary>
        /// 数据库操作错误
        /// </summary>
        public static ErrorItem WrongDataBaseOperation
        {
            get
            {
                return GetErrorItem(900100);
            }
        }


        #endregion
    }
}
