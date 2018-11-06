using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 周边信息
    /// </summary>
    public  class NearB
    {
        DAL.NearD dal = new DAL.NearD();
         /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="keyword"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public List<ZBInfoM> bindDz(string x, string y, string keyword, int number)
        {
            return dal.bindDz(x, y, keyword, number);
        }


         //美食
        public string bindDiet(string x, string y)
        {
            return dal.bindDiet(x, y);
        }
    }
}
