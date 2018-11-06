using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CouponTypeD:BaseTable
    {
        public CouponTypeD()
            : base("T_CouponType", "Ing_CouponTypeID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(CouponTypeM model)
        {         
   
           //查询是否重复
            List<CouponTypeM> coupTypeModel = this.GetAllM<CouponTypeM>();
            CouponTypeM  c= coupTypeModel.Where(a => a.str_SendType.Equals(model.str_SendType) || a.str_PaperName.Equals(model.str_PaperName)).FirstOrDefault();
            if (c != null)
            {
                this.LastError="L活动代码或者活动名称重复";
                return false;
            }


            return true;
        }

        /// <summary>
        /// 保存 优惠券类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(CouponTypeM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
          
            bool rev= this.UpdateRecord<CouponTypeM>(model, model.Ing_CouponTypeID);
            model.Ing_CouponTypeID = this.lngKeyID;
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
        /// 获取微信端  积分兑换抵用券的活动
        /// </summary>
        /// <returns></returns>
        public CouponTypeM GetWechatType(string str="")
        {
            if (string.IsNullOrEmpty(str)) 
            {
                str = ConfigValue.WeChatCard;
            }
            string strSql = "SELECT top 1 * FROM dbo.T_CouponType a WHERE a.str_SendType='{0}' ORDER by a.Ing_CouponTypeID DESC";
            strSql = string.Format(strSql,str);

            return this.GetQueryM<CouponTypeM>(strSql).FirstOrDefault();
        }
    }
}
