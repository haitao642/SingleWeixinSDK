using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepleo.Weixin.SDK.Template
{
    /// <summary>
    /// 模板消息的内容字符串
    /// </summary>
    public class TemplateString
    {
        /// <summary>
        /// 得到模板内容
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public string GetTempateContent(List<TemplateParam> list)
        {
            StringBuilder sbContent = new StringBuilder();

            sbContent.Append('"'+"data"+'"'+":{");
            int order = 0;
            foreach (TemplateParam m in list)
            {
                order++;
                sbContent.Append('"');
                sbContent.Append(m.key);
                sbContent.Append('"'+":{");
                sbContent.AppendFormat('"' + "value" + '"' + ":" + '"' + "%{0}%" + '"' + ",", m.key);
                sbContent.AppendFormat('"' + "color" + '"' + ":" + '"' + "{0}" + '"', m.color);
                sbContent.Append("}");
                if (order < list.Count)
                {
                    sbContent.Append(",");
                }

            }
            sbContent.Append("}");

            return sbContent.ToString();
        }

        /// <summary>
        /// 绑定成功通知
        /// </summary>
        public string str1
        {
            get {

                ///        {{first.DATA}}
                ///用户名：{{keyword1.DATA}}
                ///用户类型：{{keyword2.DATA}}
                ///绑定时间：{{keyword3.DATA}}
                ///{{remark.DATA}}
             
                List<TemplateParam> list = new List<TemplateParam>();
                list.Add(new TemplateParam("first", "#444456"));
                list.Add(new TemplateParam("keyword1", "#126787"));
                list.Add(new TemplateParam("keyword2", "#126787"));
                list.Add(new TemplateParam("keyword3", "#126787"));
                list.Add(new TemplateParam("remark", "#000000"));
                return GetTempateContent(list);
            }
        }


        /// <summary>
        /// 订单提交成功
        /// </summary>
        public string str2
        {
            get
            {

                //                {{first.DATA}}

                //订单号：{{orderID.DATA}}
                //待付金额：{{orderMoneySum.DATA}}
                //{{backupFieldName.DATA}}{{backupFieldData.DATA}}
                //{{remark.DATA}}

                List<TemplateParam> list = new List<TemplateParam>();
                list.Add(new TemplateParam("first", "#444456"));
                list.Add(new TemplateParam("orderID", "#126787"));
                list.Add(new TemplateParam("orderMoneySum", "#126787"));
                list.Add(new TemplateParam("backupFieldName", "#126787"));
                list.Add(new TemplateParam("backupFieldData", "#126787"));
                list.Add(new TemplateParam("remark", "#000000"));
                return GetTempateContent(list);
            }
        }


        /// <summary>
        /// 取消订单提醒
        /// </summary>
        public string str3
        {
            get
            {

                //               {{first.DATA}}

                //您已成功取消订单
                //分店：{{hotelName.DATA}}
                //价格：{{pay.DATA}}
                //入住日期：{{arriveDate.DATA}}
                //离店日期：{{departureDate.DATA}}
                //{{remark.DATA}}

                List<TemplateParam> list = new List<TemplateParam>();
                list.Add(new TemplateParam("first", "#444456"));
                list.Add(new TemplateParam("hotelName", "#126787"));
                list.Add(new TemplateParam("pay", "#126787"));
                list.Add(new TemplateParam("arriveDate", "#126787"));
                list.Add(new TemplateParam("departureDate", "#126787"));
                list.Add(new TemplateParam("remark", "#000000"));
                return GetTempateContent(list);
            }
        }


        
    }


    /// <summary>
    /// 变量
    /// </summary>
    public class TemplateParam
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="skey"></param>
        /// <param name="scolor"></param>
        public TemplateParam(string skey, string scolor)
        {
            key = skey;
            color = scolor;
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string key { get; set; }


        /// <summary>
        /// 颜色
        /// </summary>
        public string color { get; set; }
    }

    /// <summary>
    /// 模板消息
    /// </summary>
    public class TemplateModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int orderid { get; set; }
        /// <summary>
        /// 模板id
        /// </summary>
        public string Templateid { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }
    }

    public class TemplateListModel
    {
        private TemplateString ts = new TemplateString();
        #region  变量
        /// <summary>
        /// 绑定成功通知
        /// </summary>
        private TemplateModel m1
        {
            get {
                TemplateModel m = new TemplateModel();
                m.orderid = 1;
                m.Templateid = "CLWvHT1DVjYcHTofTMds-OR2shx2QfXWAcaQZzPm76U";
                m.desc = "绑定成功通知";
                m.content = ts.str1;
                return m;
            }
        }


        /// <summary>
        /// 订单提交成功
        /// </summary>
        private TemplateModel m2
        {
            get
            {
                TemplateModel m = new TemplateModel();
                m.orderid = 2;
                m.Templateid = "2YucaXs0I3-_Elv-fxn0AyOeM97Am3Fk9v3QbydhE2s";
                m.desc = "订单提交成功";
                m.content = ts.str2;
                return m;
            }
        }


        /// <summary>
        /// 取消订单提醒
        /// </summary>
        private TemplateModel m3
        {
            get
            {
                TemplateModel m = new TemplateModel();
                m.orderid = 3;
                m.Templateid = "2Iplzc_aQqUG3WUxxpp31mZxKx3F6EqgqkFMq8f9rl8";
                m.desc = "取消订单提醒";
                m.content = ts.str3;
                return m;
            }
        }

        #endregion


        /// <summary>
        /// 取模板消息
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        public TemplateModel GetTemplateModel(int orderid)
        {
            TemplateModel m = new TemplateModel();
            switch (orderid)
            { 
                case 1:
                    m = m1;
                    break;
                case 2:
                    m = m2;
                    break;
                case 3:
                    m = m3;
                    break;
                default:
                    m = null;
                    break;

            }
            return m;
        }
    }
}
