using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CommentsD:BaseTable
    {
        public CommentsD()
            : base("T_Comments", "Ing_Pk_comID")
        {
            
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(CommentsM model)
        {
            CommentsM m = GetRecordByMasID(model.Ing_MasterID);
            if (m != null)
            {
                this.LastError = "L已经评论过，不能再次评论";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 保存 用户评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(CommentsM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            model.dt_comDate=DateTime.Now;
            bool rev= this.UpdateRecord<CommentsM>(model, model.Ing_Pk_comID);
            model.Ing_Pk_comID = this.lngKeyID;
            ///如果保存失败，就不用推送消息了
            if (!rev)
            {
                return rev;
            }

            ParaForVipCardChargeM mod = new ParaForVipCardChargeM();
            mod.Ing_Pk_VipCardID = model.Ing_VipcardID;
            mod.chargemon = 50;
            mod.chargeType = 25;
            mod.Reamrk = "微信评价送积分";
            VipCardInfoD cardD = new VipCardInfoD();
            cardD.VipCardChargeExec(mod);


            ///如果客人满意，并且 没有填写建议的，就不用推送消息了
            if (model.Ing_total == 0 && string.IsNullOrEmpty(model.str_good) && string.IsNullOrEmpty(model.str_bad))
            {
                return rev;
            }

            UsersGrpD dal1 = new UsersGrpD();
            List<UsersGrpM> list = dal1.GetManagerByStoreID(model.Ing_StoreID);
            ///如果没有消息接收人员，就直接返回
            if (list == null || list.Count == 0)
            {
                return rev;
            }

            WeChatQuestionM m1 = new WeChatQuestionM();
            WeChatD weD = new WeChatD();
            m1.serviceInfo = "您管辖的门店有一条新的评价";
            m1.serviceType = "投诉建议";
            m1.serviceStatus = "刚提交";
            m1.CommentID = model.Ing_Pk_comID;
            string remark = string.Empty;
            remark = string.Format("{0}满意",model.Ing_total==0?"":"不");
            if (!string.IsNullOrEmpty(model.str_good))
            {
                remark = string.Format("{0}\\r优点：{1}", remark, model.str_good);
            }
            if (!string.IsNullOrEmpty(model.str_bad))
            {
                remark = string.Format("{0}\\r建议：{1}", remark, model.str_bad);
            }
            m1.remark = string.Format("{0}\\r点击进行回复", remark);

            foreach (UsersGrpM m in list)
            {
                m1.Openid = m.str_openid;
                weD.OrderComment(m1);
            }
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
        /// 根据主单获取评论记录
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public CommentsM GetRecordByMasID(int MasterID)
        {
            string strSql = "SELECT * FROM dbo.T_Comments a WHERE ISNULL(a.Ing_MasterID,0)={0}";
            strSql = string.Format(strSql,MasterID);

            return this.GetQueryM<CommentsM>(strSql).FirstOrDefault();
        }
        /// <summary>
        /// 获取酒店总的好评
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public List<CommentsM> GetGoodRecordByStoreID(int StoreID)
        {
            //string strSql = "SELECT * FROM dbo.T_Comments a WHERE ISNULL(a.Ing_StoreID,0)={0} AND ISNULL(a.Ing_total,0)=0 AND ISNULL(a.Ing_del,0)=0 order by Ing_Pk_comID desc";
            string strSql = "SELECT * FROM dbo.T_Comments a WHERE ISNULL(a.Ing_StoreID,0)={0} AND ISNULL(a.Ing_del,0)=0 order by Ing_Pk_comID desc";
            strSql = string.Format(strSql, StoreID);
            return this.GetQueryM<CommentsM>(strSql);
        }
        /// <summary>
        /// 得到门店总的评论数
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public int GetTotalByStoreID(int StoreID)
        {
            string strSql = "SELECT COUNT(*) FROM dbo.T_Comments a WHERE ISNULL(a.Ing_StoreID,0)={0} AND ISNULL(a.Ing_del,0)=0";
            strSql = string.Format(strSql,StoreID);
            return this.Sqlca.GetInt32(strSql);
        }


        /// <summary>
        /// 得到门店总的好评数
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public int GetGoodByStoreID(int StoreID)
        {
            string strSql = "SELECT COUNT(*) FROM dbo.T_Comments a WHERE ISNULL(a.Ing_StoreID,0)={0} AND ISNULL(a.Ing_total,0)=0 AND ISNULL(a.Ing_del,0)=0";
            strSql = string.Format(strSql, StoreID);
            return this.Sqlca.GetInt32(strSql);
        }
    }
}
