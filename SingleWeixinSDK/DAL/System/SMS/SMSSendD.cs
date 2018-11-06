using DAL.Wechat;
using Model;
using Model.Log;
using Model.WeChat;
using Public;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL
{
    /// <summary>
    /// 发送短信的类
    /// </summary>
    public class SMSSendD : BaseTable
    {
        public SMSSendD()
            : base("", "")
        { }
        
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        public bool SendMsg<T>(SMSSendM model,T model1) 
            where T:new()
        {
            //SysParaD ParaD = new SysParaD();
            //SysParaM ParaM = new SysParaM();
            //ParaM = ParaD.GetRecord("SMSlimit", "SMSlimit");
            //if (ParaM == null)
            //{
            //    this.LastError = "L短信功能关闭";
            //    goto updateerr;
            //}
            //if (!ParaM.str_ParaData.Trim().Equals("1"))
            //{
            //    this.LastError = "L短信功能关闭";
            //    goto updateerr;
            //}
            //ParaM = ParaD.GetRecord("SMSURL", "SMSURL");
            //if (ParaM == null)
            //{
            //    this.LastError = "L短信地址未配置";
            //    goto updateerr;
            //}
            //if (string.IsNullOrEmpty(ParaM.str_ParaData))
            //{
            //    this.LastError = "L短信地址未配置";
            //    goto updateerr;
            //}

            ///短信发送地址
            //string SMSURL = string.Format("{0}&Cell=&SendTime=",ParaM.str_ParaData.Trim());


            SMSBaseD BaseD = new SMSBaseD();
            SMSBaseM BaseM = new SMSBaseM();
            BaseM = BaseD.GetSMSBaseOneM(model.Ing_StoreID, model.SMSType);
            if (BaseM == null)
            {
                this.LastError = "L短信类别未配置";
                goto updateerr;
            }

            if (!BaseM.Ing_sta.HasValue)
            {
                this.LastError = "L短信类别停用了";
                goto updateerr;
            }

            if (BaseM.Ing_sta.Value!=1)
            {
                this.LastError = "L短信类别停用了";
                goto updateerr;
            }
            //短信类型
            string SMSName = BaseM.str_SMSName;

            //短信内容
            string SMSContent = BaseM.str_SMSContent;
            if (string.IsNullOrEmpty(SMSContent))
            {
                this.LastError = "L短信内容不能为空";
                goto updateerr;
            }
            SMSContent = ReplaceStoreInfo(SMSContent, model.Ing_StoreID);
            SMSContent=Public.ConverTableAndList.ReplaceObjStr<T>(SMSContent, model1);
            model.SMSContent = SMSContent;
            //手机
            string Mobile = model.Mobile;
            if (string.IsNullOrEmpty(Mobile))
            {
                this.LastError = "L手机不能为空";
                goto updateerr;
            }

            if (!this.IsHandset(Mobile))
            {
                this.LastError = "L手机号码不正确";
                goto updateerr;
            }
            
            //if (SMSContent.Length > ConfigValue.SMSLEN)
            //{
            //    int num = (SMSContent.Length / ConfigValue.SMSLEN) + 1;//50个汉字字符
            //    string temp = "";
            //    int len = 0;


            //    for (int i = 0; i < num; i++)
            //    {
            //        len = (SMSContent.Length - i * ConfigValue.SMSLEN) > ConfigValue.SMSLEN ? ConfigValue.SMSLEN : (SMSContent.Length - i * ConfigValue.SMSLEN);

            //        temp = SMSContent.Substring(i * ConfigValue.SMSLEN, len);

            //        SMSSendM m = model;
            //        m.SMSContent = temp;
            //        SendMessage(SMSURL, SMSName, m);
            //    }

            //}
            //else
            //{
            //    SendMessage(SMSURL, SMSName, model);
            //}
            return true;
        updateerr:
            LogHelper.LogInfo(string.Format("发送短信失败:{0}", this.LastError));
            return false;
        }
        public string GetSendContent<T>(SMSSendM model,T model1) where T : new()
        {
            SMSBaseD BaseD = new SMSBaseD();
            SMSBaseM BaseM = new SMSBaseM();
            BaseM = BaseD.GetSMSBaseOneM(model.Ing_StoreID, model.SMSType);
            StoreInfoD sd = new StoreInfoD();

            StoreM smodel = sd.GetStore(model.Ing_StoreID);
            if (BaseM == null)
            {
                this.LastError = "L短信类别未配置";
                goto updateerr;
            }

            if (!BaseM.Ing_sta.HasValue)
            {
                this.LastError = "L短信类别停用了";
                goto updateerr;
            }

            if (BaseM.Ing_sta.Value != 1)
            {
                this.LastError = "L短信类别停用了";
                goto updateerr;
            }
            //短信类型
            string SMSName = BaseM.str_SMSName;

            //短信内容
            string SMSContent = BaseM.str_SMSContent;
            if (string.IsNullOrEmpty(SMSContent))
            {
                this.LastError = "L短信内容不能为空";
                goto updateerr;
            }
            string Mobile = model.Mobile;
            if (string.IsNullOrEmpty(Mobile))
            {
                this.LastError = "L手机不能为空";
                goto updateerr;
            }

            if (!this.IsHandset(Mobile))
            {
                this.LastError = "L手机号码不正确";
                goto updateerr;
            }

            
            SMSContent = ReplaceStoreInfo(SMSContent, model.Ing_StoreID);
            SMSContent = Public.ConverTableAndList.ReplaceObjStr<T>(SMSContent, model1);
            SMSContent = SMSContent+ "【"+ smodel.str_StoreName+"】";
            //手机

            return SMSContent;
            updateerr:
            return "";
        }
        public bool AddLog(SMSSendM model)
        {
            try
            {
                SMSBaseD BaseD = new SMSBaseD();
                SMSBaseM BaseM = new SMSBaseM();
                BaseM = BaseD.GetSMSBaseOneM(model.Ing_StoreID, model.SMSType);
                SMSLogD logD = new SMSLogD();
                SMSLogM logM = new SMSLogM();
                logM.Ing_StoreID = model.Ing_StoreID;
                logM.str_Mobile = model.Mobile;
                logM.str_SMSName = BaseM.str_SMSName;
                logM.str_SMSType = BaseM.str_SMSType;
                logM.str_SMSURL = "";
                logM.str_SMSContent = model.SMSContent;
                logM.str_Sender = model.Sendman;
                logM.str_ReturnMsg = model.rev;
                logM.Ing_sta = BaseM.Ing_sta;
                logM.dt_SendTime = DateTime.Now;
                logD.UpdateRecord<SMSLogM>(logM, 0);
                return true;
            }catch(Exception ex)
            {
                LogHelper.LogInfo(ex.Message);
                return false;
            }
            
        }
        /// <summary>
        /// 验证手机
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public bool IsHandset(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+\d{10}");
        }

        /// <summary>
        /// 替换酒店的一些信息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public string ReplaceStoreInfo(string str, int Ing_StoreID)
        {
            StoreInfoD storeD = new StoreInfoD();
            StoreInfoM storeM = new StoreInfoM();
            storeM = storeD.GetM<StoreInfoM>(Ing_StoreID);
            if (storeM == null)
            {
                return str;
            }
            ParaForStoreM model = new ParaForStoreM();
            model.StoreName = storeM.str_StoreName;
            model.PhnNo = storeM.str_hotTel;
            model.Address = storeM.str_Address;
            str = Public.ConverTableAndList.ReplaceObjStr<ParaForStoreM>(str, model);
            return str;
        }
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="SMSURL"></param>
        /// <param name="SMSName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendMessage(string SMSURL, string SMSName, SMSSendM model)
        {
            string SMSContent = model.SMSContent;
            SMSContent = SMSContent.Replace(" ","");
            SMSContent = HttpUtility.UrlEncode(SMSContent, Encoding.GetEncoding("gb2312"));//utf8 转GB2312

            string SMSURL1 =string.Format("{0}&mobile={1}&Content={2}",SMSURL,model.Mobile,SMSContent);

            HttpWebRequest Rst = (HttpWebRequest)WebRequest.Create(SMSURL1);
            HttpWebResponse Rsp = (HttpWebResponse)Rst.GetResponse();
            StreamReader reader = new StreamReader(Rsp.GetResponseStream(), Encoding.GetEncoding("gb2312"));
            string ct = reader.ReadToEnd();
            SysBusnTypeD BusnD = new SysBusnTypeD();
            List<SysBusnTypeM> list = new List<SysBusnTypeM>();
            list = BusnD.GetBusnTypeByBusineTypeID("SmsErrorType");

            string rev = "未定义返回值";
            SysBusnTypeM BusnM = list.Where(x => x.str_TypeCode.Trim().Equals(ct.Trim())).FirstOrDefault();
            if (BusnM != null)
            {
                rev = BusnM.str_TypeName;
            }
            int sta = -1;
            if (!int.TryParse(ct, out sta))
            {
                rev = "发送过程中出错";
            }
            //如果返回大于0,表示发送成功
            if (sta > 0)
            {
                sta = 1;
            }
            else
            {
                sta = 0;
            }
            ///写日志
            SMSLogD logD = new SMSLogD();
            SMSLogM logM = new SMSLogM();
            logM.Ing_StoreID = model.Ing_StoreID;
            logM.str_Mobile = model.Mobile;
            logM.str_SMSName = SMSName;
            logM.str_SMSType = model.SMSType;
            logM.str_SMSURL = SMSURL;
            logM.str_SMSContent = model.SMSContent;
            logM.str_Sender = model.Sendman;
            logM.str_ReturnMsg = rev;
            logM.Ing_sta = sta;
            logM.dt_SendTime = DateTime.Now;
            logD.UpdateRecord<SMSLogM>(logM, 0);
            return true;
        }
        public BaseResponseModel sendSms(string content, string mobile, int ing_StoreID)
        {
            BaseResponseModel model = new BaseResponseModel();
            StoreInfoD sd = new StoreInfoD();
            StoreM smodel = sd.GetStore(ing_StoreID);
            if (smodel.Ing_SmsNumber < 1)
            {
                model.status = 1;
                LogHelper.LogInfo("门店" + smodel.str_StoreName + "短信余额不足");
                return model;
            }
            if (!this.Sqlca.BeginTransaction())
            {
                this.LastError = this.Sqlca.LastError;
                goto updateerr;
            }
            //////扣减短信余额
            smodel.Ing_SmsNumber -= 1;
            if (!sd.UpdateRecord<StoreM>(smodel, smodel.Ing_StoreID, this.Sqlca))
            {
                LogHelper.LogInfo("更新酒店短信余额失败");
                goto updateerr;
            }
            ////插入扣除记录
            StoreMoneyM storeMoneyM = new StoreMoneyM();
            storeMoneyM.Ing_StoreID = ing_StoreID;
            storeMoneyM.Ing_charge_type = 0;
            storeMoneyM.str_trade_type = "SMS";
            storeMoneyM.Ing_charge_num = 1;
            storeMoneyM.dec_balance = smodel.Ing_SmsNumber;
            storeMoneyM.dt_charge_time = DateTime.Now;
            storeMoneyM.str_remark = "公众号发送短信";
            storeMoneyM.Ing_state = 1;
            StoreMoneyD moneyD = new StoreMoneyD();
            if(!moneyD.UpdateRecord<StoreMoneyM>(storeMoneyM,0, this.Sqlca))
            {
                LogHelper.LogInfo("插入酒店短信消费记录失败");
                goto updateerr;
            }
            int i = 0;
            string[] args = new string[6];
            args[0] = ConfigValue.SmsAccount;
            args[1] = ConfigValue.SmsPwd;
            args[2] = mobile;
            args[3] = content;
            args[4] = "";
            args[5] = "";
            var data = SMSHelper.InvokeWebService(ConfigValue.SMSURL, "BatchSend2", args);

            //String res =client.BatchSend2Async(Public.ConfigValue.SmsAccount, Public.ConfigValue.SmsPwd, mobile, Content, "", "");
            int.TryParse(data.ToString(), out i);
            LogHelper.LogInfo("短信发送返回值:" + i.ToString() + ",内容:" + content);
            if (i <= 0)
            {
                LogHelper.LogInfo("短信接口发送失败");
                goto updateerr;
            }
            model.status = 0;
            model.message = data.ToString();
            this.Sqlca.CommitTransaction();
            this.Sqlca.Close();
            return model;
            updateerr:
            if (string.IsNullOrEmpty(this.LastError))
            {
                this.LastError = this.Sqlca.LastError;
            }
            this.Sqlca.RollbackTransaction();
            this.Sqlca.Close();
            model.status = 1;
            return model;
        }
    }
}
