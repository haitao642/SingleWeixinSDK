using Model.SmartControl;
using Newtonsoft.Json.Linq;
using Public;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SmartControl
{
    public class SmartControlD
    {
        /// <summary>
        /// 获取网关列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public GateWayResponseM getGateWayList(GateWayRequestM model)
        {

            GateWayResponseM result = new GateWayResponseM();
            String url = ConfigValue.SmartControlServerUrl + "hotelapp/hotel/room/gateway/list?" + model.ToString();
            LogSmartHelper.LogInfo("调用获取网关列表接口,请求路径:" + url + ",请求参数:" + ByteUtil.ObjectToJson(model));
            SmartControlLogM logM = new SmartControlLogM();
            logM.dt_CreateTime = DateTime.Now;
            logM.Ing_CustID = model.Ing_CustID;
            logM.Ing_MasterID = model.Ing_MasterID;
            logM.str_CustName = model.str_CustName;
            logM.str_HotelID = model.hotelid.ToString();
            logM.str_OpenID = model.str_OpenID;
            logM.str_RequestName = "获取网关列表";
            logM.str_RequestParam = ByteUtil.ObjectToJson(model);
            logM.str_RequestUrl = url;
            logM.str_RoomNo = model.room;
            try
            {
                //声明一个HttpWebRequest请求 
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Method = "POST";
                //request.ContentType = "application/json;chaset=utf-8";

                //设置连接超时时间
                //request.Timeout = 90000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string repResult = streamReader.ReadToEnd();
                logM.str_Response = repResult;
                LogSmartHelper.LogInfo("调用获取网关列表接口返回值:" + repResult);
                result = ByteUtil.JsonToObject<GateWayResponseM>(repResult);
                logM.str_ResultName = result.msg;
                logM.str_ResultCode = result.code;
            }
            catch (Exception ex)
            {
                logM.str_ResultName = "失败";
                logM.str_ResultCode = "0";
                LogSmartHelper.LogInfo("调用获取网关列表接口异常:" + ex.Message);
            }
            SmartControlLogD logd = new SmartControlLogD();
            string logresult = logd.save(logM);
            if (logresult.Equals("success"))
            {
                LogSmartHelper.LogInfo("保存获取网关列表接口日志成功");
            }
            else
            {
                LogSmartHelper.LogInfo("保存获取网关列表接口日志失败:" + logresult);
            }
            return result;
        }
        /// <summary>
        /// 获取遥控器列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DeviceResponseM getDeviceList(DeviceRequestM model)
        {
            DeviceResponseM result = new DeviceResponseM();
            String url = ConfigValue.SmartControlServerUrl + "app/hotelapp/device/list?" + model.ToString();
            LogSmartHelper.LogInfo("调用获取遥控器列表接口,请求路径:" + url + ",请求参数:" + ByteUtil.ObjectToJson(model));
            SmartControlLogM logM = new SmartControlLogM();
            logM.dt_CreateTime = DateTime.Now;
            logM.Ing_CustID = model.Ing_CustID;
            logM.Ing_MasterID = model.Ing_MasterID;
            logM.str_CustName = model.str_CustName;
            logM.str_GatewayID = model.gatewayid;
            logM.str_HotelID = model.hotelid;
            logM.str_OpenID = model.str_OpenID;
            logM.str_RequestName = "获取遥控器列表";
            logM.str_RequestParam = ByteUtil.ObjectToJson(model);
            logM.str_RequestUrl = url;
            logM.str_RoomNo = model.room;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string repResult = streamReader.ReadToEnd();
                logM.str_Response = repResult;
                LogSmartHelper.LogInfo("调用获取遥控器列表接口返回值:" + repResult);
                result = ByteUtil.JsonToObject<DeviceResponseM>(repResult);
                logM.str_ResultName = result.msg;
                logM.str_ResultCode = result.code;
            }
            catch (Exception ex)
            {
                logM.str_ResultName = "失败";
                logM.str_ResultCode = "0";
                LogSmartHelper.LogInfo("调用获取遥控器列表接口返回值异常:" + ex.Message);
            }
            SmartControlLogD logd = new SmartControlLogD();
            string logresult = logd.save(logM);
            if (logresult.Equals("success"))
            {
                LogSmartHelper.LogInfo("保存获取遥控器列表接口日志成功");
            }
            else
            {
                LogSmartHelper.LogInfo("保存获取遥控器列表接口日志失败:" + logresult);
            }
            return result;
        }
        /// <summary>
        /// 控制某一个网关的遥控器
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ControlResponseM controlDevice(ControlRequestM model)
        {
            ControlResponseM result = new ControlResponseM();
            String url = ConfigValue.SmartControlServerUrl + "app/hotelapp/device/do?" + model.ToString();
            LogSmartHelper.LogInfo("调用控制网关遥控器接口,请求路径:" + url + ",请求参数:" + ByteUtil.ObjectToJson(model));
            SmartControlLogM logM = new SmartControlLogM();
            logM.dt_CreateTime = DateTime.Now;
            logM.Ing_CustID = model.Ing_CustID;
            logM.Ing_MasterID = model.Ing_MasterID;
            logM.str_ContollerID = model.contollerid.ToString();
            logM.str_CustName = model.str_CustName;
            logM.str_GatewayID = model.gatewayid;
            logM.str_HotelID = model.hotelid.ToString();
            logM.Ing_KeyID = model.keyid;
            logM.str_NickName = model.nickname;
            logM.str_OpenID = model.str_OpenID;
            logM.str_RequestName = "控制网关遥控器";
            logM.str_RequestParam = ByteUtil.ObjectToJson(model);
            logM.str_RequestUrl = url;
            logM.str_RoomNo = model.str_RoomNo;
            logM.str_Type = model.type.ToString();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string repResult = streamReader.ReadToEnd();
                logM.str_Response = repResult;
                LogSmartHelper.LogInfo("调用控制网关遥控器接口返回值:" + repResult);
                result = ByteUtil.JsonToObject<ControlResponseM>(repResult);
                logM.str_ResultName = result.msg;
                logM.str_ResultCode = result.code;
            }
            catch (Exception ex)
            {
                logM.str_ResultName = "失败";
                logM.str_ResultCode = "0";
                LogSmartHelper.LogInfo("调用控制网关遥控器接口返回值异常:" + ex.Message);
            }
            SmartControlLogD logd = new SmartControlLogD();
            string logresult = logd.save(logM);
            if (logresult.Equals("success"))
            {
                LogSmartHelper.LogInfo("保存控制网关遥控器接口日志成功");
            }
            else
            {
                LogSmartHelper.LogInfo("保存控制网关遥控器接口日志失败:" + logresult);
            }
            return result;
        }
        /// <summary>
        ///  获取空调设备状态
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public AirStatusResponseM airStatus(AirStatusRequestM model)
        {
            AirStatusResponseM result = new AirStatusResponseM();
            String url = ConfigValue.SmartControlServerUrl + "app/hotelapp/device/status?param=" + model.param;
            LogSmartHelper.LogInfo("调用获取空调设备状态接口,请求路径:" + url + ",请求参数:" + ByteUtil.ObjectToJson(model));
            SmartControlLogM logM = new SmartControlLogM();
            logM.dt_CreateTime = DateTime.Now;
            logM.Ing_CustID = model.Ing_CustID;
            logM.Ing_MasterID = model.Ing_MasterID;
            logM.str_ContollerID = model.contollerid.ToString();
            logM.str_CustName = model.str_CustName;
            logM.str_GatewayID = model.gatewayid;
            logM.str_HotelID = model.hotelid.ToString();
            logM.str_NickName = model.nickname;
            logM.str_OpenID = model.str_OpenID;
            logM.str_RequestName = "获取空调设备状态";
            logM.str_RequestParam = ByteUtil.ObjectToJson(model);
            logM.str_RequestUrl = url;
            logM.str_RoomNo = model.str_RoomNo;
            logM.str_Type = model.type.ToString();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string repResult = streamReader.ReadToEnd();
                logM.str_Response = repResult;
                LogSmartHelper.LogInfo("调用获取空调设备状态接口返回值:" + repResult);
                result = ByteUtil.JsonToObject<AirStatusResponseM>(repResult);
                logM.str_ResultName = result.msg;
                logM.str_ResultCode = result.code;
            }
            catch (Exception ex)
            {
                logM.str_ResultName = "失败";
                logM.str_ResultCode = "0";
                LogSmartHelper.LogInfo("调用获取空调设备状态接口异常:" + ex.Message);
            }
            SmartControlLogD logd = new SmartControlLogD();
            string logresult = logd.save(logM);
            if (logresult.Equals("success"))
            {
                LogSmartHelper.LogInfo("保存获取空调设备状态接口日志成功");
            }
            else
            {
                LogSmartHelper.LogInfo("保存获取空调设备状态接口日志失败:" + logresult);
            }
            return result;
        }
        /// <summary>
        /// 获取设备可支持按键
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public SupportKeyM getSupportKey(SupportRequestM model)
        {
            SupportResponseM result = new SupportResponseM();
            SupportKeyM supportkey = new SupportKeyM();
            KeyLabel7M keylabe7m = new KeyLabel7M();
            String url = ConfigValue.SmartControlServerUrl + "app/hotelapp/device/one/keys?" + model.ToString();
            LogSmartHelper.LogInfo("调用获取设备可支持按键接口,请求路径:" + url + ",请求参数:" + ByteUtil.ObjectToJson(model));
            SmartControlLogM logM = new SmartControlLogM();
            logM.dt_CreateTime = DateTime.Now;
            logM.Ing_CustID = model.Ing_CustID;
            logM.Ing_MasterID = model.Ing_MasterID;
            logM.str_ContollerID = model.controllerid;
            logM.str_CustName = model.str_CustName;
            logM.str_GatewayID = model.gatewayid;
            logM.str_HotelID = model.hotelid;
            logM.str_NickName = model.str_NickName;
            logM.str_OpenID = model.str_OpenID;
            logM.str_RequestName = "获取设备可支持按键";
            logM.str_RequestParam = ByteUtil.ObjectToJson(model);
            logM.str_RequestUrl = url;
            logM.str_RoomNo = model.str_RoomNo;
            logM.str_Type = model.type.ToString();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string repResult = streamReader.ReadToEnd();
                LogSmartHelper.LogInfo("调用获取设备可支持按键接口返回值:" + repResult);
                logM.str_Response = repResult;
                JSONObjectS jobj = JSONConvertS.DeserializeObject(repResult);
                Object jinfo_o = new Object();
                Object jcode = new Object();
                Object jmsg = new Object();
                Object jac_o = new Object();
                Object jav_o = new Object();
                Object jac_keylabel7_o = new Object();
                Object jav_keylabel7_o = new Object();
                JSONObjectS jinfo = new JSONObjectS();
                JSONObjectS jac = new JSONObjectS();
                JSONObjectS jav = new JSONObjectS();
                JSONObjectS jac_keylabel7 = new JSONObjectS();
                JSONObjectS jav_keylabel7 = new JSONObjectS();
                jobj.TryGetValue("info", out jinfo_o);
                jinfo = (JSONObjectS)jinfo_o;
                jinfo.TryGetValue("AC", out jac_o);
                jinfo.TryGetValue("AV", out jav_o);
                
                
                
                if (model.type == 0)
                {
                    jav = (JSONObjectS)jav_o;
                    jav.TryGetValue("KeyLabel7", out jav_keylabel7_o);
                    jav_keylabel7 = (JSONObjectS)jav_keylabel7_o;
                    keylabe7m.KeyLabel7 = jav_keylabel7;
                }
                else
                {
                    jac = (JSONObjectS)jac_o;
                    jac.TryGetValue("KeyLabel7", out jac_keylabel7_o);
                    jac_keylabel7 = (JSONObjectS)jac_keylabel7_o;
                    keylabe7m.KeyLabel7 = jac_keylabel7;
                }
                supportkey.keylabel7 = keylabe7m;
                logM.str_ResultName = "操作成功";
                logM.str_ResultCode = "200";
            }
            catch (Exception ex)
            {
                logM.str_ResultName = "操作失败";
                logM.str_ResultCode = "0";
                LogSmartHelper.LogInfo("调用获取设备可支持按键接口异常:" + ex.Message);
            }
            SmartControlLogD logd = new SmartControlLogD();
            string logresult = logd.save(logM);
            if (logresult.Equals("success"))
            {
                LogSmartHelper.LogInfo("保存设备可支持按键接口日志成功");
            }
            else
            {
                LogSmartHelper.LogInfo("保存设备可支持按键接口日志失败:" + logresult);
            }
            //JObject jobj = JObject.Parse(repResult);
            //JObject jinfo=jobj.GetValue("info").ToObject<JObject>();
            //JObject jac= jinfo.GetValue("AC").ToObject<JObject>();
            //JObject jav = jinfo.GetValue("AV").ToObject<JObject>();
            //JToken jackeylabel7 = jac.GetValue("KeyLabel7");
            //acm.KeyLabel7 = JObjectExtensions.ToDictionary(jackeylabel7);
            //JToken javkeylabel7 = jav.GetValue("KeyLabel7");
            //avm.KeyLabel7 = JObjectExtensions.ToDictionary(javkeylabel7);
            //supportkey.AC = acm;
            //supportkey.AV = avm;
            return supportkey;
        }


        ///// <summary>
        ///// 获取单一设备的master key
        ///// </summary>
        ///// <param name="deviceid">设备类型</param>
        ///// <returns></returns>
        //public DeviceKeyResponse getDeviceKey(String deviceid)
        //{
        //    DeviceKeyResponse result = new DeviceKeyResponse();
        //    String url = ConfigValue.SmartControlServerUrl + "app/hotelapp/device/all/keys?deviceid="+deviceid;
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //    Stream streamReceive = response.GetResponseStream();
        //    Encoding encoding = Encoding.UTF8;
        //    StreamReader streamReader = new StreamReader(streamReceive, encoding);
        //    string repResult = streamReader.ReadToEnd();
        //    result = ByteUtil.JsonToObject<DeviceKeyResponse>(repResult);
        //    return result;
        //}
    }
}
