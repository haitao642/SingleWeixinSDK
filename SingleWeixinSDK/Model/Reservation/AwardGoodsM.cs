using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_AwardGoods
    /// </summary>
    public class AwardGoodsM
    {
        ///<summary>
        ///自增ID
        /// </summary>
        public int Ing_AwardGoodsID {get;set;}

        ///<summary>
        ///会员卡ID
        /// </summary>
        public int? Ing_VipcardID {get;set;}

        ///<summary>
        ///对应的奖项
        /// </summary>
        public int? Ing_AwardID {get;set;}

        ///<summary>
        ///主单ID
        /// </summary>
        public int? Ing_MasterID {get;set;}

        ///<summary>
        ///抽奖时间
        /// </summary>
        public DateTime? dt_Create {get;set;}

        ///<summary>
        ///领取时间
        /// </summary>
        public DateTime? dt_Modify {get;set;}

        ///<summary>
        ///领取人
        /// </summary>
        public string str_Modify {get;set;}

        ///<summary>
        ///领取门店
        /// </summary>
        public int? Ing_StoreID {get;set;}

        /// <summary>
        /// 领取状态：0：未领取  1：已领取
        /// </summary>
        public int Ing_Sta { get; set; }



    }

    /// <summary>
    /// 获取的奖品
    /// </summary>
    public class ListAwGoodsM
    {
        /// <summary>
        /// 奖品
        /// </summary>
        public List<AwGoodModel> list { get; set; }
    }


    /// <summary>
    /// V_AwardGoods
    /// </summary>
    public class AwGoodModel : AwardGoodsM
    {
        /// <summary>
        /// 数量
        /// </summary>
        public int Ing_RealGoods { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string str_Goods { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public string str_level { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string str_mobile { get; set; }

        /// <summary>
        /// 档案名称
        /// </summary>
        public string str_CusName { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        public string str_ident { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string str_VipCard { get; set; }

        /// <summary>
        /// 条件
        /// </summary>
        public string str_Query { get; set; }

        /// <summary>
        /// 中文状态
        /// </summary>
        public string str_Sta
        {
            get
            {
                if (Ing_Sta == 1)
                {
                    return "已领取";
                }
                else
                {
                    return "未领取";
                }
            }

        }
    }
}