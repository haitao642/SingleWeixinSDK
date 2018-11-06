using Model;
using Public;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StoreInfoD : BaseTable
    {
        public StoreInfoD()
            : base("T_Store_Info", "Ing_StoreID")
        { }


        /// <summary>
        /// 根据城市获取门店
        /// </summary>
        /// <param name="strcity"></param>
        /// <returns></returns>
        public List<StoreM> GetStoreListbycity(string strcity)
        {
            List<StoreM> list = new List<StoreM>();
            string strSql = @"SELECT b.Ing_StoreID,b.str_StoreName,b.str_StoreFullName,b.str_district,b.Ing_Park,b.Ing_wifi,b.str_Address,
                        (select MIN(vipprice) from (
                        select  dbo.mfn_GetRoomRate_ByRate(min(a.Ing_StoreID),GETDATE(),a.str_FK_Type,dbo.mfn_WAP_GetStoreWebRateID(min(a.Ing_StoreID))) vipprice from T_Room_Num a WHERE a.Ing_StoreID=b.Ing_StoreID  GROUP by a.str_FK_Type)t) as VipPrice
                         from T_Store_Info b WHERE b.str_city=@strcity AND b.Ing_State=1";
            this.Sqlca.AddParameter("@strcity", strcity);
            list = this.GetQueryM<StoreM>(strSql);
            this.Sqlca.ClearParameter();


            return list;
        }



        /// <summary>
        /// 根据城市获取钟点房预订的门店
        /// </summary>
        /// <param name="strcity"></param>
        /// <returns></returns>
        public List<StoreM> GetStoreListHourbycity(string strcity)
        {
            List<StoreM> list = new List<StoreM>();
            string strSql = @"SELECT b.Ing_StoreID,b.str_StoreName,b.str_StoreFullName,b.str_district,b.Ing_Park,b.Ing_wifi,b.str_Address,
                        (SELECT MIN(ISNULL(a1.dec_StepRate,0)) FROM dbo.T_TimeRoomRule a1 
                              INNER JOIN dbo.T_Room_Type b1
                              ON a1.str_RoomType=b1.str_TypeCode AND CHARINDEX(','+LTRIM(RTRIM(STR(ISNULL(b1.Ing_StoreID,0))))+',',','+ISNULL(a1.Str_StoreIDArea,'')+',')>0
                              WHERE ISNULL(b1.Ing_ShowInHourWechat,0)=1 AND ISNULL(a1.str_Remark,'')='wechat'
                              AND ISNULL(a1.Ing_Sta,0)=1 and b1.Ing_StoreID=b.Ing_StoreID) as VipPrice
                         from T_Store_Info b WHERE b.str_city=@strcity AND b.Ing_State=1";
            this.Sqlca.AddParameter("@strcity", strcity);
            list = this.GetQueryM<StoreM>(strSql);
            this.Sqlca.ClearParameter();

            list = list.Where(x => x.VipPrice > 0).ToList();
            return list;
        }

        /// <summary>
        /// 获取单个门店信息
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public StoreM GetStore(int Ing_StoreID)
        {
            string strSql = @"SELECT b.Ing_StoreID,b.str_StoreName,b.str_StoreFullName,b.str_district,b.Ing_Park,b.Ing_wifi,b.Ing_Restaurant,b.str_Address,b.str_city,b.str_hotTel,b.str_LockStoreNo,b.Ing_SmsNumber,b.str_port_x,b.str_port_y FROM dbo.T_Store_Info b 
                                    WHERE b.Ing_StoreID={0} AND
                                     b.Ing_State=1";
            strSql = string.Format(strSql, Ing_StoreID);

            return this.GetQueryM<StoreM>(strSql).FirstOrDefault();
        }
        /// <summary>
        /// 获取单个门店的酒店头像图片
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public String GetStoreHeaderImg(int Ing_StoreID)
        {
            String url = "";
            String dir = AppDomain.CurrentDomain.BaseDirectory + "/Images/CompanyImg/" + Ing_StoreID+".jpg";
            if (File.Exists(dir))
            {
                return "/Images/CompanyImg/" + Ing_StoreID + ".jpg";
            }else
            {
                return "/Images/CompanyImg/" + "default.jpg";
            }
        }
        /// <summary>
        /// 获取单个门店的酒店信息图片
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <returns></returns>
        public List<StoreImgM> GetStoreImg(int Ing_StoreID)
        {
            List<StoreImgM> list = new List<StoreImgM>();
            String dir = AppDomain.CurrentDomain.BaseDirectory + "/Images/StoreImg/" + Ing_StoreID;
            int index = 0;
            List<String> pic = new List<string>();

            try
            {
                pic = Directory.GetFiles(dir).Where(x => x.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) | x.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) | x.EndsWith(".png", StringComparison.OrdinalIgnoreCase)).ToList();
            }
            catch (Exception ex)
            {
                pic = new List<string>();
            }
            foreach (String path in pic)
            {
                index++;
                StoreImgM model = new StoreImgM();
                model.Ing_StoreID = Ing_StoreID;
                model.str_DLPath = "/Images/StoreImg/" + Ing_StoreID + "/" + Path.GetFileName(path); //只获取文件名image.jpgpath;
                model.order = index;
                list.Add(model);
            }

            if (list.Count == 0)
            {
                index++;
                StoreImgM model = new StoreImgM();
                model.Ing_StoreID = Ing_StoreID;
                model.str_DLPath = "/Images/StoreImg/noImg/noImg.jpg";
                model.order = index;
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 获取城市列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetCityList()
        {
            ///所有门店
            List<StoreInfoM> list = GetAllM<StoreInfoM>();
            list = list.Where(x => (x.Ing_State.HasValue && x.Ing_State.Value == 1)).ToList();

            List<string> str = new List<string>();
            foreach (StoreInfoM m in list)
            {
                if (string.IsNullOrEmpty(m.str_city)) { continue; }
                if (str.Contains(m.str_city.Trim())) { continue; }
                str.Add(m.str_city.Trim());
            }
            return str;
        }

        /// <summary>
        /// 获取有效的酒店
        /// </summary>
        /// <returns></returns>
        public List<HotelSimpleM> GetHotelSimpleList()
        {
            string strSql = @"select * from t_store_info where ing_state=1";
            return this.GetQueryM<HotelSimpleM>(strSql);
        }
        /// <summary>
        /// 根据酒店id和服务器类型获取总后端id
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public OutStoreInfoM ConvertStoreID(RequestParamModel param)
        {
            String url = ConfigValue.TotalServerUrl + "GetStoreInfoMessage";
            string json = ByteUtil.ObjectToJson(param);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            //声明一个HttpWebRequest请求 
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json;chaset=utf-8";

            //设置连接超时时间
            request.Timeout = 90000;

            Stream reqstream = request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream streamReceive = response.GetResponseStream();
            Encoding encoding = Encoding.UTF8;
            StreamReader streamReader = new StreamReader(streamReceive, encoding);
            string result = streamReader.ReadToEnd();
            OutStoreInfoM model = ByteUtil.JsonToObject<OutStoreInfoM>(result);
            return model;
        }
    }
}
