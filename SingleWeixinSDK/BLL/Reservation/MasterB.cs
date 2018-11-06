using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MasterB
    {
        public DAL.MasterD dal = new DAL.MasterD();


        /// <summary>
        /// 获取一条
        /// </summary>
        /// <param name="masid"></param>
        /// <returns></returns>
        public MasterM GetOne(int masid)
        {
            return dal.GetM<MasterM>(masid);
        }

        /// <summary>
        /// 根据openid获取订单列表
        /// </summary>
        /// <param name="topnum"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public List<OrderM> GetOrderListByOpenid(int topnum, string openid)
        {
            return dal.GetOrderListByOpenid(topnum, openid);
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="vipcardid">vipcardid</param>
        /// <param name="type">1: 在住 预订 挂账,微信预订的钟点房    0：离店   2：取消</param>
        /// <returns></returns>
        public List<OrderM> GetOrderbycardid(int vipcardid, int type)
        {
            return dal.GetOrderbycardid(vipcardid, type);
        }


        /// <summary>
        /// 获取评论的主单记录
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public OrderM GetCommentRecordByMasID(int MasterID)
        {
            return dal.GetCommentRecordByMasID(MasterID);
        }

        /// <summary>
        /// 撤销订单
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public BaseResponseModel UpdateX(cancelOrderM model)
        {
            BaseResponseModel response = new BaseResponseModel();
            bool rev = dal.UpdateX(model);
            response.data = rev;            

            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 得到默认房价码
        /// </summary>
        /// <param name="time"></param>
        /// <param name="lngvipcardid"></param>
        /// <returns></returns>
        public RoomRateDefaultM GetRoomRateDefault(int Ing_StoreID, DateTime time, int lngvipcardid)
        {
            return dal.GetRoomRateDefault(Ing_StoreID, time, lngvipcardid);
        }


        /// <summary>
        /// 获取房价
        /// </summary>
        /// <param name="time"></param>
        /// <param name="lngvipcardid"></param>
        /// <returns></returns>
        public RoomRateM GetRoomRate(int Ing_StoreID, DateTime time, string roomtype, string roomrate, int lngvipcardid)
        {
            return dal.GetRoomRate(Ing_StoreID, time, roomtype, roomrate, lngvipcardid);
        }


                /// <summary>
        /// 散客预订里的可用房，最大，最小房数
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<RoomCanUseM> GetRoomCanUse(int Ing_StoreID, DateTime date1, DateTime date2, string typecode)
        {
            return dal.GetRoomCanUse(Ing_StoreID, date1, date2, typecode);
        }


        /// <summary>
        /// 保存预订
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel SaveOrder(WriteOrderM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.SaveOrder(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

         /// <summary>
        /// 根据openid，获取操作员对应的操作员ID
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public int GetSaleIDbyopenid(string openid)
        {
            return dal.GetSaleIDbyopenid(openid);
        }


        /// <summary>
        /// 续住操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel ContinueInter(ContinueInterDisplay model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.ContinueInter(model);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 选择退房提醒
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel SaveTuiFang(SelectContinueM model)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.SaveTuiFang(model.Ing_MasterID);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 续住获取所需房价
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public decimal GetRoomPriceById(ContinueInterDisplay model) 
        {
            return dal.GetRoomPriceById(model);
        }
    }
}
