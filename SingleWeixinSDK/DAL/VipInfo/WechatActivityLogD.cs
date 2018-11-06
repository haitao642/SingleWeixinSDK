using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Public;
using Bee.Web;
namespace DAL
{
   public class WechatActivityLogD:BaseTable
    {

       public WechatActivityLogD()
           : base("T_Wechat_ActivityLog", "Ing_PKID")
        {

        }

       /// <summary>
       /// 判断该会员是否已经参与了该活动（true是未参加,false已参加）
       /// </summary>
       /// <param name="openid"></param>
       /// <returns></returns>
       public bool IsActivityLog(string openid) 
       {
           string strSql = "SELECT isnull(count(*),0) from T_Wechat_ActivityLog where str_Openid=@openid and Ing_Type=@Ing_Type";
           this.Sqlca.AddParameter("@openid", openid);
           this.Sqlca.AddParameter("@Ing_Type", ConfigValue.ActivityType);
           return this.Sqlca.GetInt32(strSql)==0;
       }


       /// <summary>
       /// 保存活动记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool SaveOrUpdate(WechatActivityLogM model, DataTrans DataTrans=null)
       {
           if (DataTrans != null) 
           {
               this.Sqlca = DataTrans;
           }

           if (model.Ing_PKID == 0)
           {
               model.str_Creator = "微信扫码";
               model.dt_Create = DateTime.Now;
           }
           bool rev = this.UpdateRecord<WechatActivityLogM>(model, model.Ing_PKID,this.Sqlca);
           model.Ing_PKID = this.lngKeyID;
           return rev;
       }

    }
}
