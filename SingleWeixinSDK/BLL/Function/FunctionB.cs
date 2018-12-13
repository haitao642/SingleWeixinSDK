using DAL.function;
using Model.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Function
{
     public class FunctionB
    {
        FunctionD dal = new FunctionD();
        /// <summary>
        /// 获取功能列表(根)
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        public List<FunctionM> GetFunctionRootForOta(string storeid)
        {
            return dal.GetFunctionRootForOta(storeid);
        }
        /// <summary>
        /// 根据父级id获取子集功能列表
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public List<FunctionM> GetFunctionForParent(int parentid)
        {
            return dal.GetFunctionForParent(parentid);
        }
    }
}
