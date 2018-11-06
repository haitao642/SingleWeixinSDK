using Model;
using Model.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VipCardInfoB
    {
        public DAL.VipCardInfoD dal = new DAL.VipCardInfoD();

        
        /// <summary>
        /// 根据openid获取会员卡记录
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public VipCardInfoM GetVipCardByopenID(string openid)
        {
            return dal.GetVipCardByopenID(openid);
        }
        /// <summary>
        /// 根据openid和storeid获取会员卡记录
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public VipCardInfoM GetVipCardByStoreid(string openid,int storeid)
        {
            return dal.GetVipCardByStoreid(openid, storeid);
        }

        /// <summary>
        /// 根据unionid获取
        /// </summary>
        /// <param name="unionid"></param>
        /// <returns></returns>
        public VipCardInfoM GetVipCardByunionID(string unionid)
        {
            return dal.GetVipCardByunionID(unionid);
        }

        /// <summary>
        /// 保存会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateVip(VipCardInfoM model) 
        {
            return dal.SaveOrUpdate(model);
        }

        /// <summary>
        /// 获取一条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VipCardInfoM GetOne(int id)
        {
            return dal.GetM<VipCardInfoM>(id);
        }

        /// <summary>
        /// 绑定或者新增会员
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="cusname"></param>
        /// <param name="openid"></param>
        /// <param name="yzcode">用户输入的验证码</param>
        /// <param name="yzcode1">系统发送的验证码   手机-验证码   的md5加密</param>
        /// <returns></returns>
        public BaseResponseModel BindOrAddWeChat(string mobile, string cusname, string openid,string yzcode,string yzcode1,int StoreID,string ident)
        {
            BaseResponseModel response = new BaseResponseModel();
           bool rev= dal.BindOrAddWeChat(mobile, cusname, openid,yzcode,yzcode1,StoreID,ident);

           //if (rev)
           //{
           //    ///微信推送
           //    BindSuccessM m1 = new BindSuccessM();
           //    m1.Openid = openid;
           //    m1.keyword1 = cusname;
           //    m1.remark = string.Format("绑定的是手机:{0},如非本人，请联系系统管理员",mobile);
           //    DAL.WeChatD weD = new DAL.WeChatD();
           //    weD.BindSuccessNotice(m1);
           //}
           response.data = rev;
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 绑定微信的时候，发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public String WechatBindVirifyCode(string mobile,int yzcode,int storeid)
        {
            return  dal.WechatBindVirifyCode(mobile, yzcode,storeid);
           
        }
        /// <summary>
        /// 验证储值支付密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public BaseResponseModel VirifyPwd(string pwd,int vipcardid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.VirifyPwd(pwd,vipcardid);
           
            return response;
        }
        /// <summary>
        /// 修改储值支付密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public BaseResponseModel ChangePwd(string pwd, int vipcardid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.ChangePwd(pwd, vipcardid);

            return response;
        }
        /// <summary>
        /// 修改会员密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public BaseResponseModel ChangeVipPwd(string pwd, int vipcardid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.ChangeVipPwd(pwd, vipcardid);

            return response;
        }
        /// <summary>
        /// 验证会员密码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public BaseResponseModel VirifyVipPwd(string pwd, int vipcardid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.VirifyVipPwd(pwd, vipcardid);

            return response;
        }
        /// <summary>
        /// 储值密码使用，发送验证码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public BaseResponseModel UsePayPwdVirifyCode(string mobile)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.UsePayPwdVirifyCode(mobile);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 修改储值支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel UpdatePayPassword(UpdatePayPasswordM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            bool rev = dal.UpdatePayPassword(model);

            if (rev)
            {
                ///微信推送
            }
            response.data = rev;
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 修改手机号码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel UpdateMobile(MyInfoM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.UpdateMobile(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel UnBind(UnBindM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.UnBind(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }
        public Boolean CreateSHCoupon(int vipCardInfoId)
        {
            return dal.CreateSHCoupon(vipCardInfoId);
        }
        /// <summary>
        /// 积分兑换抵用券
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel IntegralExchangeCoupon(WechatCouponM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.IntegralExchangeCoupon(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 检查微信支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel CheckWXPay(ParaForCoponPayM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.CheckWXPay(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 检查会员首住支付
        /// </summary>
        /// <param name="model"></param>
        /// <param name="masM"></param>
        /// <param name="cardM"></param>
        /// <returns></returns>
        public bool CheckFirst(ParaForCoponPayM model, MasterM masM = null, VipCardInfoM cardM = null) 
        {
            return dal.CheckFirst(model,masM,cardM);
        }

        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel WXPay(ParaForCoponPayM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.WXPay(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 储值支付时，验证储值支付密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel VerifyPayPWD(VerifyPayPWDM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.VerifyPayPWD(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 获取商城会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ShopVipcardM GetShopVipCard(ShopVipcardM model)
        {
            return dal.GetShopVipCard(model);
        }

        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditUserInfo(ShopVipcardM model) 
        {
            return dal.EditUserInfo(model);
        }

        /// <summary>
        /// 新增会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ShopVipcardM Rigister(ShopVipcardM model)
        {
            return dal.Rigister(model);
        }

        /// <summary>
        /// 赠送优惠券
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseShopM DiscountGet(CreateCoupon model)
        {
            return dal.DiscountGet(model);
        }

        /// <summary>
        /// 获取储值/钱包/积分详细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ShopVipTotalM GetVipDetail(ShopVipDeatilM model) 
        {
            return dal.GetVipDetail(model);
        }

        /// <summary>
        /// 获取会员卡类型接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public VipCardBackM GetVipCardType(ShopVipDeatilM model) 
        {
            VipCardBackM mm = new VipCardBackM();
            mm.list= dal.GetVipCardType(model);
            mm.code="1";
            return mm;
        }

        
    }
}
