using Bee.Web;
using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccD : BaseTable
    {
        public AccD()
            : base("T_Acc", "Ing_Acc_Id")
        {

        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(AccM model)
        {
            return true;
        }

        /// <summary>
        /// 保存 账务表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(AccM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev = this.UpdateRecord<AccM>(model, model.Ing_Acc_Id);
            model.Ing_Acc_Id = this.lngKeyID;
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
        /// 得到有效账务
        /// </summary>
        /// <param name="Ing_Fk_MasterID"></param>
        /// <returns></returns>
        public List<AccM> GetUseFulAcc(int Ing_Fk_MasterID)
        {
            string strSql = "SELECT * FROM dbo.T_Acc a WHERE a.Ing_Fk_MasterID={0} AND a.Ing_sta=1";
            strSql = string.Format(strSql,Ing_Fk_MasterID);

            return this.GetQueryM<AccM>(strSql);
        }


        /// <summary>
        /// 插入账务
        /// </summary>
        /// <param name="model"></param>
        /// <param name="DataTrans"></param>
        /// <returns></returns>
        public bool InsertAcct(AccM model, int Itype, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }
            string strSql = "EXEC U_T_Acc_ADD @Ing_StoreID,@Ing_Fk_MasterID,@pk_accnt,@CreateDate,@pccode,@argcode,@quantity,@totalCharge,@BaseCharge,@Balance,@Shift,@Empno,@RoomNo,@GroupNo,@Billno,@Reason,@Description,@Crradjt,@Itype,@VipCard";

            this.Sqlca.AddParameter("@Ing_StoreID", model.Ing_StoreID);
            this.Sqlca.AddParameter("@Ing_Fk_MasterID", model.Ing_Fk_MasterID);
            this.Sqlca.AddParameter("@pk_accnt", model.str_Pk_Accnt);
            this.Sqlca.AddParameter("@CreateDate", DateTime.Now);
            this.Sqlca.AddParameter("@pccode", model.str_PcCode);
            this.Sqlca.AddParameter("@argcode", model.str_ArgCode);
            this.Sqlca.AddParameter("@quantity", model.Ing_Qty);
            this.Sqlca.AddParameter("@totalCharge", model.dec_TotalCharge);
            this.Sqlca.AddParameter("@BaseCharge", model.dec_BaseCharge);
            this.Sqlca.AddParameter("@Balance", model.dec_Balance);
            this.Sqlca.AddParameter("@Shift", "");
            this.Sqlca.AddParameter("@Empno", "WeChat");
            this.Sqlca.AddParameter("@RoomNo", model.str_RoomNo);
            this.Sqlca.AddParameter("@GroupNo", model.str_GroupNo);
            this.Sqlca.AddParameter("@Billno", model.Ing_Billno);
            this.Sqlca.AddParameter("@Reason", model.str_Reason);
            this.Sqlca.AddParameter("@Description", model.str_desc);
            this.Sqlca.AddParameter("@Crradjt", model.str_Crradjt);
            this.Sqlca.AddParameter("@Itype", Itype);
            this.Sqlca.AddParameter("@VipCard", model.str_VipCard);

            bool rev = this.Sqlca.ExecuteNonQuery(strSql);

            this.Sqlca.ClearParameter();
            return rev;
        }       
    }
}
