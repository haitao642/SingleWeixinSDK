using Deepleo.Weixin.SDK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;

namespace Deepleo.Weixin.SDK.Template
{
    /// <summary>
    /// 发送模板消息
    /// </summary>
    public class TemplateSend
    {

        /// <summary>
        /// 推送消息
        /// </summary>
        /// <param name="msgTemplateID"></param>
        /// <param name="sOpenid"></param>
        /// <param name="msg"></param>
        /// <param name="url"></param>
        public static bool PushMessage(string msgTemplateID, string sOpenid, string msg, string url, string accessToken)
        {
            if (string.IsNullOrEmpty(sOpenid))
            {
                return false;
            }

            if (string.IsNullOrEmpty(url))
            {
                //地址到时微信弄好再完善
                //url = string.Format("{0}/order/home.aspx?openid={1}", ConfigValue.WechatModelID, sOpenid);
            }

           
            if (string.IsNullOrEmpty(accessToken))
            {
                return false;
            }
            
            StringBuilder sbContent = new StringBuilder();//模板内容
            sbContent.Append("{");
            sbContent.AppendFormat('"'+"touser"+'"'+":"+'"'+"{0}"+'"'+",", sOpenid);
            sbContent.AppendFormat('"' + "template_id" + '"' + ":" + '"' + "{0}" + '"' + ",", msgTemplateID);
            sbContent.AppendFormat('"' + "url" + '"' + ":" + '"' + "{0}" + '"' + ",", url);
            sbContent.AppendFormat('"' + "topcolor" + '"' + ":" + '"' + "{0}" + '"' + ",", "#886677");//主标题颜色码
            sbContent.Append(msg);
            sbContent.Append("}");


            dynamic dyn1= TemplateMessageAPI.SendTemplateMessage(accessToken, sbContent.ToString());

            return dyn1.errcode==0;
        }



        /// <summary>
        /// 批量推送消息
        /// </summary>
        /// <param name="model"></param>
        public static void PushMessageBat(TemplateValue model)
        {
            if (model == null)
            {
                return;
            }

            TemplateListModel t = new TemplateListModel();
            TemplateModel m = t.GetTemplateModel(model.LylOrderID);

            if (m == null)
            {
                return;
            }
            


            string content = ReplaceObjStr<TemplateValue>(m.content, model);

            List<string> listopenid = model.LylOpenID.Split(',').ToList();

            foreach (string openid in listopenid)
            {
                PushMessage(m.Templateid, openid, content, model.LylUrl, model.LylaccessToken);
            }
        }



        /// <summary>
        /// 替换类里面的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private static string ReplaceObjStr<T>(string str, T model)
            where T : new()
        {
            T entity = new T();
            PropertyInfo[] propinfos = entity.GetType().GetProperties();
            if (propinfos == null)
            {
                return str;
            }
            foreach (PropertyInfo propinfo in propinfos)
            {
                string v = string.Empty;
                object o = propinfo.GetValue(model, null);
                if (o != null)
                {
                    v = o.ToString();
                }
                str = str.Replace(string.Format("%{0}%", propinfo.Name), v);
            }
            return str;
        }
    }
}
