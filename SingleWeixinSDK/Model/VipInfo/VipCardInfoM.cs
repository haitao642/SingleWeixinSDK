using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    /// <summary>
    /// 会员卡信息
    /// </summary>
    public class VipCardInfoM
    {
        ///<summary>
        ///Ing_Pk_VipCardId
        /// </summary>
        public int Ing_Pk_VipCardId {get;set;}

        ///<summary>
        ///会员卡号
        /// </summary>
        public string str_VipCard {get;set;}

        ///<summary>
        ///Ing_Fk_VipID
        /// </summary>
        public int Ing_Fk_VipID {get;set;}

        ///<summary>
        ///会员卡类型
        /// </summary>
        public int Ing_VipCardType {get;set;}

        ///<summary>
        ///会员卡类型中文
        /// </summary>
        public string str_CardTypeName { get; set; }

        ///<summary>
        ///总共积分
        /// </summary>
        public int Ing_TotalIntegral {get;set;}

        ///<summary>
        ///消费积分
        /// </summary>
        public int Ing_ExchangeIntegral {get;set;}

        ///<summary>
        ///最大可用积分
        /// </summary>
        public int Ing_SurplusIntegral {get;set;}

        ///<summary>
        ///余额
        /// </summary>
        public decimal dec_SurplusMoney {get;set;}

        ///<summary>
        ///间夜积分
        /// </summary>
        public decimal dec_RoomNightScore {get;set;}

        ///<summary>
        ///钟点房入住次数
        /// </summary>
        public int Ing_ClockRoomCount {get;set;}

        ///<summary>
        ///有效日期
        /// </summary>
        public DateTime? dt_EffectiveDate {get;set;}

        ///<summary>
        ///失效日期
        /// </summary>
        public DateTime? dt_ExpirationDate {get;set;}

        ///<summary>
        ///休眠时间
        /// </summary>
        public DateTime? dt_SleepDate {get;set;}

        ///<summary>
        ///销售员
        /// </summary>
        public string str_Seller {get;set;}

        ///<summary>
        ///发放方式
        /// </summary>
        public int Ing_SendType {get;set;}

        ///<summary>
        ///发卡酒店
        /// </summary>
        public string str_CardHotel {get;set;}

        ///<summary>
        ///会员卡状态 1为有效 、-1 为未激活、0为停用 、2 为休眠、3为注销、4挂失
        /// </summary>
        public int Ing_VipCardSta {get;set;}

        /// <summary>
        /// 状态中文
        /// </summary>
        public string str_VipCardSta
        {
            get {
                string rev = "";
                switch (Ing_VipCardSta)
                { 
                    case -1:
                        rev = "未激活";
                        break;
                    case 0:
                        rev = "停用";
                        break;
                    case 1:
                        rev = "有效";
                        break;
                    case 2:
                        rev = "休眠";
                        break;
                    case 3:
                        rev = "注销";
                        break;
                    case 4:
                        rev = "挂失";
                        break;
                }
                return rev;
            }
        }

        ///<summary>
        ///最低金额
        /// </summary>
        public decimal dec_LimitMoney {get;set;}

        ///<summary>
        ///保证金
        /// </summary>
        public decimal? dec_Margin {get;set;}

        ///<summary>
        ///是否有记账行 1表示有 0 表示没有
        /// </summary>
        public int? Ing_HotelAccount {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_remark {get;set;}

        ///<summary>
        ///排序
        /// </summary>
        public int? Ing_Seq {get;set;}

        ///<summary>
        ///归属旅馆
        /// </summary>
        public string str_HotelID {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_CreateTime {get;set;}

        ///<summary>
        ///str_ptrv
        /// </summary>
        public string str_ptrv {get;set;}

        ///<summary>
        ///str_easyflag
        /// </summary>
        public string str_easyflag {get;set;}

        ///<summary>
        ///str_GroupNo
        /// </summary>
        public string str_GroupNo {get;set;}

        ///<summary>
        ///dec_SetParm
        /// </summary>
        public decimal? dec_SetParm {get;set;}

        ///<summary>
        ///str_VGroupNo
        /// </summary>
        public string str_VGroupNo {get;set;}

        ///<summary>
        ///dec_PayMoney
        /// </summary>
        public decimal? dec_PayMoney {get;set;}

        ///<summary>
        ///dt_PayTime
        /// </summary>
        public DateTime? dt_PayTime {get;set;}

        ///<summary>
        ///1
        /// </summary>
        public string str_SendCoupon {get;set;}

        ///<summary>
        ///str_OldSendCoupon
        /// </summary>
        public string str_OldSendCoupon {get;set;}

        ///<summary>
        ///dec_PersentMoney
        /// </summary>
        public decimal? dec_PersentMoney {get;set;}

        ///<summary>
        ///登录密码
        /// </summary>
        public string str_loginPwd {get;set;}

        ///<summary>
        ///str_wcopenid
        /// </summary>
        public string str_wcopenid {get;set;}

        /// <summary>
        /// 绑定微信时间
        /// </summary>
        public DateTime? dt_BindWeChat { get; set; }

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///销售员ID
        /// </summary>
        public int Ing_Pk_SaleUID { get; set; }



        /// <summary>
        /// 会员第一次入住的主单号
        /// </summary>
        public int? Ing_FirstMaster { get; set; }


        /// <summary>
        /// 该会员卡类型是否参加首住活动
        /// </summary>
        public int Ing_FirstCheck { get; set; }

        /// <summary>
        /// 能否参加首住的具体表述
        /// </summary>
        public string str_First
        {
            get {
                string rev = string.Empty;
                if (Ing_FirstCheck == 0)
                {
                    rev = "无";
                    return rev;
                }

                int masid=0;
                if (Ing_FirstMaster.HasValue)
                {
                    masid = Ing_FirstMaster.Value;
                }

                if (masid == 0)
                {
                    rev = "有,未享受";
                }
                else if (masid == 1)
                {
                    rev = "无";
                }
                else if (masid > 1)
                {
                    rev = "有,已享受，主单id为："+masid.ToString();
                }

               return rev;
            }
        }

        /// <summary>
        /// 手机
        /// </summary>
        public string str_mobile{get;set;}

        /// <summary>
        /// 姓名
        /// </summary>
        public string str_CusName{get;set;}

        /// <summary>
        /// 身份证号
        /// </summary>
        public string str_ident{get;set;}

        /// <summary>
        /// 储值支付密码
        /// </summary>
        public string str_paypassword { get;set; }

        /// <summary>
        /// 微信钱包金额
        /// </summary>
        public decimal dec_WechatPrice { get; set; }

        /// <summary>
        /// 微信unionid
        /// </summary>
        public string str_Unionid { get; set; }

        /// <summary>
        /// 档案id
        /// </summary>
        public int Ing_Pk_CustID { get; set; }
        /// <summary>
        /// 是否领取智能遥控器优惠券
        /// </summary>
        public int Ing_SHActivity { get; set; }

    }

    /// <summary>
    /// 储值支付密码验证
    /// </summary>
    public class VerifyPayPWDM
    {
        /// <summary>
        /// 储值支付密码,加密过的                                             
        /// </summary>
        public string str_paypassword { get; set; }


        /// <summary>
        /// 用户输入的储值支付密码
        /// </summary>
        public string str_pwd { get; set; }
    }


    /// <summary>
    /// 绑定或者新增会员时，传的参数
    /// </summary>
    public class AddWeChatM
    {
        /// <summary>
        /// 手机号
        /// </summary>
        [Display(Name = "手机号")]
        public string mobile { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string cusname { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string ident { get; set; }

        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int VipCardID { get; set; }

        /// <summary>
        /// 头像地址
        /// </summary>
        public string headerimg { get; set; }

        /// <summary>
        /// 公司头像地址
        /// </summary>
        public string companyimg { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 用户输入的验证码
        /// </summary>
        public string yzcode { get; set; }

        /// <summary>
        /// 系统的验证码
        /// </summary>
        public string yzcode1 { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        public int StoreID { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string Str_StoreName { get; set; }

        /// <summary>
        /// 绑定成功后的返回地址
        /// </summary>
        public string rawurl { get; set; }

        /// <summary>
        /// unionid
        /// </summary>
        public string unionid { get; set; }
    }

    /// <summary>
    /// 修改储值密码用到的参数
    /// </summary>
    public class UpdatePayPasswordM
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int VipCardID { get; set; }

        /// <summary>
        /// 用户输入的验证码
        /// </summary>
        public string yzcode { get; set; }

        /// <summary>
        /// 系统的验证码
        /// </summary>
        public string yzcode1 { get; set; }

        /// <summary>
        /// 0储值支付,1会员登录
        /// </summary>
        public int type { get; set; }
    }


    /// <summary>
    /// 会员卡储值，消费  所传的参数
    /// </summary>
    public class ParaForVipCardChargeM
    {
        /// <summary>
        /// 卡id
        /// </summary>
        public int Ing_Pk_VipCardID { get; set; }

        /// <summary>
        /// 主单id
        /// </summary>
        public int Ing_Fk_MasterID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int chargeType { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal chargemon { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Reamrk { get; set; }

        /// <summary>
        /// 赠送金额
        /// </summary>
        public int SendMon { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayType { get; set; }

        /// <summary>
        /// 结账单号
        /// </summary>
        public string str_CheckOutNo { get; set; }
    }


}