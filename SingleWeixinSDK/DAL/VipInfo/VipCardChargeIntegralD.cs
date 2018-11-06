using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VipCardChargeIntegralD:BaseTable
    {
        public VipCardChargeIntegralD()
            : base("T_VipCard_ChargeIntegral", "Ing_pk_CintID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(VipCardChargeIntegralM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 充值记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(VipCardChargeIntegralM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<VipCardChargeIntegralM>(model, model.Ing_pk_CintID);
            model.Ing_pk_CintID = this.lngKeyID;
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
        /// 根据openid获取积分记录
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public List<VipCardChargeIntegralM> GetListbyOpenid(string openid)
        {
            string strSql = @"SELECT a.* from T_VipCard_ChargeIntegral a 
                                INNER JOIN T_VipCard_Info b on a.Ing_Fk_VipCardID=b.Ing_Pk_VipCardId
                                where ISNULL(b.str_wcopenid,'')<>'' AND ISNULL(b.str_wcopenid,'')=@openid
                                ORDER BY a.Ing_pk_CintID DESC";
            this.Sqlca.AddParameter("@openid",openid);

            List<VipCardChargeIntegralM> list = this.GetQueryM<VipCardChargeIntegralM>(strSql);
            this.Sqlca.ClearParameter();
            return list;
        }

        /// <summary>
        /// 根据会员卡id查找积分记录
        /// </summary>
        /// <param name="cardid"></param>
        /// <returns></returns>
        public List<VipCardChargeIntegralM> GetListbyVipcardid(int cardid)
        {
            string strSql = @"SELECT a.* from T_VipCard_ChargeIntegral a WHERE a.Ing_Fk_VipCardID=@cardid
                                ORDER BY a.Ing_pk_CintID DESC";
            this.Sqlca.AddParameter("@cardid", cardid);

            List<VipCardChargeIntegralM> list = this.GetQueryM<VipCardChargeIntegralM>(strSql);
            this.Sqlca.ClearParameter();
            return list;
        }


    }
}
