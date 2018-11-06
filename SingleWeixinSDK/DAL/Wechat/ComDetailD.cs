using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ComDetailD:BaseTable
    {
        public ComDetailD()
            : base("T_ComDetail", "Ing_DetailID")
        {
            this.Sqlca = this.SqlcaWeChat();
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(ComDetailM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 客户的进度跟踪表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(ComDetailM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<ComDetailM>(model, model.Ing_DetailID);
            model.Ing_DetailID = this.lngKeyID;
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
        /// 根据评论id获取跟踪列表
        /// </summary>
        /// <param name="comid"></param>
        /// <returns></returns>
        public List<ComDetailM> GetList(int comid)
        {
            string strSql = "SELECT * FROM T_ComDetail a WHERE a.Ing_ComID={0} ORDER BY a.dt_com desc";
            strSql = string.Format(strSql,comid);

            return this.GetQueryM<ComDetailM>(strSql);
        }

        /// <summary>
        /// 客评跟踪
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveDetail(ComDetailM model)
        {
            if (model == null)
            {
                this.LastError = "L参数错误";
                return false;
            }            
            model.dt_Com = DateTime.Now;
            if (model.Ing_UserID > 0)
            {
                model.Ing_Result = null;
                if (string.IsNullOrEmpty(model.str_Result))
                {
                    this.LastError = "L请填写内容，再进行回复";
                    return false;
                }
            }
            if (!this.UpdateRecord<ComDetailM>(model, model.Ing_DetailID))
            {
                this.LastError = "L操作出错";
                return false;
            }

            if (string.IsNullOrEmpty(model.openids))
            {
                return true;
            }

            List<string> list = model.openids.Split(',').ToList();
            if (list.Count == 0)
            {
                return true;
            }

            WeChatQuestionM m1 = new WeChatQuestionM();
            WeChatD weD = new WeChatD();
            string remark = string.Empty;
            if (model.Ing_UserID == 0)
            {
                if ((model.Ing_Result.HasValue && model.Ing_Result.Value == 0) && string.IsNullOrEmpty(model.str_Result))
                {
                    return true;
                }
                m1.serviceInfo = "您管辖的门店有一条新的客评跟踪";
                m1.serviceType = "投诉建议";
                m1.serviceStatus = "再次提交";
                m1.CommentID = model.Ing_ComID ?? 0;
                remark = string.Format("{0}满意", (model.Ing_Result.HasValue && model.Ing_Result.Value == 0) ? "" : "不");
                if (!string.IsNullOrEmpty(model.str_Result))
                {
                    remark = string.Format("{0}\\r内容：{1}", remark, model.str_Result);
                }
                m1.remark = string.Format("{0}\\r点击进行回复", remark);
            }
            else
            {
                m1.serviceInfo = "你有一条新的店长回复";
                m1.serviceType = "问题回复";
                m1.serviceStatus = "回复";
                m1.CommentID = model.Ing_ComID ?? 0;
                if (!string.IsNullOrEmpty(model.str_Result))
                {
                    remark = string.Format("{0}内容：{1}", remark, model.str_Result);
                }
                m1.remark = string.Format("{0}\\r点击进行回复", remark);
            }

            foreach (string m in list)
            {
                m1.Openid = m;
                weD.OrderComment(m1);
            }

            return true;
        }
    }
}
