using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AwardGoodsD:BaseTable
    {
        public AwardGoodsD()
            : base("T_AwardGoods", "Ing_AwardGoodsID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(AwardGoodsM model)
        {            
            return true;
        }

        /// <summary>
        /// 保存 抽奖奖品领取设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(AwardGoodsM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev= this.UpdateRecord<AwardGoodsM>(model, model.Ing_AwardGoodsID);
            model.Ing_AwardGoodsID = this.lngKeyID;
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
        /// 判断该用户是否已经抽奖过了
        /// </summary>
        /// <param name="VipcardID"></param>
        /// <returns></returns>
        public bool AlreadyAward(int VipcardID)
        {
            string strSql = "SELECT count(1) FROM dbo.T_AwardGoods a WHERE ISNULL(a.Ing_VipcardID,0)={0}";
            strSql = string.Format(strSql,VipcardID);

            return this.Sqlca.GetInt32(strSql) > 0;
        }

        /// <summary>
        /// 查找某人的奖品
        /// </summary>
        /// <param name="VipcardID"></param>
        /// <returns></returns>
        public List<AwGoodModel> GetGoods(int VipcardID)
        {
            string strSql = "SELECT * FROM dbo.V_AwardGoods a WHERE a.Ing_VipcardID={0}";
            strSql = string.Format(strSql,VipcardID);

            return this.GetQueryM<AwGoodModel>(strSql);
        }
    }
}
