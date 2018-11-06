using Model;
using Model.Cust;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustB
    {
        public DAL.CustD dal = new DAL.CustD();

        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="CustID"></param>
        /// <returns></returns>
        public CustM GetOne(int CustID)
        {
            return dal.GetM<CustM>(CustID);
        }

    }
}
