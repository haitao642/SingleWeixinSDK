using Model;
using Model.SmartControl;
using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SmartControl
{
    public class SmartControlB
    {
        public DAL.SmartControl.SmartControlD dal = new DAL.SmartControl.SmartControlD();
       // public DAL.CouponDetailsD coupondal = new DAL.CouponDetailsD();
        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GateWayResponseM getGateWayList(GateWayRequestM model)
        {
            return dal.getGateWayList(model);
        }
        /// <summary>
        /// 获取遥控器列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DeviceResponseM getDeviceList(DeviceRequestM model)
        {
            return dal.getDeviceList(model);
        }
        /// <summary>
        /// 获取在线网关的设备列表
        /// </summary>
        /// <param name="roomNo"></param>
        /// <param name="ing_Storeid"></param>
        /// <returns></returns>
        public List<DeviceM> getDeviceListByRoom(String roomNo,int ing_Storeid,int Ing_CustID,string str_CustName,string str_OpenID,int Ing_MasterID)
        {
            List<DeviceM> list = new List<DeviceM>();
            GateWayRequestM model1 = new GateWayRequestM();
            model1.start = 0;
            model1.pageCount = 50;
            model1.room = roomNo;
            model1.hotelid = ing_Storeid;
            model1.Ing_CustID = Ing_CustID;
            model1.str_CustName = str_CustName;
            model1.str_OpenID = str_OpenID;
            model1.Ing_MasterID = Ing_MasterID;
            GateWayResponseM responseM = getGateWayList(model1);
            if (responseM.info != null)
            {
               foreach(GateWayM gateway in responseM.info)
                {
                    if (gateway.online == 1)
                    {
                        DeviceRequestM model2 = new DeviceRequestM();
                        model2.hotelid = ing_Storeid.ToString();
                        model2.start = 0;
                        model2.pageCount = 50;
                        model2.gatewayid = gateway.gateway_id;
                        model2.room = roomNo;
                        model2.Ing_CustID = Ing_CustID;
                        model2.str_CustName = str_CustName;
                        model2.str_OpenID = str_OpenID;
                        model2.Ing_MasterID = Ing_MasterID;
                        DeviceResponseM responseM1 = getDeviceList(model2);
                        if (responseM1.info != null)
                        {
                            for(int i = 0; i < responseM1.info.Count; i++)
                            {
                                responseM1.info[i].gatewayid = gateway.gateway_id;
                                list.Add(responseM1.info[i]);
                            } 
                        }
                    }
                }
            }
            return list;
        }
        /// <summary>
        /// 控制某一个网关的遥控器
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ControlResponseM controlDevice(ControlRequestM model)
        {
            return dal.controlDevice(model);
        }
        /// <summary>
        /// 获取空调状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AirStatusResponseM airStatus(AirStatusRequestM model)
        {
            return dal.airStatus(model);
        }
        /// <summary>
        /// 获取设备可支持按键
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SupportKeyM getSupportKey(SupportRequestM model)
        {
            
                return dal.getSupportKey(model);
            
        }
        ///// <summary>
        ///// 获取单一设备的master key
        ///// </summary>
        ///// <param name="deviceid">控制器id</param>
        ///// <returns></returns>
        //public DeviceKeyResponse getDeviceKey(String deviceid)
        //{
        //    return dal.getDeviceKey(deviceid);
        //}
        /// <summary>
        /// 接口返回的result信息
        /// </summary>
        /// <param name="errorcode"></param>
        /// <returns></returns>
        public static String errorMsg(String errorcode)
        {
            if (errorcode.Equals("2000"))
            {
                return "没有权限操作";
            }else if (errorcode.Equals("2001"))
            {
                return "没有找到想要操作的资源即修改信息没有找到该信息";
            }else if (errorcode.Equals("2002"))
            {
                return "操作失败";
            }else if (errorcode.Equals("2003"))
            {
                return "操作成功";
            }else if (errorcode.Equals("4000"))
            {
                return "字段缺少";
            }else if (errorcode.Equals("4001"))
            {
                return "字段不在预期范围";
            }else
            {
                return "其他错误";
            }
        }
    }
}
