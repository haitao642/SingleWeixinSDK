using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_StoreDetailInfo
    /// </summary>
    public class StoreDetailInfoM
    {
        ///<summary>
        ///Ing_StoreDetailInfoID
        /// </summary>
        public int Ing_StoreDetailInfoID {get;set;}

        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int? Ing_StoreID {get;set;}

        ///<summary>
        ///门店简介
        /// </summary>
        public string str_StoreBrief {get;set;}

        ///<summary>
        ///地址
        /// </summary>
        public string str_Address {get;set;}

        ///<summary>
        ///预定电话
        /// </summary>
        public string str_ReseCall {get;set;}

        ///<summary>
        ///传真
        /// </summary>
        public string str_FAX {get;set;}

        ///<summary>
        ///400预定
        /// </summary>
        public string str_ReseFourCall {get;set;}

        ///<summary>
        ///WAP预定
        /// </summary>
        public string str_WAPRese {get;set;}

        ///<summary>
        ///网站预定
        /// </summary>
        public string str_WWWRese {get;set;}

        ///<summary>
        ///短信预定
        /// </summary>
        public string str_ScheSMS {get;set;}

        ///<summary>
        ///投诉电话
        /// </summary>
        public string str_ComplaintsTel {get;set;}

        ///<summary>
        ///房型信息
        /// </summary>
        public string str_RoomType {get;set;}

        ///<summary>
        ///客服服务
        /// </summary>
        public string str_RoomService {get;set;}

        ///<summary>
        ///酒店服务
        /// </summary>
        public string str_HotelService {get;set;}

        ///<summary>
        ///周边环境和商业设施
        /// </summary>
        public string str_EnvAndFa {get;set;}

        ///<summary>
        ///交通信息
        /// </summary>
        public string str_TrafficInfo {get;set;}

        ///<summary>
        ///地图经度
        /// </summary>
        public string str_mapX {get;set;}

        ///<summary>
        ///地图纬度
        /// </summary>
        public string str_mapY {get;set;}

        ///<summary>
        ///温馨提示
        /// </summary>
        public string str_KindlyRem {get;set;}



    }

    /// <summary>
    /// 门店列表用到的参数
    /// </summary>
    public class DetailInfoInListM
    {
        ///<summary>
        ///Ing_StoreID
        /// </summary>
        public int Ing_StoreID { get; set; }


        ///<summary>
        ///地图经度
        /// </summary>
        public string str_mapX { get; set; }

        ///<summary>
        ///地图纬度
        /// </summary>
        public string str_mapY { get; set; }

        ///<summary>
        ///地址
        /// </summary>
        public string str_Address { get; set; }
    }
}