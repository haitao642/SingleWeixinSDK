using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Award
    /// </summary>
    public class AwardM
    {
        ///<summary>
        ///自增ID
        /// </summary>
        public int Ing_AwardID {get;set;}

        ///<summary>
        ///等级
        /// </summary>
        public int Ing_level {get;set;}

        ///<summary>
        ///中文等级
        /// </summary>
        public string str_level {get;set;}

        ///<summary>
        ///奖品描述
        /// </summary>
        public string str_Goods {get;set;}

        ///<summary>
        ///应该转的角度
        /// </summary>
        public int Ing_angles {get;set;}

        ///<summary>
        ///数量，用来算概率
        /// </summary>
        public int Ing_Amount {get;set;}

        ///<summary>
        ///1:实体物品，   0：虚拟物品
        /// </summary>
        public int Ing_RealGoods {get;set;}



        ///<summary>
        ///开始时间
        /// </summary>
        public DateTime dt_Start { get; set; }

        ///<summary>
        ///结束时间
        /// </summary>
        public DateTime dt_End { get; set; }

        ///<summary>
        ///如果是优惠券，对应的活动id
        /// </summary>
        public int Ing_CouponTypeID { get; set; }



    }


    /// <summary>
    /// 抽奖用到的参数
    /// </summary>
    public class ParaForAwardM
    {
        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int Ing_VipcardID { get; set; }
    }
}