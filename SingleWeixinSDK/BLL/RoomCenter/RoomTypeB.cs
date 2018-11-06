using Model;
using Model.RoomCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomTypeB
    {
        public DAL.RoomTypeD dal = new DAL.RoomTypeD();

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="RoomTypeID"></param>
        /// <returns></returns>
        public RoomTypeM GetOne(int RoomTypeID)
        {
            return dal.GetM<RoomTypeM>(RoomTypeID);
        }

        /// <summary>
        /// 获取有效房房型
        /// </summary>
        /// <returns></returns>
        public List<RoomTypeM> GetUseFulList(int Ing_StoreID)
        {
            return dal.GetUseFulList(Ing_StoreID);
        }

        /// <summary>
        /// 获取房型和价格
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="dtarr"></param>
        /// <returns></returns>
        public List<RoomType1M> GetUseFulList(int Ing_StoreID, DateTime dtarr)
        {
            return dal.GetUseFulList(Ing_StoreID, dtarr);
        }
        /// <summary>
        /// 获取房型图片
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="strRoomTypeCode"></param>
        /// <returns></returns>
        public List<StoreImgM> GetRoomTypeImg(int Ing_StoreID, string strRoomTypeCode)
        {
            return dal.GetRoomTypeImg(Ing_StoreID,strRoomTypeCode);
        }

        /// <summary>
        /// 获取钟点房型和价格
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="dtarr"></param>
        /// <returns></returns>
        public List<RoomType1M> GetUseFulHourList(int Ing_StoreID, DateTime dtarr)
        {
            return dal.GetUseFulHourList(Ing_StoreID, dtarr);
        }


        /// <summary>
        /// 根据门店和房型找记录
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public RoomTypeM GetRoomType(int Ing_StoreID, string typecode)
        {
            return dal.GetRoomType(Ing_StoreID, typecode);
        }
        /// <summary>
        /// 根据主单获取房型
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public RoomTypeM GetRoomType(int masterid)
        {
            DAL.MasterD masD = new DAL.MasterD();
            MasterM masM = masD.GetM<MasterM>(masterid);
            if (masM == null || string.IsNullOrEmpty(masM.str_RoomType))
            {
                return null;
            }
            return dal.GetRoomType(masM.Ing_StoreID ?? 0, masM.str_RoomType);
        }
    }
}
