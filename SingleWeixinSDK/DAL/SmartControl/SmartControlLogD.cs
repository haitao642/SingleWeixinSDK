using Model.SmartControl;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SmartControl
{
    public class SmartControlLogD:BaseTable
    {
        public SmartControlLogD(): base("T_SmartControl_Log", "Ing_Pk_SmartControlLogID")
        {
            this.Sqlca = SqlcaOTAPMS();
        }
        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(SmartControlLogM model)
        {
            return true;
        }

        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(SmartControlLogM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev = this.UpdateRecord<SmartControlLogM>(model, model.Ing_Pk_SmartControlLogID);
            model.Ing_Pk_SmartControlLogID = this.lngKeyID;
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
        public string save(SmartControlLogM model)
        {
            if (!this.Sqlca.BeginTransaction())
            {
                goto updateerr;
            }
            int ID = 0;
            if (!this.UpdateRecord<SmartControlLogM>(model, 0, this.Sqlca))
            {
                this.LastError = "L生成控制器日志失败";
                goto updateerr;
            }
            ID= this.lngKeyID;
            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();
            return "success";
            updateerr:
            if (!string.IsNullOrEmpty(this.LastError))
            {
                this.LastError = this.Sqlca.LastError;
            }
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            return this.LastError;
        }
    }
}
