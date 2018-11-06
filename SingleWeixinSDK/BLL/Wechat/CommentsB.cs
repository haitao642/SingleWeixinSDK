using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CommentsB
    {
        public DAL.CommentsD dal = new DAL.CommentsD();

        #region 公共方法
        public CommentsB() { }

        /// <summary>
        /// 查询所有用户评论
        /// </summary>
        /// <returns></returns>
        public BaseResponseModel GetAll()
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetAllM<CommentsM>();
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 根据条件查询用户评论
        /// </summary>
        /// <returns></returns>
        public BaseResponseModel GetSearch(string strwhere)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetQueryM<CommentsM>(strwhere);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 查询一条指定的记录:用户评论
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public BaseResponseModel Get(int pid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetM<CommentsM>(pid);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 添加或者修改记录:用户评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel SaveOrUpdate(CommentsM model)
        {
            BaseResponseModel response =new BaseResponseModel();
            bool rev = dal.SaveOrUpdate(model);
            response.data = model;
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;

        }


        /// <summary>
        /// 删除记录:用户评论
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public BaseResponseModel Delete(int pid)
        {
            BaseResponseModel response = new BaseResponseModel();
            bool rev = dal.Delete(pid);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }       
        #endregion

        /// <summary>
        /// 根据主单获取评论记录
        /// </summary>
        /// <param name="MasterID"></param>
        /// <returns></returns>
        public CommentsM GetRecordByMasID(int MasterID)
        {
            return dal.GetRecordByMasID(MasterID);
        }

        /// <summary>
        /// 获取一条评论消息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public CommentsM GetOne(int ID)
        {
            return dal.GetM<CommentsM>(ID);
        }


        /// <summary>
        /// 得到门店总的评论数
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public int GetTotalByStoreID(int StoreID)
        {
            return dal.GetTotalByStoreID(StoreID);
        }


        /// <summary>
        /// 得到门店总的好评数
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public int GetGoodByStoreID(int StoreID)
        {
            return dal.GetGoodByStoreID(StoreID);
        }
        /// <summary>
        /// 获取酒店总的好评
        /// </summary>
        /// <param name="StoreID"></param>
        /// <returns></returns>
        public List<CommentsM> GetGoodRecordByStoreID(int StoreID)
        {
            return dal.GetGoodRecordByStoreID(StoreID);
        }
        }
}
