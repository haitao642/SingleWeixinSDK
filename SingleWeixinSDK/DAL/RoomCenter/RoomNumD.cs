using Bee.Web;
using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomNumD:BaseTable
    {
        public RoomNumD()
            : base("T_Room_Num", "Ing_pk_id")
        { }

        /// <summary>
        /// 获取房间数
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="RoomType"></param>
        /// <returns></returns>
        public int GetRoomNum(int Ing_StoreID, string RoomType)
        {
            string strSql = "SELECT COUNT(0) FROM dbo.T_Room_Num c1 WHERE c1.Ing_StoreID={0} AND c1.str_FK_Type='{1}'";
            strSql = string.Format(strSql,Ing_StoreID,RoomType);

            return this.Sqlca.GetInt32(strSql);
        }


    }
}
