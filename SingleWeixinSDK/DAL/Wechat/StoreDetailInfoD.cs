using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StoreDetailInfoD:BaseTable
    {
        public StoreDetailInfoD()
            : base("T_StoreDetailInfo", "Ing_StoreDetailInfoID")
        {
            this.Sqlca = SqlcaWeChat();
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(StoreDetailInfoM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 门店详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(StoreDetailInfoM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<StoreDetailInfoM>(model, model.Ing_StoreDetailInfoID);
            model.Ing_StoreDetailInfoID = this.lngKeyID;
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
        /// 根据门店ID 查找门店详情
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public StoreDetailInfoM GetOne(int Ing_StoreID)
        {
            StoreDetailInfoM model = new StoreDetailInfoM();
            string strSql = "SELECT * from T_StoreDetailInfo a where a.Ing_StoreID=@Ing_StoreID";

            this.Sqlca.AddParameter("@Ing_StoreID",Ing_StoreID);

            model = this.GetQueryM<StoreDetailInfoM>(strSql).FirstOrDefault();
            this.Sqlca.ClearParameter();

            return model;
        }

        /// <summary>
        /// 获取在查询酒店列表用到的信息
        /// </summary>
        /// <param name="storeids"></param>
        /// <returns></returns>
        public List<DetailInfoInListM> GetList(string storeids)
        {
            string strSql = "SELECT a.Ing_StoreID,a.str_Address,a.str_mapX,a.str_mapY FROM dbo.T_StoreDetailInfo a WHERE a.Ing_StoreID IN ({0})";
            strSql = string.Format(strSql,storeids);

            return this.GetQueryM<DetailInfoInListM>(strSql);
        }
    }
}
