using Bee.Web;
using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AwardD : BaseTable
    {
        public AwardD()
            : base("T_Award", "Ing_AwardID")
        { }

        #region 添加，删除，修改
        /// <summary>
        /// 检查更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CheckUpdateM(AwardM model)
        {
            return true;
        }

        /// <summary>
        /// 保存 抽奖奖品设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveOrUpdate(AwardM model)
        {
            if (!CheckUpdateM(model))
            {
                return false;
            }
            bool rev = this.UpdateRecord<AwardM>(model, model.Ing_AwardID);
            model.Ing_AwardID = this.lngKeyID;
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
        /// 获取所有有效的奖项设置
        /// </summary>
        /// <returns></returns>
        public List<AwardM> GetUseFulAward()
        {
            string strSql = "SELECT * FROM T_Award a WHERE ISNULL(a.Ing_Amount,0)>0 AND DATEDIFF(DAY,a.dt_Start,GETDATE())>=0 AND DATEDIFF(DAY,GETDATE(),a.dt_End)>=0";
            return this.GetQueryM<AwardM>(strSql);
        }

        /// <summary>
        /// 得到抽奖的随机奖项
        /// </summary>
        /// <param name="vipcardID"></param>
        /// <returns></returns>
        public AwardM GetAward(int vipcardID)
        {
            //如果会员卡id=0,说明该微信还没有绑定
            if (vipcardID == 0)
            {
                this.LastError = "L你还未绑定，请关闭此页面，绑定后再进行抽奖";
                return null;
            }

            AwardGoodsD goodsD = new AwardGoodsD();
            if (goodsD.AlreadyAward(vipcardID))
            {
                this.LastError = "L亲，你已经抽奖过了哦!";
                return null;
            }

            List<AwardM> list = new List<AwardM>();
            list = this.GetUseFulAward();
            if (list == null || list.Count == 0)
            {
                this.LastError = "L还未设定奖项或者名额已经用完，请联系管理员";
                return null;
            }

            #region 随机抽奖
            int sum = list.Sum(x => x.Ing_Amount);

            Random rn = new Random();
            int key = rn.Next(sum);

            sum = 0;

            AwardM model = null;
            foreach (AwardM m in list)
            {
                sum += m.Ing_Amount;
                if (key <= sum)
                {
                    model = m;
                    break;
                }
            }
            if (model == null)
            {
                this.LastError = "L还未设定奖项或者名额已经用完，请联系管理员!";
                return null;
            }
            #endregion

            ///插入奖品
            AwardGoodsM m1 = new AwardGoodsM();
            m1.dt_Create = DateTime.Now;
            m1.Ing_AwardID = model.Ing_AwardID;
            m1.Ing_VipcardID = vipcardID;
            m1.Ing_Sta = 0;
            if (model.Ing_RealGoods == 0)
            {
                //如果是虚拟物品，直接领取
                m1.dt_Modify = DateTime.Now;
                m1.str_Modify = "WeChat";
                m1.Ing_StoreID = 0;
                m1.Ing_Sta = 1;
            }


            if (goodsD.AlreadyAward(vipcardID))
            {
                this.LastError = "L亲，你已经抽奖过了哦!";
                return null;
            }

            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }

            if (!goodsD.UpdateRecord<AwardGoodsM>(m1, 0, this.Sqlca))
            {
                this.LastError = "L系统繁忙，请稍后再试!";
                goto updateerr;
            }

            ///是不是抽一次，这个奖品的数量要减1，暂时先注释掉
            //model.Ing_Amount -= 1;
            //if (!this.UpdateRecord<AwardM>(model, model.Ing_AwardID, this.Sqlca))
            //{
            //    this.LastError = "L系统繁忙，请稍后再试!";
            //    goto updateerr;
            //}

            if (model.Ing_level == 1 || model.Ing_level == 2)
            {
                //插入对应的优惠券信息
                if (model.Ing_CouponTypeID == 0)
                {
                    this.LastError = "L系统繁忙，请稍后再试1!";
                    goto updateerr;
                }
                if (!this.CreateCoupponDetail(vipcardID, model.Ing_CouponTypeID, 0, this.Sqlca))
                {
                    this.LastError = "L系统繁忙，请稍后再试2!";
                    goto updateerr;
                }
            }


            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();

            return model;

        updateerr:
            if (string.IsNullOrEmpty(this.LastError))
            {
                this.LastError = this.Sqlca.LastError;
            }
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            return null;
        }


        /// <summary>
        /// 根据会员卡号生成优惠券
        /// </summary>
        /// <param name="vipCardId"></param>
        /// <returns></returns>
        public bool CreateCoupponDetail(int vipCardInfoId, int coupontypeId = 0, int ingmonth = 0, DataTrans DataTrans = null)
        {
            if (DataTrans != null)
            {
                this.Sqlca = DataTrans;
            }

            string strSql = "EXEC U_CreateCouponDetail @StoreId,@VipCardInfoId,@UserName,@CouponTypeId,@ingmonth";
            this.Sqlca.AddParameter("@StoreId", 0);
            this.Sqlca.AddParameter("@VipCardInfoId", vipCardInfoId);
            this.Sqlca.AddParameter("@UserName", "WeChat");
            this.Sqlca.AddParameter("@CouponTypeId", coupontypeId);
            this.Sqlca.AddParameter("@ingmonth", ingmonth);
            bool rev = this.Sqlca.ExecuteNonQuery(strSql);
            this.Sqlca.ClearParameter();
            return rev;
        }
    }
}
