using Model.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 商城会员
    /// </summary>
    public class ShopVipcardM : BaseShopM
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string nickname { get; set; }

        /// <summary>
        ///会员级别
        /// </summary>
        public string level { get; set; }

        /// <summary>
        /// pms主键
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// 档案id
        /// </summary>
        public int custid { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string idcard { get; set; }

        /// <summary>
        /// 储值余额
        /// </summary>
        public decimal dec_SurplusMoney{get;set;}
        
        /// <summary>
        /// 微信钱包
        /// </summary>
        public decimal dec_WechatPrice{get;set;}

        /// <summary>
        /// 积分
        /// </summary>
        public int Ing_TotalIntegral { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
    }

    /// <summary>
    /// 会员请求
    /// </summary>
    public class ShopVipDeatilM
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? id { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 方法1增减 2 查询明细 3查询总额
        /// </summary>
        public int method { get; set; }

        /// <summary>
        /// 1储值金  2 泊友钱包 3积分 4 全部(查询时)
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
       public string description{get;set;}

       /// <summary>
       /// 开始时间
       /// </summary>
       public string starttime { get; set; }

       /// <summary>
       /// 结束时间
       /// </summary>
       public string endtime { get; set; }

       /// <summary>
       /// 酒店
       /// </summary>
       public string hotelides { get; set; }

       /// <summary>
       /// 签名
       /// </summary>
       public string sign { get; set; }
    }

    /// <summary>
    /// 商城信息返回
    /// </summary>
    public class ShopVipTotalM : BaseShopM
    {
      /// <summary>
      /// 详情
      /// </summary>
        public List<VipDetailM> details { get; set; }
      
      /// <summary>
      /// 总金额
      /// </summary>
      public decimal total { get; set; }
    }

    /// <summary>
    /// 会员资料详情
    /// </summary>
    public class VipDetailM 
    {    
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 中文类型
        /// </summary>
        public string strtype { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Create { get; set; }
    }

    /// <summary>
    /// 赠送优惠券
    /// </summary>
    public class CreateCoupon : AskShopM
    {
        /// <summary>
        /// 数量
        /// </summary>
        public int num { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// 礼包id
        /// </summary>
        public int packageid { get; set; }
    }

    /// <summary>
    /// 会员卡类型返回
    /// </summary>
    public class VipCardBackM : BaseShopM
    {
        /// <summary>
        /// 会员记录
        /// </summary>
        public List<ShopVipCardType> list { get; set; }
    }

    /// <summary>
    /// 会员类型
    /// </summary>
    public class ShopVipCardType
    {
        /// <summary>
        /// 会员卡类型id
        /// </summary>
        public int Ing_CardTypeID { get; set; }

        /// <summary>
        /// 会员卡类型名称
        /// </summary>
        public string str_CardTypeName { get; set; }
    }
}
