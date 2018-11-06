using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WxPayResultB
    {
        public DAL.WxPayResultD dal = new DAL.WxPayResultD();

        #region 公共方法
        public WxPayResultB() { }

        /// <summary>
        /// 查询所有微信支付结果表
        /// </summary>
        /// <returns></returns>
        public BaseResponseModel GetAll()
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetAllM<WxPayResultM>();
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }

        /// <summary>
        /// 根据条件查询微信支付结果表
        /// </summary>
        /// <returns></returns>
        public BaseResponseModel GetSearch(string strwhere)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetQueryM<WxPayResultM>(strwhere);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 查询一条指定的记录:微信支付结果表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public BaseResponseModel Get(int pid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetM<WxPayResultM>(pid);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 添加或者修改记录:微信支付结果表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel SaveOrUpdate(WxPayResultM model)
        {
            BaseResponseModel response =new BaseResponseModel();
            bool rev = dal.SaveOrUpdate(model);
            response.data = model;
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;

        }


        /// <summary>
        /// 删除记录:微信支付结果表
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
        /// 根据类型和对应的主键id查询记录   支付成功的记录
        /// </summary>
        /// <param name="Ing_type"></param>
        /// <param name="Ing_pkid"></param>
        /// <returns></returns>
        public WxPayResultM GetMoelBypid(int Ing_type, int Ing_pkid)
        {
            return dal.GetMoelBypid(Ing_type, Ing_pkid);
        }


        /// <summary>
        /// 支付成功后的操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel AddPayResult(WxPayResultM model)
        {
            BaseResponseModel response = new BaseResponseModel();
            bool rev = dal.AddPayResult(model);
            response.data = model;
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }
    }
}
