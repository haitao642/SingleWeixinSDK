using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 会员评论表
    /// </summary>
    public class UserCommentsM
    {
        ///<summary>
        ///Ing_PK_comID
        /// </summary>
        public int Ing_PK_comID {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///门店名称
        /// </summary>
        public string strStoreName {get;set;}

        ///<summary>
        ///会员卡id
        /// </summary>
        public int? Ing_VipCardID {get;set;}

        ///<summary>
        ///评论人
        /// </summary>
        public string strUserName {get;set;}

        ///<summary>
        ///评论时间
        /// </summary>
        public DateTime? dtcomDate {get;set;}

        ///<summary>
        ///评论内容
        /// </summary>
        public string strcomCon {get;set;}

        ///<summary>
        ///服务效率
        /// </summary>
        public int? IngserviceEff {get;set;}

        ///<summary>
        ///服务热情
        /// </summary>
        public int? IngserviceAtt {get;set;}

        ///<summary>
        ///淋浴舒适度
        /// </summary>
        public int? IngShowerCom {get;set;}

        ///<summary>
        ///客房卫生
        /// </summary>
        public int? IngroomHea {get;set;}

        ///<summary>
        ///睡眠舒适度
        /// </summary>
        public int? IngSleepCom {get;set;}

        ///<summary>
        ///状态
        /// </summary>
        public int Ingsta {get;set;}

        ///<summary>
        ///删除标识
        /// </summary>
        public int Ingdel {get;set;}

        ///<summary>
        ///主单号
        /// </summary>
        public int? IngMasterID {get;set;}

        ///<summary>
        ///IngReSta
        /// </summary>
        public int? IngReSta {get;set;}

        ///<summary>
        ///入住时间
        /// </summary>
        public DateTime? dtCheckInTime {get;set;}



    }
}