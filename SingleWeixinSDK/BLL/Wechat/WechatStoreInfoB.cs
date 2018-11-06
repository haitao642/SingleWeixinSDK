using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WechatStoreInfoB
    {
        public DAL.WechatStoreInfoD dal = new DAL.WechatStoreInfoD();

        public WechatStoreInfoB() { }


        /// <summary>
        /// ²éÑ¯¾Æµê
        /// </summary>
        /// <param name="topnum"></param>
        /// <param name="str_city"></param>
        /// <returns></returns>
        public List<SearchStoreInfoM> SearchHotel(int topnum, string str_city)
        {
            return dal.SearchHotel(topnum, str_city);
        }
    }
}
