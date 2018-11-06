using Model.WeiXin;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Wechat
{
    public class WeChatConfigD
    {
        public WeChatConfigM GetWeixinConfig(int storeid)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                WeChatConfigM model = new WeChatConfigM();
                doc.Load(@AppDomain.CurrentDomain.BaseDirectory+"WeChatConfig.xml");
                XmlNode xn = doc.SelectSingleNode("WeiXinConfig");
                XmlNodeList xnl = xn.ChildNodes;
                foreach(XmlNode m in xnl)
                {
                    XmlElement xe = (XmlElement)m;
                    int id = xe.FirstChild.InnerXml.ToInt() ;
                    if (id == storeid)
                    {
                        XmlNodeList list = xe.ChildNodes;
                        foreach (XmlNode m1 in list)
                        {
                            if (m1.Name == "ID")
                            {
                                model.ID = m1.InnerXml.ToInt();
                            }
                            if (m1.Name == "Name")
                            {
                                model.Name = m1.InnerXml;
                            }
                            if (m1.Name == "Token")
                            {
                                model.Token = m1.InnerXml;
                            }
                            if (m1.Name == "EncodingAESKey")
                            {
                                model.EncodingAESKey = m1.InnerXml;
                            }
                            if (m1.Name == "AppID")
                            {
                                model.AppID = m1.InnerXml;
                            }
                            if (m1.Name == "AppSecret")
                            {
                                model.AppSecret = m1.InnerXml;
                            }
                            if (m1.Name == "PartnerKey")
                            {
                                model.PartnerKey = m1.InnerXml;
                            }
                            if (m1.Name == "mch_id")
                            {
                                model.mch_id = m1.InnerXml;
                            }
                            if (m1.Name == "device_info")
                            {
                                model.device_info = m1.InnerXml;
                            }
                            if (m1.Name == "spbill_create_ip")
                            {
                                model.spbill_create_ip = m1.InnerXml;
                            }
                            if (m1.Name == "OauthScope")
                            {
                                model.OauthScope = m1.InnerXml;
                            }
                            if (m1.Name == "OpenJSSDK")
                            {
                                model.OpenJSSDK = m1.InnerXml.ToInt();
                            }
                            if (m1.Name == "SMSURL")
                            {
                                model.SMSURL = m1.InnerXml;
                            }
                            if(m1.Name== "HourStart")
                            {
                                model.HourStart= m1.InnerXml.ToInt();
                            }
                            if (m1.Name == "HourEnd")
                            {
                                model.HourEnd = m1.InnerXml.ToInt();
                            }
                        }
                        break;
                    }
                }
                return model;
            }
            catch(Exception ex)
            {
                LogHelper.LogInfo(ex.Message);
                return null;
            }
        }
    }
}
