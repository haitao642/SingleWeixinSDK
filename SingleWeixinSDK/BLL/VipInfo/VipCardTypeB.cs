using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VipCardTypeB
    {
        public DAL.VipCardTypeD dal = new DAL.VipCardTypeD();
        public VipCardTypeM GetVipCardType(int CardTypeID)
        {
            return dal.GetVipCardType(CardTypeID);
        }



    }
}
