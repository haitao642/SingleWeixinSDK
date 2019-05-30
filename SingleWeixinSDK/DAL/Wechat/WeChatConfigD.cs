using Model;
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
    public class WeChatConfigD: BaseTable
    {
        public WeChatConfigD() : base("T_WeChat_Config", "Ing_Pk_ID")
        {
            this.Sqlca = SqlcaOTAPMS();
        }

        public WeChatFileM GetOne(int Ing_PK_FileID)
        {
            WeChatFileM result = new WeChatFileM();
            string sql = "select * from T_WeChat_File where Ing_PK_FileID=" + Ing_PK_FileID;
            result = this.GetQueryM<WeChatFileM>(sql).FirstOrDefault();
            return result;//取得全部的model
        }


        public Model.WeChatConfigM GetWeixinConfigForOta(string storeid)
        {
            string sql = "select * from T_WeChat_Config where Ing_Fk_SPkID={0}";
            sql = string.Format(sql, storeid);
            return this.GetQueryM<Model.WeChatConfigM>(sql).FirstOrDefault();
        }


        /// <summary>
        /// 根据酒店ID,营业点类型获取营业点图片
        /// </summary>
        /// <param name="Ing_Fk_SPkID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<WeChatFileM> getOutLetImgList(string Ing_Fk_SPkID,int type)
        {
            return new List<WeChatFileM>();//取得全部的model
        }


        /// <summary>
        /// 根据酒店ID获取门店图片
        /// </summary>
        /// <param name="Ing_Fk_SPkID"></param>
        /// <returns></returns>
        public List<WeChatFileM> getStoreImgList(string Ing_Fk_SPkID)
        {
            List<WeChatFileM> list = new List<WeChatFileM>();
            string sql = "select a.*,b.str_StoreName from T_WeChat_File a  left join T_Store_Info b on b.Ing_SPkID=a.Ing_Fk_SPkID where Ing_Fk_SPkID=" + Ing_Fk_SPkID + " and Ing_Type=1 and is_Deleted=1 order by Ing_PK_FileID desc";
            list = this.GetQueryM<WeChatFileM>(sql);
            return list;//取得全部的model
        }
        /// <summary>
        /// 根据酒店ID，房型ID获取房型图片
        /// </summary>
        /// <param name="Ing_Fk_SPkID"></param>
        /// <param name="Ing_FK_ID"></param>
        /// <returns></returns>
        public List<WeChatFileM> getRoomTypeImgList(string Ing_Fk_SPkID, int Ing_FK_ID)
        {
            List<WeChatFileM> list = new List<WeChatFileM>();
            string sql = "select * from T_WeChat_File where Ing_Fk_SPkID=" + Ing_Fk_SPkID + " and Ing_FK_ID=" + Ing_FK_ID + " and Ing_Type=2 and is_Deleted=1 order by Ing_PK_FileID desc";
            list = this.GetQueryM<WeChatFileM>(sql);
            return list;//取得全部的model
        }
        //public WeChatConfigM GetWeixinConfig(int storeid)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        WeChatConfigM model = new WeChatConfigM();
        //        doc.Load(@AppDomain.CurrentDomain.BaseDirectory+"WeChatConfig.xml");
        //        XmlNode xn = doc.SelectSingleNode("WeiXinConfig");
        //        XmlNodeList xnl = xn.ChildNodes;
        //        foreach(XmlNode m in xnl)
        //        {
        //            XmlElement xe = (XmlElement)m;
        //            int id = xe.FirstChild.InnerXml.ToInt() ;
        //            if (id == storeid)
        //            {
        //                XmlNodeList list = xe.ChildNodes;
        //                foreach (XmlNode m1 in list)
        //                {
        //                    if (m1.Name == "ID")
        //                    {
        //                        model.ID = m1.InnerXml.ToInt();
        //                    }
        //                    if (m1.Name == "Name")
        //                    {
        //                        model.Name = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "Token")
        //                    {
        //                        model.Token = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "EncodingAESKey")
        //                    {
        //                        model.EncodingAESKey = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "AppID")
        //                    {
        //                        model.AppID = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "AppSecret")
        //                    {
        //                        model.AppSecret = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "PartnerKey")
        //                    {
        //                        model.PartnerKey = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "mch_id")
        //                    {
        //                        model.mch_id = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "device_info")
        //                    {
        //                        model.device_info = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "spbill_create_ip")
        //                    {
        //                        model.spbill_create_ip = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "OauthScope")
        //                    {
        //                        model.OauthScope = m1.InnerXml;
        //                    }
        //                    if (m1.Name == "OpenJSSDK")
        //                    {
        //                        model.OpenJSSDK = m1.InnerXml.ToInt();
        //                    }
        //                    if (m1.Name == "SMSURL")
        //                    {
        //                        model.SMSURL = m1.InnerXml;
        //                    }
        //                    if(m1.Name== "HourStart")
        //                    {
        //                        model.HourStart= m1.InnerXml.ToInt();
        //                    }
        //                    if (m1.Name == "HourEnd")
        //                    {
        //                        model.HourEnd = m1.InnerXml.ToInt();
        //                    }
        //                    if (m1.Name == "StoreUrl")
        //                    {
        //                        model.StoreUrl = m1.InnerXml;
        //                    }
        //                }
        //                break;
        //            }
        //        }
        //        return model;
        //    }
        //    catch(Exception ex)
        //    {
        //        LogHelper.LogInfo(ex.Message);
        //        return null;
        //    }
        //}
    }
}
