using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SMSBasePlatD:BaseTable
    {
        public SMSBasePlatD()
            : base("T_SMSBasePlat", "Ing_pk_sd")
        { }

        #region Ìí¼Ó£¬É¾³ý£¬ÐÞ¸Ä
        /// <summary>
        /// ¼ì²é¸üÐÂ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(SMSBasePlatM model)
        {            
            return true;
        }

        /// <summary>
        /// ±£´æ ¶ÌÐÅÅäÖÃ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(SMSBasePlatM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<SMSBasePlatM>(model, model.Ing_pk_sd);
            model.Ing_pk_sd = this.lngKeyID;
            return rev;
        }


        
        /// <summary>
        /// ¼ì²éÉ¾³ý
        /// </summary>
        /// <param name="lnguserid"></param>
        /// <returns></returns>
        public bool CheckDelete(int id)
        {
            return true;
        }


        /// <summary>
        /// É¾³ý
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
