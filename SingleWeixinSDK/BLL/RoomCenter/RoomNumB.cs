using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RoomNumB
    {
        public DAL.RoomNumD dal = new DAL.RoomNumD();

        
        /// <summary>
        /// 获取房间数
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="RoomType"></param>
        /// <returns></returns>
        public int GetRoomNum(int Ing_StoreID, string RoomType)
        {
            return dal.GetRoomNum(Ing_StoreID, RoomType);
        }
    }
}
