using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsersGrpB
    {
        public DAL.UsersGrpD dal = new DAL.UsersGrpD();


        /// <summary>
        /// 根据门店ID 查找店长
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public List<UsersGrpM> GetManagerByStoreID(int StoreID)
        {
            return dal.GetManagerByStoreID(StoreID);
        }
    }
}
