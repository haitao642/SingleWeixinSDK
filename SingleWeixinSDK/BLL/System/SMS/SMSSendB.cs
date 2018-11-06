using Model;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SMSSendB
    {
        public DAL.SMSSendD dal = new DAL.SMSSendD();
                /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public bool SendMsg<T>(SMSSendM model, T model1)
            where T : new()
        {
            return dal.SendMsg(model,model1);
        }
        public bool AddLog(string rev,string mobile,string content,int ing_StoreID)
        {
            SMSSendM model = new SMSSendM();
            model.Mobile = mobile;
            model.SMSContent = content;
            model.SMSType = "WechatBind";
            model.Sendman = "wechat";
            model.Ing_StoreID = ing_StoreID;
            model.rev = rev;
            return dal.AddLog(model);
        }
        public BaseResponseModel sendSms(string content,string mobile,int ing_StoreID)
        {
            return dal.sendSms(content, mobile, ing_StoreID);
        }
    }
}
