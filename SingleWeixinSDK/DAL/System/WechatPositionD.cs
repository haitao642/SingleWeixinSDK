using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WechatPositionD:BaseTable
    {
        public WechatPositionD()
            : base("T_WechatPosition", "Ing_PositionID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(WechatPositionM model)
        {
            if (model == null)
            {
                this.LastError = "L参数为空";
                return false;
            }
            if (string.IsNullOrEmpty(model.openid))
            {
                //this.LastError = "Lopenid为空了";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存 微信所在位置表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(WechatPositionM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }

            WechatPositionM res = GetPositionByopenid(model.openid);
            if (res != null)
            {
                model.Ing_PositionID = res.Ing_PositionID;
            }
            model.dt_Create = DateTime.Now;

            bool rev= this.UpdateRecord<WechatPositionM>(model, model.Ing_PositionID);
            model.Ing_PositionID = this.lngKeyID;
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
        /// 根据openid获取位置信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public WechatPositionM GetPositionByopenid(string openid)
        {
            string strSql = "select top 1 * from T_WechatPosition a where a.openid=@openid";
            this.Sqlca.AddParameter("@openid",openid);

            WechatPositionM model = new WechatPositionM();
            model = this.GetQueryM<WechatPositionM>(strSql).FirstOrDefault();
            this.Sqlca.ClearParameter();

            return model;
        }
    }
}
