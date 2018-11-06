using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TimeRoomRuleD:BaseTable
    {
        public TimeRoomRuleD()
            : base("T_TimeRoomRule", "Ing_PID")
        {
        }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(TimeRoomRuleM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 锁房规则
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(TimeRoomRuleM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<TimeRoomRuleM>(model, model.Ing_PID);
            model.Ing_PID = this.lngKeyID;
            return rev;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public List<TimeRoomRuleM> GetAllList()
        {
            string strSql = "select * from V_TimeRoomRule";

            return this.GetQueryM<TimeRoomRuleM>(strSql);
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
        /// 获取钟点房规则
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="RoomType"></param>
        /// <returns></returns>
        public List<TimeRoomRuleM> GetRule(int Ing_StoreID,string RoomType)
        {
            string strSql = @"SELECT * FROM dbo.T_TimeRoomRule a WHERE a.Ing_Sta=1 AND a.str_Remark='wechat'
                                AND ISNULL(a.str_RoomType,'-')='{1}'";
            strSql = string.Format(strSql,Ing_StoreID,RoomType);
            return this.GetQueryM<TimeRoomRuleM>(strSql);
        }
    }
}
