using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WechatStoreInfoD:BaseTable
    {
        public WechatStoreInfoD()
            : base("T_Wechat_Store_Info", "Ing_StoreID")
        {
            this.Sqlca = SqlcaWeChat();
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(WechatStoreInfoM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 门店信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(WechatStoreInfoM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<WechatStoreInfoM>(model, model.Ing_StoreID);
            model.Ing_StoreID = this.lngKeyID;
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
        /// 查询酒店
        /// </summary>
        /// <param name="topnum"></param>
        /// <param name="str_city"></param>
        /// <returns></returns>
        public List<SearchStoreInfoM> SearchHotel(int topnum, string str_city)
        {
            this.Sqlca = this.SqlcaWeChat();
            ///查询全部，还是几条
            string top = string.Empty;
            if (topnum > 0)
            {
                top = string.Format(" top {0}", topnum);
            }

            string strSql = @"SELECT {0} a.Ing_StoreID,a.str_StoreName,a.str_city,a.str_Address,
                                    isnull((SELECT TOP 1 b.str_DLPath FROM T_StoreImg b WHERE b.Ing_StoreID=a.Ing_StoreID),'') str_DLPath
                                     FROM T_Wechat_Store_Info a 
                                    where a.Ing_State=1 AND a.str_city=@str_city";
            strSql = string.Format(strSql,top);

            this.Sqlca.AddParameter("@str_city", str_city);

            List<SearchStoreInfoM> list = this.GetQueryM<SearchStoreInfoM>(strSql);
            this.Sqlca.ClearParameter();
            return list;


        }
    }
}
