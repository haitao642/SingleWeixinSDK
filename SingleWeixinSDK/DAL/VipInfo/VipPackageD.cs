using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Public;
namespace DAL
{
    public class VipPackageD : BaseTable
    {
        public VipPackageD()
            : base("T_VipPackage", "Ing_PKID")
        {

        }

        /// <summary>
        /// 根据code获取活动
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public VipPackageM GetPackageModel(string code) 
        {
            string strSql = "SELECT a.* FROM T_VipPackage a where a.Ing_Sta=1 AND a.str_Code=@code";
            this.Sqlca.AddParameter("@code",code);
            return this.GetQueryM<VipPackageM>(strSql).FirstOrDefault();
        }

        /// <summary>
        ///  微信扫码活动赠送礼包
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuyPackage(BuyPackageM model)
        {

            VipCardInfoD infoD = new VipCardInfoD();
            VipPackageM packM = model.packM;
            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = "L开启事务失败";
                goto updateerr;
            }

            //赠送积分
            if (packM.dec_Integral.HasValue && packM.dec_Integral.Value > 0)
            {
                ParaForVipCardChargeM jifenM = new ParaForVipCardChargeM();
                jifenM.Ing_Pk_VipCardID = model.vipcardid;
                jifenM.chargemon = packM.dec_Integral.Value;
                jifenM.chargeType = 1;
                jifenM.Reamrk = "微信扫码赠送积分";
                if (!infoD.VipCardChargeExec(jifenM, this.Sqlca))
                {
                    this.LastError = "L赠送积分失败";
                    goto updateerr;
                }

            }
            if (packM.Ing_Fk_CouponId.HasValue && packM.Ing_Fk_CouponId.Value > 0)
            {
                CouponDetailsD couponDetail = new CouponDetailsD();
                CreateCoupponM coupponM = new CreateCoupponM();
                coupponM.vipCardInfoId = model.vipcardid;
                coupponM.coupontypeId = packM.Ing_Fk_CouponId.Value;
                if (!couponDetail.CreateCoupponDetail(coupponM, this.Sqlca))
                {
                    this.LastError = "L创建优惠券失败";
                    goto updateerr;
                }

            }

            //保存微信扫码活动记录
            WechatActivityLogD WechatLogD = new WechatActivityLogD();
            WechatActivityLogM WechatLogM = new WechatActivityLogM();
            WechatLogM.Ing_Type = model.type;
            WechatLogM.str_Openid = model.openid;
            WechatLogM.Ing_VipPackageId = model.packageid;
            WechatLogM.str_Remark = "微信扫码";
            WechatLogM.dt_Create = DateTime.Now;
            WechatLogM.str_Creator = "微信公众号";
            if (!WechatLogD.UpdateRecord<WechatActivityLogM>(WechatLogM)) 
            {
                this.LastError = "L记录保存失败";
                goto updateerr;
            }
            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();
            return true;
        updateerr:
            if (string.IsNullOrEmpty(this.LastError))
            {
                this.LastError = this.Sqlca.LastError;
            }
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            return false;

        }


        /// <summary>
        /// 获取活动使用的门店
        /// </summary>
        /// <param name="type">类型(0优惠券，1活动)</param>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public List<HotelSimpleM> RangeCaption(int type, int id) 
        {
            StoreInfoD storeD = new StoreInfoD();
            CouponTypeD typeD = new CouponTypeD();
            List<HotelSimpleM> list = storeD.GetHotelSimpleList();
            if (list == null || list.Count == 0) 
            {
                return list;
            }

            //通过礼包，找优惠券类型id
            if (type ==1) 
            {
                VipPackageM packM = this.GetM<VipPackageM>(id);
                if (packM == null) 
                {
                    return null;
                }
                id = packM.Ing_Fk_CouponId.HasValue ? packM.Ing_Fk_CouponId.Value : 0;
            }

            CouponTypeM mm = typeD.GetM<CouponTypeM>(id);
            if (mm == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(mm.str_UseArea))
            {
                return list;
            }
            if (("," + mm.str_UseArea + ",").Contains(",0,"))
            {
                return list;
            }
            List<HotelSimpleM> tempList = new List<HotelSimpleM>();
            foreach (string item in mm.str_UseArea.Split(',')) 
            {
                if (string.IsNullOrEmpty(item)) 
                {
                    continue;
                }
                int num = 0;
                int.TryParse(item, out num);
                tempList.AddRange(list.Where(a => a.Ing_StoreID == num));
            }

            return tempList;
        }
    }
}
