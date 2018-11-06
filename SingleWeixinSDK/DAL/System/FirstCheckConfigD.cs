using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bee.Web;
namespace DAL
{
    public class FirstCheckConfigD:BaseTable
    {
        public FirstCheckConfigD()
            : base("T_FirstCheck_Config", "Ing_ID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(FirstCheckConfigM model)
        {
           
            
            return true;
        }

        /// <summary>
        /// 保存 首住优惠配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(FirstCheckConfigM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<FirstCheckConfigM>(model, model.Ing_ID);
            model.Ing_ID = this.lngKeyID;
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
        /// 根据门店和日期，查找微信端配额
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="dtarr"></param>
        /// <returns></returns>
        public FirstCheckConfigM GetRecordByDate(int Ing_StoreID, DateTime dtarr)
        {
            string strSql = "SELECT * FROM dbo.T_FirstCheck_Config a WHERE a.Ing_StoreID={0} AND DATEDIFF(DAY,a.dt_Date,'{1}')=0 AND ISNULL(a.ing_Type,0)=0";
            strSql = string.Format(strSql,Ing_StoreID,dtarr.ToString("yyyy-MM-dd"));

            return this.GetQueryM<FirstCheckConfigM>(strSql).FirstOrDefault();
        }
    }
}
