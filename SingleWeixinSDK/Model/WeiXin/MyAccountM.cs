using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 我的账号的基类
    /// </summary>
    public class BaseMyAccountM
    {
        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }


        /// <summary>
        /// 门店号
        /// </summary>
        public int storeid { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 门店名称
        /// </summary>
        public string Str_StoreName { get; set; }
        /// <summary>
        /// rawurl
        /// </summary>
        public string rawurl { get; set; }
    }

    /// <summary>
    /// 我的泊友会页面用到的参数
    /// </summary>
    public class MyAccountM : BaseMyAccountM
    {
        /// <summary>
        /// 头像地址
        /// </summary>
        public string headerimg { get;set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string str_CusName { get; set; }
        /// <summary>
        /// 包含星号的手机号码
        /// </summary>
        public string strmobile {
            get {
                if (string.IsNullOrEmpty(mobile)) return mobile;
                if (mobile.Length < 7) return mobile;
                return string.Format("{0}****{1}",mobile.Substring(0,3),mobile.Substring(7));
            }
        }


        /// <summary>
        /// 可用积分
        /// </summary>
        public int Ing_SurplusIntegral { get; set; }

        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal dec_SurplusMoney { get; set; }

         /// <summary>
        /// 微信钱包
        /// </summary>
        public decimal dec_WechatPrice { get; set; }
        /// <summary>
        /// 可用优惠券数量
        /// </summary>
        public int coupon { get; set; }

        
        /// <summary>
        /// 会员卡id
        /// </summary>
        public int VipCardId { get; set; }
    }


    /// <summary>
    /// 优惠券
    /// </summary>
    public class MyCouponM : BaseMyAccountM
    {
        /// <summary>
        /// 0:无效   1：有效   2：过期
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// css名字
        /// </summary>
        public string strcss { get {
            return string.Format("coupon{0}",type);
        } }


        /// <summary>
        /// 优惠券列表 未使用
        /// </summary>
        public List<CouponDetailsM> list0 { get; set; }
        /// <summary>
        /// 优惠券列表 已使用
        /// </summary>
        public List<CouponDetailsM> list1 { get; set; }
        /// <summary>
        /// 优惠券列表 已过期
        /// </summary>
        public List<CouponDetailsM> list2 { get; set; }
    }


        /// <summary>
    /// 储值分享的类
    /// </summary>
    public class ShareChargeMonM : BaseMyAccountM
    {
        /// <summary>
        /// 分享者的会员卡ID
        /// </summary>
        public int Ing_VipCardID { get; set; }

        /// <summary>
        /// 分享地址
        /// </summary>
        public string str_ShareUrl { get; set; }


        /// <summary>
        /// 头像地址
        /// </summary>
        public string str_ShareHeaderimgUrl { get; set; }


        /// <summary>
        /// appID
        /// </summary>
        public string appId { set; get; }

        /// <summary>
        /// 时间
        /// </summary>
        public long timestamp { set; get; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonceStr { set; get; }


        /// <summary>
        /// 签名
        /// </summary>
        public string signature { set; get; }
    }


    /// <summary>
    /// 订单
    /// </summary>
    public class MyOrderM : BaseMyAccountM
    {
        /// <summary>
        /// 1: 在住 预订 挂账    0：离店   2：取消
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// css名字
        /// </summary>
        public string strcss
        {
            get
            {
                return string.Format("myorder{0}", type);
            }
        }
        
        /// <summary>
        /// 总的储值金额
        /// </summary>
        public decimal dec_SurplusMoney { get; set; }

        /// <summary>
        /// 微信储值密码
        /// </summary>
        public string str_paypassword { get; set; }

        /// <summary>
        /// 会员卡id
        /// </summary>
        public int Ing_Pk_VipCardId { get; set; }

        /// <summary>
        /// 订单列表 离店
        /// </summary>
        public List<OrderM> list0 { get; set; }
        /// <summary>
        /// 订单列表 新订
        /// </summary>
        public List<OrderM> list1 { get; set; }
        /// <summary>
        /// 订单列表 取消
        /// </summary>
        public List<OrderM> list2 { get; set; }
    }

    /// <summary>
    /// 取消订单用到的参数
    /// </summary>
    public class cancelOrderM
    {
        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 主单id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }
    }

    /// <summary>
    /// 评论
    /// </summary>
    public class MyCommentM
    {
        /// <summary>
        /// 会员卡id
        /// </summary>
        public int vipcardid { get; set; }

        /// <summary>
        /// 主单id
        /// </summary>
        public int masid { get; set; }

        /// <summary>
        /// 房型
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public string RoomNo { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        public int storeid { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// 个人资料
    /// </summary>
    public class MyInfoM:BaseMyAccountM
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string headerimg { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        /// 档案id
        /// </summary>
        public int custid { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string cusname { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 包含星号的手机号码
        /// </summary>
        public string strmobile
        {
            get
            {
                if (string.IsNullOrEmpty(mobile)) return mobile;
                if (mobile.Length < 7) return mobile;
                return string.Format("{0}****{1}", mobile.Substring(0, 3), mobile.Substring(7));
            }
        }


        /// <summary>
        /// 身份证
        /// </summary>
        public string ident { get; set; }

        /// <summary>
        /// 包含星号的身份证
        /// </summary>
        public string strident
        {
            get
            {
                if (string.IsNullOrEmpty(ident)) return ident;
                if (ident.Length < 7) return ident;
                return string.Format("{0}****{1}", ident.Substring(0, 3), ident.Substring(ident.Length-4));
            }
        }

        

        /// <summary>
        /// 用户输入的验证码
        /// </summary>
        public string yzcode { get; set; }


        /// <summary>
        /// 手机号+验证码   的md5加密字符串
        /// </summary>
        public string yzcode1 { get; set; }


        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// 解除绑定
    /// </summary>
    public class UnBindM
    {
        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }


        /// <summary>
        /// 包含星号的手机号码
        /// </summary>
        public string strmobile
        {
            get
            {
                if (string.IsNullOrEmpty(mobile)) return mobile;
                if (mobile.Length < 7) return mobile;
                return string.Format("{0}****{1}", mobile.Substring(0, 3), mobile.Substring(7));
            }
        }


        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 用户输入的验证码
        /// </summary>
        public string yzcode { get; set; }


        /// <summary>
        /// 手机号+验证码   的md5加密字符串
        /// </summary>
        public string yzcode1 { get; set; }


        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// 修改储值密码用到的参数
    /// </summary>
    public class ChangePayPwdM:BaseMyAccountM
    {
        /// <summary>
        /// 会员卡id
        /// </summary>
        public int vipcardid { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 包含星号的手机号码
        /// </summary>
        public string strmobile
        {
            get
            {
                if (string.IsNullOrEmpty(mobile)) return mobile;
                if (mobile.Length < 7) return mobile;
                return string.Format("{0}****{1}", mobile.Substring(0, 3), mobile.Substring(7));
            }
        }

        /// <summary>
        /// 新密码
        /// </summary>
        public string newpwd { get; set; }

        /// <summary>
        /// 用户输入的验证码
        /// </summary>
        public string yzcode { get; set; }


        /// <summary>
        /// 手机号+验证码   的md5加密字符串
        /// </summary>
        public string yzcode1 { get; set; }



        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 0储值密码,1登录密码
        /// </summary>
        public int type { get; set; }
    }
}
