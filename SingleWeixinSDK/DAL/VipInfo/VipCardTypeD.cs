using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bee.Web;
namespace DAL
{
    public class VipCardTypeD:BaseTable
    {
        public VipCardTypeD()
            : base("T_VipCard_Type", "Ing_CardTypeID")
        {
        }

        #region ��ӣ�ɾ�����޸�
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(VipCardTypeM model)
        {            
            return true;
        }

        /// <summary>
        /// ���� ��Ա������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(VipCardTypeM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<VipCardTypeM>(model, model.Ing_CardTypeID);
            model.Ing_CardTypeID = this.lngKeyID;
            return rev;
        }


        
        /// <summary>
        /// ���ɾ��
        /// </summary>
        /// <param name="lnguserid"></param>
        /// <returns></returns>
        public bool CheckDelete(int id)
        {
            return true;
        }


        /// <summary>
        /// ɾ��
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
        public VipCardTypeM GetVipCardType(int CardTypeID)
        {
            if (CardTypeID<=0)
            {
                return null;
            }
            string strSql = "SELECT * FROM T_VipCard_Type a WITH (NOLOCK) WHERE a.Ing_Halt=1 AND a.Ing_CardTypeID=@CardTypeID";

            this.Sqlca.AddParameter("@CardTypeID", CardTypeID);

            VipCardTypeM model = this.GetQueryM<VipCardTypeM>(strSql).FirstOrDefault();
            if (model == null) { }
            this.Sqlca.ClearParameter();

            return model;
        }
    }
}
