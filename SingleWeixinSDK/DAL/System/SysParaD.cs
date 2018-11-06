using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysParaD:BaseTable
    {
        public SysParaD()
            : base("T_Sys_Para", "Ing_pk_PID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(SysParaM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 参数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(SysParaM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<SysParaM>(model, model.Ing_pk_PID);
            model.Ing_pk_PID = this.lngKeyID;
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
        /// 取某条数据
        /// </summary>
        /// <param name="str_ParaType"></param>
        /// <param name="str_ParaCode"></param>
        /// <returns></returns>
        public SysParaM GetRecord(string str_ParaType, string str_ParaCode)
        {
            string strSql = "SELECT * from T_Sys_Para a WHERE a.str_ParaType='{0}' AND a.str_ParaCode='{1}'";
            strSql = string.Format(strSql, str_ParaType, str_ParaCode);

            return this.GetQueryM<SysParaM>(strSql).FirstOrDefault();
        }
    }
}
