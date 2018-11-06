using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SysBusnTypeD:BaseTable
    {
        public SysBusnTypeD()
            : base("T_Sys_BusnType", "Ing_pk_TypeID")
        {
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(SysBusnTypeM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 基本配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(SysBusnTypeM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<SysBusnTypeM>(model, model.Ing_pk_TypeID);
            model.Ing_pk_TypeID = this.lngKeyID;
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
        /// 返回相应的记录
        /// </summary>
        /// <param name="BusineTypeID">NormalType SecretType FeaturesType ChannelType InterType</param>
        /// <returns></returns>
        public List<SysBusnTypeM> GetBusnTypeByBusineTypeID(string BusineTypeID)
        {
            BusineTypeID = BusineTypeID.Replace("'","''");
            string strSql = "select * from {0} a WHERE a.Ing_sta=1 AND a.str_BusineTypeID='{1}'";
            strSql = string.Format(strSql,tablename,BusineTypeID);
            return this.GetQueryM<SysBusnTypeM>(strSql);
        }

        
    }
}
