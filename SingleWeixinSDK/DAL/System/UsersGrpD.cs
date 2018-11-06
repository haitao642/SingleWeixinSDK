using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class UsersGrpD : BaseTable
    {
        public UsersGrpD()
            : base("T_UsersGrp", "Ing_pk_UID")
        { }

        /// <summary>
        /// 根据门店ID 查找店长
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public List<UsersGrpM> GetManagerByStoreID(int StoreID)
        {
            if (StoreID == 0)
            {
                return new List<UsersGrpM>();
            }
            string strSql = @"SELECT a.Ing_pk_UID,a.str_EmpNo,a.str_UserName,a.str_RealName,a.str_openid
                                    FROM dbo.T_UsersGrp a WHERE ISNULL(a.str_openid,'')<>''
                                    AND ','+LTRIM(RTRIM(ISNULL(a.str_fk_AreaStoreStr,'')))+',' LIKE '%,{0},%'";
            strSql = string.Format(strSql,StoreID);
            return this.GetQueryM<UsersGrpM>(strSql);
        }
    }
}
