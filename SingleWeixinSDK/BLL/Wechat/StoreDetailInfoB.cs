using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreDetailInfoB
    {
        public DAL.StoreDetailInfoD dal = new DAL.StoreDetailInfoD();

        public StoreDetailInfoB() { }


                /// <summary>
        /// 根据门店ID 查找门店详情
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public StoreDetailInfoM GetOne(int Ing_StoreID)
        {
            return dal.GetOne(Ing_StoreID);
        }


                /// <summary>
        /// 获取在查询酒店列表用到的信息
        /// </summary>
        /// <param name="storeids"></param>
        /// <returns></returns>
        public List<DetailInfoInListM> GetList(string storeids)
        {
            return dal.GetList(storeids);
        }
    }
}
