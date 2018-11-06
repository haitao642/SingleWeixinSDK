using Model;
using Model.RoomCenter;
using Public;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomTypeD:BaseTable
    {
        public RoomTypeD()
            : base("T_Room_Type", "Ing_Pk_RoomTypeID")
        { }

        /// <summary>
        /// 获取有效房房型
        /// </summary>
        /// <returns></returns>
        public List<RoomTypeM> GetUseFulList(int Ing_StoreID)
        {
            string strSql = @"SELECT * FROM T_Room_Type a where a.Ing_StoreID={0} AND ISNULL(a.Ing_halt,0)=1";
            strSql = string.Format(strSql, Ing_StoreID);

            return this.GetQueryM<RoomTypeM>(strSql);
        }

        /// <summary>
        /// 获取房型和价格
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="dtarr"></param>
        /// <returns></returns>
        public List<RoomType1M> GetUseFulList(int Ing_StoreID,DateTime dtarr)
        {
            string strSql = @"SELECT a.Ing_Pk_RoomTypeID,a.str_TypeCode AS strRoomTypeCode,a.str_TypeName AS strRoomTypeName,a.dec_FirstLivePrice,
                                    a.str_Area,a.str_Bed_w,a.str_BedType,a.Ing_window,a.str_CurrentFloor,a.str_NumberGuest,a.str_Remark,
                                    dbo.mfn_GetRoomRate_ByRate(a.Ing_StoreID, '{1}', a.str_TypeCode, '') AS price0,
                                    dbo.mfn_GetRoomRate_ByRate(a.Ing_StoreID, '{1}', a.str_TypeCode, b.str_RateID1) AS price1,
                                    dbo.mfn_GetRoomRate_ByRate(a.Ing_StoreID, '{1}', a.str_TypeCode, b.str_RateID2) AS price2,
                                    dbo.mfn_GetRoomRate_ByRate(a.Ing_StoreID, '{1}', a.str_TypeCode, b.str_RateID3) AS price3,
                                    dbo.mfn_GetRoomRate_ByRate(a.Ing_StoreID, '{1}', a.str_TypeCode, b.str_RateID4) AS price4
                                     FROM dbo.T_Room_Type a LEFT JOIN dbo.T_StoreWebRate b ON a.Ing_StoreID=b.Ing_StoreID
                                    WHERE a.Ing_StoreID={0} AND ISNULL(a.Ing_halt,0)=1";
            strSql = string.Format(strSql, Ing_StoreID,dtarr.ToString("yyyy-MM-dd"));

            return this.GetQueryM<RoomType1M>(strSql);
        }
        /// <summary>
        /// 获取房型图片
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="strRoomTypeCode"></param>
        /// <returns></returns>
        public List<StoreImgM> GetRoomTypeImg(int Ing_StoreID, string strRoomTypeCode)
        {
            List<StoreImgM> list = new List<StoreImgM>();
            String dir = AppDomain.CurrentDomain.BaseDirectory + "/Images/RoomImg/" + Ing_StoreID+"/"+ strRoomTypeCode;
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
                model.str_DLPath = "/Images/RoomImg/" + Ing_StoreID + "/"+ strRoomTypeCode + "/" + Path.GetFileName(path); //只获取文件名image.jpgpath;
                model.order = index;
                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 获取钟点房型和价格
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="dtarr"></param>
        /// <returns></returns>
        public List<RoomType1M> GetUseFulHourList(int Ing_StoreID, DateTime dtarr)
        {
            //string strSql = @"SELECT a.Ing_Pk_RoomTypeID,a.str_TypeCode AS strRoomTypeCode,a.str_TypeName AS strRoomTypeName
            //                                ,MIN(ISNULL(b.dec_StepRate,0)) AS  price0
            //                                ,(SELECT COUNT(0) FROM dbo.T_Room_Num c1 WHERE c1.Ing_StoreID={0} AND c1.str_FK_Type=a.str_TypeCode) roomnum
            //                                FROM dbo.T_Room_Type a 
            //                                LEFT JOIN dbo.T_TimeRoomRule b ON b.str_RoomType=a.str_TypeCode 
            //                                    AND CHARINDEX(','+LTRIM(RTRIM(STR(ISNULL(a.Ing_StoreID,0))))+',',','+ISNULL(b.Str_StoreIDArea,'')+',')>0
            //                                    AND ISNULL(b.str_Remark,'')='wechat' AND ISNULL(b.Ing_Sta,0)=1
            //                        WHERE ISNULL(a.Ing_ShowInHourWechat,0)=1 AND ISNULL(a.Ing_halt,0)=1 AND a.Ing_StoreID={0}
            //                        GROUP BY a.Ing_Pk_RoomTypeID,a.str_TypeCode,a.str_TypeName";
            string strSql = @"SELECT a.Ing_Pk_RoomTypeID,a.str_TypeCode AS strRoomTypeCode,a.str_TypeName AS strRoomTypeName
                                            ,a.str_Area,a.str_Bed_w,a.str_BedType,a.Ing_window,a.str_CurrentFloor,a.str_NumberGuest,a.str_Remark
                                            ,MIN(ISNULL(b.dec_StepRate,0)) AS  price0
                                            ,(SELECT COUNT(0) FROM dbo.T_Room_Num c1 WHERE c1.Ing_StoreID={0} AND c1.str_FK_Type=a.str_TypeCode) roomnum
                                            FROM dbo.T_Room_Type a 
                                            LEFT JOIN dbo.T_TimeRoomRule b ON b.str_RoomType=a.str_TypeCode 
                                                AND ISNULL(b.str_Remark,'')='wechat' AND ISNULL(b.Ing_Sta,0)=1
                                    WHERE ISNULL(a.Ing_ShowInHourWechat,0)=1 AND ISNULL(a.Ing_halt,0)=1 AND a.Ing_StoreID={0}
                                    GROUP BY a.Ing_Pk_RoomTypeID,a.str_TypeCode,a.str_TypeName,a.str_Area,a.str_Bed_w,a.str_BedType,a.Ing_window,a.str_CurrentFloor,a.str_NumberGuest,a.str_Remark";
            strSql = string.Format(strSql, Ing_StoreID);
            return this.GetQueryM<RoomType1M>(strSql);
        }

        /// <summary>
        /// 根据门店和房型找记录
        /// </summary>
        /// <param name="Ing_StoreID"></param>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public RoomTypeM GetRoomType(int Ing_StoreID, string typecode)
        {
            string strSql = "SELECT * FROM dbo.T_Room_Type a WHERE a.Ing_StoreID=@Ing_StoreID AND a.str_TypeCode=@typecode";
            this.Sqlca.AddParameter("@Ing_StoreID",Ing_StoreID);
            this.Sqlca.AddParameter("@typecode", typecode);

            RoomTypeM model = new RoomTypeM();
            model = this.GetQueryM<RoomTypeM>(strSql).FirstOrDefault();
            this.Sqlca.ClearParameter();
            return model;
        }

    }
}
