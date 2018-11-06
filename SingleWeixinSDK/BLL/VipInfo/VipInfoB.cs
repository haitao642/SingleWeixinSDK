using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VipInfoB
    {
        public DAL.VipInfoD dal = new DAL.VipInfoD();

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="RoomTypeID"></param>
        /// <returns></returns>
        public VipInfoM GetOne(int VipInfoID)
        {
            return dal.GetM<VipInfoM>(VipInfoID);
        }
    }
}
