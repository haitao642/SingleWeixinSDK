using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BLL
{
   public class WechatWalletB
    {
       private DAL.WechatWalletD dal = new DAL.WechatWalletD();

       /// <summary>
       /// 获取微信钱包记录
       /// </summary>
       /// <returns></returns>
       public List<WechatWalletM> GetWalletList(int vipcardid) 
       {
           string strSql = @"SELECT * from T_Wechat_Wallet
                            where Ing_Fk_VipcardId={0} ORDER by Ing_PKID DESC ";
           strSql = string.Format(strSql,vipcardid);
           return dal.GetQueryM<WechatWalletM>(strSql);
       }
    }
}
