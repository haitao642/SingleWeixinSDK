using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShareRecordD:BaseTable
    {
        public ShareRecordD()
            : base("T_ShareRecord", "Ing_Pk_id")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(ShareRecordM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 微信分享
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(ShareRecordM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<ShareRecordM>(model, model.Ing_Pk_id);
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

        /// <summary>
        /// 根据openid,查看 被推荐的记录
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public ShareRecordM GetRecordByopenid(string openid)
        {
            string strSql = "SELECT * FROM T_ShareRecord a WHERE ISNULL(a.str_openid,'')='{0}'";
            strSql = string.Format(strSql,openid);

            return this.GetQueryM<ShareRecordM>(strSql).FirstOrDefault();
        }

        /// <summary>
        /// 根据会员卡id查找，推荐这个人的记录
        /// </summary>
        /// <param name="vipcardid"></param>
        /// <returns></returns>
        public ShareRecordM GetRecordByvipcardid(int vipcardid)
        {
            string strSql = @"SELECT a.* FROM dbo.T_ShareRecord a INNER JOIN dbo.T_VipCard_Info b ON a.str_openid=b.str_wcopenid
                                 WHERE ISNULL(a.Ing_sta,0)=0 AND b.Ing_Pk_VipCardId={0}";
            strSql = string.Format(strSql,vipcardid);

            return this.GetQueryM<ShareRecordM>(strSql).FirstOrDefault();
        }

        #region 添加分享记录
        /// <summary>
        /// 添加分享记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddShare(ShareRecordM model)
        {
            if (model == null)
            {
                this.LastError = "L参数为空";
                return false;
            }
            if (model.Ing_VipCardID == 0)
            {
                this.LastError = "L推荐者的id为0，不能保存";
                return false;
            }
            if (string.IsNullOrEmpty(model.str_openid))
            {
                this.LastError = "L被推荐都的openid为空，不能保存";
                return false;
            }

            ShareRecordM model1 = GetRecordByopenid(model.str_openid);
            if (model1 == null) model1 = new ShareRecordM();
            if (model1.Ing_sta == 1)
            {
                this.LastError = "L被推荐人已经储值过了，不能保存";
                return false;
            }
            model1.Ing_VipCardID = model.Ing_VipCardID;
            model1.str_openid = model.str_openid;

            return this.UpdateRecord<ShareRecordM>(model1, model1.Ing_Pk_id);
        }

        #endregion
    }
}
