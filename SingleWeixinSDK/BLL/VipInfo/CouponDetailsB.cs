using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class CouponDetailsB
    {
        public DAL.CouponDetailsD dal = new DAL.CouponDetailsD();

        /// <summary>
        /// 获取有效的优惠券数量
        /// </summary>
        /// <param name="vipcardid"></param>
        /// <returns></returns>
        public int GetUseFulCount(int vipcardid)
        {
            return dal.GetUseFulCount(vipcardid);
        }


        
        /// <summary>
        /// 根据类型返回优惠券
        /// </summary>
        /// <param name="vipcardid">vipcardid</param>
        /// <param name="type">0:无效   1：有效   2：过期</param>
        /// <returns></returns>
        public List<CouponDetailsM> GetListbytype(int vipcardid, int type)
        {
            return dal.GetListbytype(vipcardid, type);
        }


        /// <summary>
        /// 抵扣券支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel CouponPay(ParaForCoponPayM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.CouponPay(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 根据主单查询有效的优惠券
        /// </summary>
        /// <param name="MasterID"></param>
        /// <param name="type">0:普通1变房价</param>
        /// <returns></returns>
        public List<ResultCouponM> GetCouponByMasterID(int MasterID, int type = 0) 
        {
            return dal.GetCouponByMasterID(MasterID, type);
        }

        /// <summary>
        /// 检查当天是否能使用房价变价优惠券
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public bool CheckDayUser(int masterid,int couponid=0)
        {
            MasterD masD = new MasterD();
            MasterM masM = masD.GetM<MasterM>(masterid);
            if (masM == null)
            {
                return false;
            }
            if (!masM.Ing_Fk_VipCardID.HasValue || masM.Ing_Fk_VipCardID.Value == 0)
            {
                return false;
            }
            VipCardInfoD vipD = new VipCardInfoD();
            VipCardInfoM vipM = vipD.GetM<VipCardInfoM>(masM.Ing_Fk_VipCardID ?? 0);
            if (vipM == null)
            {
                return false;
            }
            //1,判断主单没享受首住优惠
            if (vipM == null || !vipM.Ing_FirstMaster.HasValue || vipM.Ing_FirstMaster.Value == masM.Ing_Pk_MasterID)
            {
                return false;
            }
            //3,该主单是否当天已经使用了
            CouponDetailsM coupM = dal.GetCouponDetail(masterid);
            if (coupM != null) 
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 通过优惠券改变房价
        /// </summary>
        /// <param name="masterid"></param>
        /// <param name="couponid"></param>
        /// <returns></returns>
        public bool CouponPrice(int masterid, int couponid) 
        {
            if(!this.CheckDayUser(masterid))
            {
                return false;
            }
            //检查优惠券是不是属于本人
            List<ResultCouponM> list = this.GetCouponByMasterID(masterid, 1);
            if (list == null || list.Count == 0)
            {
                return false;
            }
            if (list.Where(a => a.Ing_PaperID == couponid).Count()==0) 
            {
                return false;
            }
            if (!dal.CouponPrice(masterid, couponid)) 
            {
                return false;
            }
          return true;
        }

        /// <summary>
        /// 判断该主单有没有使用变价优惠券
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        public CouponDetailsM GetCouponDetail(int masterid)
        {
            return dal.GetCouponDetail(masterid);
        }
    }
}
