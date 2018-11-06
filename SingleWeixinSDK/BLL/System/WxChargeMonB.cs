using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WxChargeMonB
    {
        public DAL.WxChargeMonD dal = new DAL.WxChargeMonD();

        #region 公共方法
        public WxChargeMonB() { }
        

        /// <summary>
        /// 查询所有微信储值充值类型表
        /// </summary>
        /// <returns></returns>
        public List<WxChargeMonM> GetAll()
        {
            return dal.GetAll();
        }
        public WxChargeMonM GetByid(int Ing_Pk_id)
        {
            return dal.GetByid(Ing_Pk_id);
        }
        /// <summary>
        /// 全部记录
        /// </summary>
        /// <returns></returns>
        public List<WxChargeMonM> GetAllM()
        {
            List<WxChargeMonM> list = dal.GetAllM<WxChargeMonM>().OrderBy(x=>x.Ing_order).ToList();
            return list;
        }

        /// <summary>
        /// 根据条件查询微信储值充值类型表
        /// </summary>
        /// <returns></returns>
        public BaseResponseModel GetSearch(string strwhere)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetQueryM<WxChargeMonM>(strwhere);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 查询一条指定的记录:微信储值充值类型表
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public BaseResponseModel Get(int pid)
        {
            BaseResponseModel response = new BaseResponseModel();

            response.data = dal.GetM<WxChargeMonM>(pid);
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;
        }


        /// <summary>
        /// 添加或者修改记录:微信储值充值类型表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseResponseModel SaveOrUpdate(WxChargeMonM model)
        {
            BaseResponseModel response =new BaseResponseModel();
            bool rev = dal.SaveOrUpdate(model);
            response.data = model;
            ConvertResponseB.HandResponse(response, dal.LastError);
            return response;

        }


        /// <summary>
        /// 删除记录:微信储值充值类型表
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
    }
}
