using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StoreImgB
    {
        public DAL.StoreImgD dal = new DAL.StoreImgD();

        public StoreImgB() { }


        /// <summary>
        /// 得到门店图片
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public List<StoreImgM> GetStoreImgM(int Ing_StoreID)
        {
            return dal.GetStoreImgM(Ing_StoreID);
        }


                /// <summary>
        /// 根据类型获取图片
        /// </summary>
        /// <param name="storeids"></param>
        /// <param name="Ing_type">类型1，酒店，2房型,3评论.4新闻</param>
        /// <returns></returns>
        public List<StoreImgM> GetStoreImgbytype(string storeids, int Ing_type)
        {
            return dal.GetStoreImgbytype(storeids, Ing_type);
        }

         /// <summary>
        /// 根据类型获取图片
        /// </summary>
        /// <param name="storeids"></param>
        /// <param name="Ing_type">类型1，酒店，2房型,3评论.4新闻</param>
        /// <returns></returns>
        public StoreImgM GetOneStoreImgbytype(int Ing_StoreID, int Ing_type)
        {
            return dal.GetOneStoreImgbytype(Ing_StoreID, Ing_type);
        }
    }
}
