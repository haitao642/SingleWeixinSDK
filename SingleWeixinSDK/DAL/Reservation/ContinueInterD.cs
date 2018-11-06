using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContinueInterD:BaseTable
    {
        public ContinueInterD()
            : base("T_ContinueInter", "Ing_pkid")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(ContinueInterM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 续住记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(ContinueInterM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<ContinueInterM>(model, model.Ing_pkid);
            model.Ing_pkid = this.lngKeyID;
            return rev;
        }


        
        /// <summary>
        /// 检查删除
        /// </summary>
        /// <param name="lnguserid"></param>
        /// <returns></returns>
        public bool CheckDelete(int id)
        {
            return true;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lnguserid"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {

            if (!CheckDelete(id))
            {
                return false;
            }

            return this.DeleteRecord(id);
        }
        #endregion


        /// <summary>
        /// 根据主单id和类型查找记录
        /// </summary>
        /// <param name="MasterID">主单id</param>
        /// <param name="type">0:续住   1：退房</param>
        /// <returns></returns>
        public ContinueInterM GetRecord(int MasterID, int type)
        {
            string strSql = "SELECT TOP 1 * FROM dbo.T_ContinueInter a WHERE a.Ing_MasterID={0} AND ISNULL(a.Ing_type,0)={1} ORDER BY a.Ing_pkid DESC";
            strSql = string.Format(strSql,MasterID,type);

            return this.GetQueryM<ContinueInterM>(strSql).FirstOrDefault();
        }
    }
}
