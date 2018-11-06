using Bee.Web;
using Model.Cust;
using Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustD:BaseTable
    {
        public CustD()
            : base("T_Cust", "Ing_Pk_CustID")
        { 
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(CustM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 档案主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(CustM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<CustM>(model, model.Ing_Pk_CustID);
            model.Ing_Pk_CustID = this.lngKeyID;
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
    }
}
