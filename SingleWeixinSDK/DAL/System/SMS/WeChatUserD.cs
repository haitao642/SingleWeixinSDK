using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class WeChatUserD:BaseTable
    {
        public WeChatUserD()
            : base("T_WeChat_User", "Ing_WeChat_UserID")
        {
            
        }

        #region 添加，删除，修改
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
        /// 根据openid和类型查找记录
        /// </summary>
        /// <param name="openid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public WeChatUserM GetRecordByOpenid(string openid, int type)
        {
            string strSql = @"SELECT * FROM dbo.T_WeChat_User a WHERE a.OpenID=@openid AND a.Ing_type=@type";
            this.Sqlca.AddParameter("@openid",openid);
            this.Sqlca.AddParameter("@type", type);
            WeChatUserM model = this.GetQueryM<WeChatUserM>(strSql).FirstOrDefault();
            this.Sqlca.ClearParameter();
            return model;
        }


        /// <summary>
        /// 查询哪个类型的微信接收者
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<WeChatUserM> GetList(int type, int StoreID = 0)
        {
            string strSql = "select * from T_WeChat_User a where (isnull(a.Ing_StoreID,0)=0 or a.Ing_StoreID={0}) and a.Ing_type={1} and a.Ing_sta=1";

            strSql = string.Format(strSql, StoreID, type);

            return this.GetQueryM<WeChatUserM>(strSql);
        }
    }
}
