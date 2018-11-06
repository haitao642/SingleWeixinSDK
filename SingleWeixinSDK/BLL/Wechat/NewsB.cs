using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NewsB
    {
        public DAL.NewsD dal = new DAL.NewsD();

        public NewsB() { }

        /// <summary>
        /// 得到一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NewsM GetOne(int id)
        {
            return dal.GetM<NewsM>(id);
        }


        /// <summary>
        /// 获取某一类的新闻
        /// </summary>
        /// <param name="topnum">0:全部  </param>
        /// <param name="Ing_FCaption">新闻类型   31： 促销信息</param>
        /// <returns></returns>
        public List<NewsM> GetNews(int topnum, int Ing_FCaption)
        {
            return dal.GetNews(topnum, Ing_FCaption);
        }
    }
}
