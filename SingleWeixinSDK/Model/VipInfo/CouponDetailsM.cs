using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_CouponDetails
    /// </summary>
    public class CouponDetailsM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_PaperID {get;set;}

        ///<summary>
        ///优惠券类型
        /// </summary>
        public int Ing_CouponTypeID {get;set;}

        ///<summary>
        ///优惠券编码
        /// </summary>
        public string str_PaperCode {get;set;}

        ///<summary>
        ///优惠券名称
        /// </summary>
        public string str_PaperName {get;set;}

        ///<summary>
        ///金额
        /// </summary>
        public decimal? dec_Amount {get;set;}

        /// <summary>
        /// 金额字符串
        /// </summary>
        public string str_Amount { get {
            if (!dec_Amount.HasValue) return "0";
            return dec_Amount.Value.ToString("F0");
        } }

        ///<summary>
        ///开始时间
        /// </summary>
        public DateTime dt_StartTime {get;set;}

        ///<summary>
        ///结束时间
        /// </summary>
        public DateTime dt_EndTime {get;set;}

        ///<summary>
        ///使用门店范围
        /// </summary>
        public string str_UseArea {get;set;}

        ///<summary>
        ///是否使用
        /// </summary>
        public int? Ing_IsUse {get;set;}

        ///<summary>
        ///str_barcode
        /// </summary>
        public string str_barcode {get;set;}

        ///<summary>
        ///str_TDcode
        /// </summary>
        public string str_TDcode {get;set;}

        ///<summary>
        ///str_descript
        /// </summary>
        public string str_descript {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_remark {get;set;}

        ///<summary>
        ///状态  1：有效  0：无效  2：注销  3：挂失
        /// </summary>
        public int? Ing_Sta {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_createtime {get;set;}

        /// <summary>
        /// 使用时间
        /// </summary>
        public DateTime? dt_useTime{get;set;}

        ///<summary>
        ///创建者
        /// </summary>
        public string str_creater {get;set;}

        ///<summary>
        ///创建门店
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///会员卡id
        /// </summary>
        public int? Ing_VipcardInfoID {get;set;}

        ///<summary>
        ///能使用次数
        /// </summary>
        public int? Ing_CanUseNum {get;set;}

        ///<summary>
        ///已经使用次数
        /// </summary>
        public int? Ing_UseNum {get;set;}

        ///<summary>
        ///还能使用次数
        /// </summary>
        public int? Ing_LastNum {get;set;}

        ///<summary>
        ///折扣
        /// </summary>
        public decimal? dec_Discount {get;set;}

        ///<summary>
        ///pccode
        /// </summary>
        public string str_Pccode {get;set;}



    }

    /// <summary>
    /// 房价变更modle
    /// </summary>
    public class CouponPriceM 
    {
      /// <summary>
      /// 主单id
      /// </summary>
      public  int masterid{get;set;}

      /// <summary>
      /// 优惠券id
      /// </summary>
      public int couponid { get; set; }
    }


    /// <summary>
    /// 根据会员卡号查找出来的优惠券记录
    /// </summary>
    public class ResultCouponM
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string str_PaperName { get; set; }


        /// <summary>
        /// 类型标识
        /// </summary>
        public string str_SendType { get; set; }

        /// <summary>
        /// 优惠券类型：0普通,1变房价
        /// </summary>
        public int Ing_type { get; set; }

        /// <summary>
        /// 优惠券主键
        /// </summary>
        public int Ing_PaperID { get; set; }


        /// <summary>
        /// 优惠券编码
        /// </summary>
        public string str_PaperCode { get; set; }


        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal dec_Amount { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime dt_StartTime { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime dt_EndTime { get; set; }

        /// <summary>
        /// 还能使用的次数
        /// </summary>
        public int Ing_LastNum { get; set; }

        /// <summary>
        /// 金额字符串
        /// </summary>
        public string str_Amount
        {
            get
            {
                return dec_Amount.ToString("F0");
            }
        }
    }


    /// <summary>
    /// 抵扣券支付要传的参数
    /// </summary>
    public class ParaForCoponPayM
    {
        /// <summary>
        /// 主单id
        /// </summary>
        public int MasterID { get; set; }


        /// <summary>
        /// 优惠券id
        /// </summary>
        public int PagerID { get; set; }

        /// <summary>
        /// 优惠券id  以逗号分隔的字符串
        /// </summary>
        public string PagerIDs { get; set; }

        /// <summary>
        /// 优惠券id列表
        /// </summary>
        public List<int> ListPagerID
        {
            get {                
                List<int> list = new List<int>();
                if (string.IsNullOrEmpty(PagerIDs))
                {
                    return list;
                }
                List<string> liststr = PagerIDs.Split(',').ToList();
                foreach (string str in liststr)
                {
                    if (string.IsNullOrEmpty(str))
                    {
                        continue;
                    }
                    int id = 0;
                    if (!int.TryParse(str, out id))
                    {
                        continue;
                    }
                    if (id <= 0)
                    {
                        continue;
                    }
                    list.Add(id);
                }
                return list;
            }
        }

        /// <summary>
        /// 门店id
        /// </summary>
        public int Ing_StoreID { get; set; }
        

        /// <summary>
        /// 备注
        /// </summary>
        public string str_Remark { get; set; }


        ///<summary>
        ///会员卡ID
        /// </summary>
        public int Ing_Pk_VipCardId { get; set; }

        /// <summary>
        /// 微信金额
        /// </summary>
        public decimal dec_WechatPrice { get; set; }

        ///<summary>
        ///储值余额
        /// </summary>
        public decimal dec_SurplusMoney { get; set; }

        /// <summary>
        /// 积分兑换总共花了多少积分
        /// </summary>
        public int Ing_IntegralExchangeTotal { get; set; }

        /// <summary>
        /// 积分兑换的金额
        /// </summary>
        public decimal dec_IntegralExchangeTotalMoney { get; set; }

        /// <summary>
        /// token
        /// </summary>
        public string token { get; set; }

    }


    /// <summary>
    /// 撤销抵扣券支付返回的类
    /// </summary>
    public class ResultCoponCancelM
    {
        /// <summary>
        /// 错误代码， 0表示正确的
        /// </summary>
        public int ret { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string msg { get; set; }
    }
}