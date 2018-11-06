using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLL
{
  public  class WechatActivityLogB
    {
      DAL.WechatActivityLogD dal = new DAL.WechatActivityLogD();

      /// <summary>
      /// 判断该会员是否已经参与了该活动（true是未参加,false已参加）
      /// </summary>
      /// <param name="openid"></param>
      /// <returns></returns>
      public bool IsActivityLog(string openid) 
      {
          return dal.IsActivityLog(openid);        
      }
    }
}
