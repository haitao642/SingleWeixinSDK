using Model.Function;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.function
{
     public class FunctionD : BaseTable
    {

        public FunctionD(): base("T_Wechat_Function", "Ing_id")
        {
            this.Sqlca = SqlcaOTAPMS();
        }
        /// <summary>
        /// 获取功能列表(根)
        /// </summary>
        /// <param name="storeid"></param>
        /// <returns></returns>
        public List<FunctionM> GetFunctionRootForOta(string storeid)
        {
            string sql = "select * from T_Wechat_Function where Ing_id={0} and isRoot=0 and is_Deleted=1 order by sort desc";
            sql = string.Format(sql, storeid);
            return this.GetQueryM<FunctionM>(sql);
        }

        /// <summary>
        /// 根据父级id获取子集功能列表
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public List<FunctionM> GetFunctionForParent(int parentid)
        {
            string sql = "select * from T_Wechat_Function where parentid={0} and is_Deleted=1 order by sort desc";
            sql = string.Format(sql, parentid);
            return this.GetQueryM<FunctionM>(sql);
        }
    }
}
