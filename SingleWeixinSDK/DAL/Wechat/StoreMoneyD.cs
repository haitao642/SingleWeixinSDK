using Model.WeChat;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Wechat
{
    public class StoreMoneyD: BaseTable
    {
        public StoreMoneyD() : base("T_Store_Money_Detail", "Ing_Pk_id")
        {

        }
        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(StoreMoneyM model)
        {
            return true;
        }

        /// <summary>
        /// 保存 门店图片表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(StoreMoneyM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev = this.UpdateRecord<StoreMoneyM>(model, model.Ing_Pk_id);
            model.Ing_Pk_id = this.lngKeyID;
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
