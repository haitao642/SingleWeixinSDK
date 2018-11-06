using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreInfoB
    {
        public DAL.StoreInfoD dal = new DAL.StoreInfoD();


        /// <summary>
        /// 得到一个门店
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public StoreInfoM GetOne(int Ing_StoreID)
        {
            return dal.GetM<StoreInfoM>(Ing_StoreID);
        }

         /// <summary>
        /// 根据城市获取门店
        /// </summary>
        /// <param name="strcity"></param>
        /// <returns></returns>
        public List<StoreM> GetStoreListbycity(string strcity)
        {
            return dal.GetStoreListbycity(strcity);
        }

        /// <summary>
        /// 根据酒店id和服务器类型获取总后端id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public OutStoreInfoM ConvertStoreID(RequestParamModel param)
        {
            return dal.ConvertStoreID(param);
        }
        /// <summary>
        /// 根据城市获取钟点房预订的门店
        /// </summary>
        /// <param name="strcity"></param>
        /// <returns></returns>
        public List<StoreM> GetStoreListHourbycity(string strcity)
        {
            return dal.GetStoreListHourbycity(strcity);
        }

        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetCityList()
        {
            return dal.GetCityList();
        }

                /// <summary>
        /// 获取单个门店信息
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public StoreM GetStore(int Ing_StoreID)
        {
            return dal.GetStore(Ing_StoreID);
        }
        public String GetStoreHeaderImg(int Ing_StoreID)
        {
            return dal.GetStoreHeaderImg(Ing_StoreID);
        }
        public List<StoreImgM> GetStoreImg(int Ing_StoreID)
        {
            return dal.GetStoreImg(Ing_StoreID);
        }
         
    }
}
