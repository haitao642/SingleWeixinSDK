using Public;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using Model.RoomCenter;
using DAL.Wechat;
using Model.WeiXin;

namespace DAL
{
    public class WeChatD: BaseTable
    {
        public WeChatD()
            : base("", "")
        { }


        #region 基础方法
         /// <summary>
        /// 获取token
         /// </summary>
         /// <returns></returns>
        private static string GetToken()
        {
            Public.WechatTokenServices.WeChatSoapClient ws = new Public.WechatTokenServices.WeChatSoapClient();
            Public.WechatTokenServices.ResultM model = new Public.WechatTokenServices.ResultM();
            try
            {
                model = ws.GetWechatToken(ConfigValue.AppID);
                if (model == null)
                {
                    return null;
                }
                if (!model.Rev)
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            return model.strRev;
            //string postUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
            //postUrl = string.Format(postUrl, ConfigValue.AppID, ConfigValue.AppSecret);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(postUrl);
            //request.Method = "GET";
            //request.ContentType = "text/html;charset=UTF-8";

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream myResponseStream = response.GetResponseStream();
            //StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            //string retString = myStreamReader.ReadToEnd();
            //myStreamReader.Close();
            //myResponseStream.Close();


            //JSONObjectS jarray = JSONConvertS.DeserializeObject(retString);

            //string sReturn = jarray["access_token"].ToString();


            //return sReturn;


        }


        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="msgTemplateID"></param>
        /// <param name="sOpenid"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static void PushMessage(string msgTemplateID, string sOpenid, string msg, string url,string accessToken)
        {
            if (string.IsNullOrEmpty(sOpenid))
            {
                LogHelper.LogInfo("没有openid");
                return;
            }
            if (string.IsNullOrEmpty(url))
            {
                //地址到时微信弄好再完善
                //url = string.Format("{0}/order/home.aspx?openid={1}", ConfigValue.WechatModelID, sOpenid);
            }
            if (string.IsNullOrEmpty(accessToken))
            {
                LogHelper.LogInfo("没有token");
                return;
            }
            LogHelper.LogInfo("accessToken:"+accessToken);
            string pushUrl = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", accessToken);
            StringBuilder sbContent = new StringBuilder();//模板内容
            sbContent.Append("{");
            sbContent.AppendFormat("\"touser\":\"{0}\",", sOpenid);
            sbContent.AppendFormat("\"template_id\":\"{0}\",", msgTemplateID);
            sbContent.AppendFormat("\"url\":\"{0}\",", url);
            sbContent.AppendFormat("\"topcolor\":\"{0}\",", "#886677");//主标题颜色码
            sbContent.Append(msg);
            sbContent.Append("}");
            string responeStr=string.Empty;
            try
            {
                WebClient wc = new WebClient();
                wc.Encoding = System.Text.Encoding.UTF8;
                byte[] resultData = wc.UploadData(pushUrl, "POST", System.Text.Encoding.UTF8.GetBytes(sbContent.ToString()));
                responeStr = System.Text.Encoding.UTF8.GetString(resultData);
            }
            catch (Exception ex)
            {
                LogHelper.LogInfo(string.Format("结果:{0},token:{1},错误消息:{2}", responeStr,accessToken,ex.Message));
            }
        }

        #endregion

        /// <summary>
        /// 绑定成功通知
        /// </summary>
        /// <param name="model"></param>
        public void BindSuccessNotice(BindSuccessM model)
        {
            if (model == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(model.first))
            {
                model.first = "您好！您的微信号与系统账号绑定成功";
            }

            if (string.IsNullOrEmpty(model.keyword2))
            {
                model.keyword2 = "个人用户";
            }

            if (string.IsNullOrEmpty(model.keyword3))
            {
                model.keyword3 = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm");
            }




            StringBuilder sbContent = new StringBuilder();



            sbContent.Append("\"data\":{");
            sbContent.Append("\"first\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.first);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");
            sbContent.Append("\"keyword1\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.keyword1);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");

            sbContent.Append("\"keyword2\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.keyword2);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");

            sbContent.Append("\"keyword3\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.keyword3);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");
            sbContent.Append("\"remark\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.remark);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#000000");
            sbContent.Append("}");
            sbContent.Append("}");

            string url = "";

            PushMessage(ConfigValue.ModelID(1), model.Openid, sbContent.ToString(), url,model.token);
        }


        /// <summary>
        /// 支付房费成功
        /// {{first.DATA}}

//订单号：{{folioId.DATA}}
//已成功支付房费{{roomRate.DATA}}元，房间整晚保留！
//{{remark.DATA}}
        /// </summary>
        /// <param name="model"></param>
        public void WeChatPaySuccess(WeChatPaySuccessM model)
        {
            if (model == null)
            {
                LogHelper.LogInfo("支付成功推送消息报错，发送微信时，参数为空");
                return;
            }

            MasterD masD = new MasterD();
            MasterM masM = masD.GetM<MasterM>(model.masterid);

            if (masM == null)
            {
                return;
            }

            model.first = "支付房费成功";
            model.folioId = masM.str_Pk_Accnt;
            if (masM.dec_ActualRate.HasValue)
            {
                model.roomRate = masM.dec_ActualRate.Value.ToString();
            }

            StoreInfoD infoD = new StoreInfoD();
            StoreInfoM infoM = infoD.GetM<StoreInfoM>(masM.Ing_StoreID ?? 0);
            if (infoM == null)
            {
                return;
            }

            RoomTypeD typeD = new RoomTypeD();
            RoomTypeM typeM = typeD.GetRoomType(masM.Ing_StoreID ?? 0, masM.str_RoomType);
            if (typeM == null)
            {
                return;
            }

            model.remark = string.Format("你的支付信息：门店：{0} 房型：{1} 来期:{2}  离期:{3}",infoM.str_StoreName,typeM.str_TypeName,masM.dt_ArrDate.HasValue?masM.dt_ArrDate.Value.ToString("MM-dd"):"",masM.dt_DepDate.HasValue?masM.dt_DepDate.Value.ToString("MM-dd"):"");




            StringBuilder sbContent = new StringBuilder();



            sbContent.Append("\"data\":{");
            sbContent.Append("\"first\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.first);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");
            sbContent.Append("\"folioId\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.folioId);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");

            sbContent.Append("\"roomRate\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.roomRate);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");
            
            sbContent.Append("\"remark\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.remark);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#000000");
            sbContent.Append("}");
            sbContent.Append("}");

            string url = "";

            PushMessage(ConfigValue.ModelID(2), model.Openid, sbContent.ToString(), url,model.token);
        }


        /// <summary>
        /// 预订成功
        /// </summary>
        /// <param name="model"></param>
        public void OrderSuccess(WeChatOrderSuccessM model)
        {
            if (model == null)
            {
                LogHelper.LogInfo("修改预订成功报错，发送微信时，参数为空");
                return;
            }
            

            StringBuilder sbContent = new StringBuilder();



            sbContent.Append("\"data\":{");
            sbContent.Append("\"first\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.first);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");
            sbContent.Append("\"order\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.order);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");

            sbContent.Append("\"Name\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.Name);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");


            sbContent.Append("\"datein\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.datein);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");


            sbContent.Append("\"dateout\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.dateout);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");

            sbContent.Append("\"number\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.number);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");

            sbContent.Append("\"room type\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.roomtype);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");

            sbContent.Append("\"pay\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.pay);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");

            sbContent.Append("\"remark\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.remark);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#000000");
            sbContent.Append("}");
            sbContent.Append("}");

            string url = "";

            PushMessage(ConfigValue.ModelID(3), model.Openid, sbContent.ToString(), url,model.token);
        }



        /// <summary>
        /// 取消预订
        /// </summary>
        /// <param name="model"></param>
        public void OrderCancel(WeChatCancelOrderM model)
        {
            if (model == null)
            {
                LogHelper.LogInfo("修改取消预订报错，发送微信时，参数为空");
                return;
            }
            if (string.IsNullOrEmpty(model.first))
            {
                model.first = "尊敬的会员：";
            }


            StringBuilder sbContent = new StringBuilder();



            sbContent.Append("\"data\":{");
            sbContent.Append("\"first\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.first);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");
            sbContent.Append("\"hotelName\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.hotelName);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");

            sbContent.Append("\"pay\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.pay);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");


            sbContent.Append("\"arriveDate\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.arriveDate);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");


            sbContent.Append("\"departureDate\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.departureDate);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");
            

            sbContent.Append("\"remark\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.remark);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#000000");
            sbContent.Append("}");
            sbContent.Append("}");

            string url = "";

            PushMessage(ConfigValue.ModelID(4), model.Openid, sbContent.ToString(), url,model.token);
        }



        #region 客人与店长在评价方面的互动
        /// <summary>
        /// //    问题咨询处理进度提醒

        //{{serviceInfo.DATA}}
        //服务类型：{{serviceType.DATA}}
        //处理状态：{{serviceStatus.DATA}}
        //提交时间：{{time.DATA}}
        //{{remark.DATA}}    VVGZDsyLuIyNaXvsKoU5mB2lbNVF80dtxQtNFWHmiso
        /// </summary>
        /// <param name="model"></param>
        public void OrderComment(WeChatQuestionM model)
        {
            if (model == null)
            {
                LogHelper.LogInfo("问题咨询处理进度提醒，发送微信时，参数为空");
                return;
            }

            model.time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            StringBuilder sbContent = new StringBuilder();



            sbContent.Append("\"data\":{");
            sbContent.Append("\"serviceInfo\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.serviceInfo);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");
            sbContent.Append("\"serviceType\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.serviceType);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#444456");
            sbContent.Append("},");

            sbContent.Append("\"serviceStatus\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.serviceStatus);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");


            sbContent.Append("\"time\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.time);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#126787");
            sbContent.Append("},");


            sbContent.Append("\"remark\":{");
            sbContent.AppendFormat("\"value\":\"{0}\",", model.remark);
            sbContent.AppendFormat("\"color\":\"{0}\"", "#000000");
            sbContent.Append("}");
            sbContent.Append("}");

            string url = string.Format("{0}/MyAccount/Question/{1}",ConfigValue.GetDomain,model.CommentID);

            PushMessage(ConfigValue.ModelID(5), model.Openid, sbContent.ToString(), url,model.token);
        }

        #endregion


        #region 每天储值会员订房三单或者三单以上（同一天,的订单，>=3）
        /// <summary>
        /// 每天储值会员订房三单或者三单以上（同一天,的订单，>=3）
        /// </summary>
        /// <param name="model"></param>
        public void VipOrder(WeChatChargeMon model)
        {
            if (model == null)
            {
                LogHelper.LogInfo("储值会员订单超过三次推送,参数为空");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("\"data\":{");
            sb.Append("\"first\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.first);
            sb.Append("},");

            sb.Append("\"keyword1\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword1);
            sb.Append("},");

            sb.Append("\"keyword2\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword2);
            sb.Append("},");

            sb.Append("\"remark\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.remark);
            sb.Append("}");

            sb.Append("}");
            PushMessage(ConfigValue.ModelID(7), model.Openid, sb.ToString(), "",model.token);
        }

        /// <summary>
        /// 每天储值会员订房三单或者三单以上（同一天,的订单，>=3）
        /// </summary>
        /// <param name="model"></param>
        public void VipOrderAll(WeChatChargeMon model)
        {
            UsersGrpD userD = new UsersGrpD();
            List<UsersGrpM> list = new List<UsersGrpM>();
            list = userD.GetManagerByStoreID(model.Ing_StoreID);

            if (list.Count == 0)
            {
                LogHelper.LogInfo(string.Format("门店：{0}  每天储值会员订房三单或者三单以上（同一天,的订单，>=3），没有微信接收者", model.Ing_StoreID));
                return;
            }

            WeChatChargeMon mod1 = new WeChatChargeMon();
            foreach (UsersGrpM mod in list)
            {
                if (string.IsNullOrEmpty(mod.str_openid))
                {
                    continue;
                }
                mod1 = model;
                mod1.Openid = mod.str_openid;

                VipOrder(mod1);
            }
        }
        #endregion


        #region 储值推送
        /// <summary>
        /// 储值卡充值消费推送
        /// </summary>
        /// <param name="model"></param>
        public void ChargeMon(WeChatChargeMon model)
        {
            if (model == null)
            {
                LogHelper.LogInfo("储值卡充值消费，参数为空");
                return;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("\"data\":{");
            sb.Append("\"first\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.first);
            sb.Append("},");

            sb.Append("\"keyword1\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword1);
            sb.Append("},");

            sb.Append("\"keyword2\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword2);
            sb.Append("},");

            sb.Append("\"keyword3\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword3);
            sb.Append("},");

            sb.Append("\"keyword4\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword4);
            sb.Append("},");

            sb.Append("\"keyword5\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.keyword5);
            sb.Append("},");

            sb.Append("\"remark\":{");
            sb.AppendFormat("\"value\":\"{0}\"", model.remark);
            sb.Append("}");

            sb.Append("}");
            LogHelper.LogInfo("储值卡充值消费，:"+model.Openid+"::"+sb.ToString());
            PushMessage(ConfigValue.ModelID(6), model.Openid, sb.ToString(), "",model.token);
        }

        #endregion
    }
}
