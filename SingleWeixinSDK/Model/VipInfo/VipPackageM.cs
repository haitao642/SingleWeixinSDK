using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_VipPackage
    /// </summary>
    public class VipPackageM
    {
        ///<summary>
        ///Ing_PKID
        /// </summary>
        public int Ing_PKID { get; set; }

        ///<summary>
        ///礼包名称
        /// </summary>
        public string str_Name { get; set; }

        ///<summary>
        ///编码(可以为空)
        /// </summary>
        public string str_Code { get; set; }

        ///<summary>
        ///总金额
        /// </summary>
        public decimal? dec_Amount { get; set; }

        ///<summary>
        ///赠送积分
        /// </summary>
        public decimal? dec_Integral { get; set; }

        /// <summary>
        /// 优惠券集合
        /// </summary>
        public string str_Couppones { get; set; }

        /// <summary>
        /// 优惠券集合
        /// </summary>
        public List<int> str_CouponIdes1
        {
            get
            {
                List<int> list = new List<int>();
                if (string.IsNullOrEmpty(str_Couppones))
                {
                    return list;
                }
                foreach (string li in str_Couppones.Split(','))
                {
                    if (string.IsNullOrEmpty(li))
                    {
                        continue;
                    }
                    int num = 0;
                    int.TryParse(li, out num);
                    if (num == 0)
                    {
                        continue;
                    }
                    list.Add(num);
                }
                return list;
            }
        }

        ///<summary>
        ///房晚(暂时不用)
        /// </summary>
        public int? Ing_Day { get; set; }

        ///<summary>
        ///礼包范围（age:礼包A，只能在这2门店可以赠送,购买）
        /// </summary>
        public string str_UseArea { get; set; }

        ///<summary>
        ///门店
        /// </summary>
        public int? Ing_StoreID { get; set; }

        ///<summary>
        ///状态
        /// </summary>
        public int Ing_Sta { get; set; }

        /// <summary>
        /// 中文状态
        /// </summary>
        public string str_Sta
        {
            get
            {
                if (Ing_Sta == 1)
                {
                    return "启用";
                }
                else
                {
                    return "停用";
                }
            }


        }

        /// <summary>
        /// 是否享受会员首住优惠(1享受,0不享受)
        /// </summary>
        public int? Ing_FirstCheck { get; set; }

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_Create { get; set; }

        ///<summary>
        ///创建人
        /// </summary>
        public string str_Creator { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string str_Describe { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? dt_Begin { get; set; }

         /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? dt_End { get; set; }

        ///<summary>
        ///优惠券id
        /// </summary>
        public int? Ing_Fk_CouponId { get; set; }

    }

    /// <summary>
    /// 购买/赠送礼包(即现在的会员升级)
    /// </summary>
    public class BuyPackageM
    {
        /// <summary>
        /// 会员卡id
        /// </summary>
        public int vipcardid { get; set; }

        /// <summary>
        /// 礼包id
        /// </summary>
        public int packageid { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// 礼包信息
        /// </summary>
        public VipPackageM packM { get; set; }

        /// <summary>
        /// 微信id
        /// </summary>
        public string openid { get; set; }
    }

    /// <summary>
    /// 酒店model
    /// </summary>
    public class HotelSimpleM
    {
        /// <summary>
        /// 酒店id
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string str_hotTel{get;set;}

        /// <summary>
        /// 地址
        /// </summary>
        public string str_Address{get;set;}

        /// <summary>
        /// 区域
        /// </summary>
        public string str_district { get; set; }
    }

    /// <summary>
    /// 门店范围显示
    /// </summary>
    public class HotelRangeShow 
    {
        /// <summary>
        /// 门店
        /// </summary>
        public List<HotelSimpleM> HotelSimpleList { get; set; }

        /// <summary>
        /// 区域范围
        /// </summary>
        public List<string> AreaList { get; set; }
    }
}
