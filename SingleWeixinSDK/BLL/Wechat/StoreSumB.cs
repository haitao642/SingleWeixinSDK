using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreSumB
    {
        public DAL.StoreSumD dal = new DAL.StoreSumD();

        public StoreSumB() { }

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StoreSumM GetOne(int id)
        {
            return dal.GetM<StoreSumM>(id);
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<StoreSumM> GetAll()
        {
            List<StoreSumM> list = new List<StoreSumM>();
            list = dal.GetAllM<StoreSumM>();
            list = list.OrderBy(x => x.Ing_StoreSumID).ToList();
            return list;
        }
    }
}
