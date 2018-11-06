using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLL
{
   public class VipPackageB
    {
       DAL.VipPackageD dal = new DAL.VipPackageD();

       /// <summary>
       /// 根据活动类型获取
       /// </summary>
       /// <param name="code"></param>
       /// <returns></returns>
       public VipPackageM GetPackageModel(string code)
       {
           return dal.GetPackageModel(code);
       }

       /// <summary>
       /// 微信扫码活动赠送礼包
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool BuyPackage(BuyPackageM model)
       {
           return dal.BuyPackage(model);
       }

       /// <summary>
       /// 获取活动使用的门店
       /// </summary>
       /// <param name="type">类型(0优惠券，1活动)</param>
       /// <param name="id">主键</param>
       /// <returns></returns>
       public List<HotelSimpleM> RangeCaption(int type, int id) 
       {
           return dal.RangeCaption(type, id);
       }
    }
}
