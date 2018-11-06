using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 微信基类
    /// </summary>
    public class WeChatBaseM
    {
        /// <summary>
        /// openid
        /// </summary>
        public string Openid { get; set; }
        /// <summary>
        /// storeid
        /// </summary>
        public string  token { get; set; }

        public int storeid { get; set; }
       
    }


    /// <summary>
    ///修改房价：  modelID:  mQ2Cb_P442y3slrZruW-oYKlolcK9aKIdzLHUTanF5o
    /// </summary>
    public class WeChatChangePriceM:WeChatBaseM
    {
        /// <summary>
        /// first
        /// </summary>
        public string first { get; set; }

        /// <summary>
        /// keyword1
        /// </summary>
        public string keyword1 { get; set; }


        /// <summary>
        /// keyword2
        /// </summary>
        public string keyword2 { get; set; }


        /// <summary>
        /// keyword3
        /// </summary>
        public string keyword3 { get; set; }


        /// <summary>
        /// RoomNo
        /// </summary>
        public string RoomNo { get; set; }

        /// <summary>
        /// 旧的价格
        /// </summary>
        public decimal? dec_OldActualRate { get; set; }

        /// <summary>
        /// 新的价格
        /// </summary>
        public decimal? dec_NewActualRate { get; set; }
    }


    /// <summary>
    ///公安上传报错：  modelID:  mQ2Cb_P442y3slrZruW-oYKlolcK9aKIdzLHUTanF5o
    /// </summary>
    public class WeChatPoliceErrM : WeChatBaseM
    {
        /// <summary>
        /// first
        /// </summary>
        public string first { get; set; }

        /// <summary>
        /// keyword1
        /// </summary>
        public string keyword1 { get; set; }


        /// <summary>
        /// keyword2
        /// </summary>
        public string keyword2 { get; set; }


        /// <summary>
        /// keyword3
        /// </summary>
        public string keyword3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }


    /// <summary>
    ///修改账务通知报错：  modelID:  mQ2Cb_P442y3slrZruW-oYKlolcK9aKIdzLHUTanF5o
    /// </summary>
    public class WeChatUpdateAccErrM : WeChatBaseM
    {
        /// <summary>
        /// first
        /// </summary>
        public string first { get; set; }

        /// <summary>
        /// keyword1
        /// </summary>
        public string keyword1 { get; set; }


        /// <summary>
        /// keyword2
        /// </summary>
        public string keyword2 { get; set; }


        /// <summary>
        /// keyword3
        /// </summary>
        public string keyword3 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 门店号
        /// </summary>
        public string storeno { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string storename { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        public int StoreID { get; set; }
    }

    /// <summary>
    /// 绑定成功的微信推送
    /// </summary>
    public class BindSuccessM : WeChatUpdateAccErrM
    { }


    /// <summary>
    /// 支付房费成功   modelID:sAaB5U3-Hez9Fk1NyN0arKqFolOEZ517DWvhmA9UcQE
    /// </summary>
    public class WeChatPaySuccessM : WeChatBaseM
    {
        /// <summary>
        /// 主单id
        /// </summary>
        public int masterid { get; set; }

        /// <summary>
        /// first
        /// </summary>
        public string first { get; set; }


        /// <summary>
        /// folioId
        /// </summary>
        public string folioId { get; set; }


        /// <summary>
        /// roomRate
        /// </summary>
        public string roomRate { get; set; }


        /// <summary>
        /// remark
        /// </summary>
        public string remark { get; set; }
    }

    /// <summary>
    /// 预订成功
    /// 
    /// </summary>
    public class WeChatOrderSuccessM : WeChatBaseM
    {
//        {{first.DATA}}

//订单号：{{order.DATA}}
//入住人：{{Name.DATA}}
//入住日期：{{datein.DATA}}
//离店日期：{{dateout.DATA}}
//房间数量：{{number.DATA}}
//房型名称：{{room type.DATA}}
//订单总价：{{pay.DATA}}
//{{remark.DATA}}

        /// <summary>
        /// first
        /// </summary>
        public string first { get; set; }


        /// <summary>
        /// order
        /// </summary>
        public string order { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// datein
        /// </summary>
        public string datein { get; set; }

        /// <summary>
        /// dateout
        /// </summary>
        public string dateout { get; set; }


        /// <summary>
        /// number
        /// </summary>
        public string number { get; set; }


        /// <summary>
        /// room type
        /// </summary>
        public string roomtype { get; set; }

        /// <summary>
        /// pay
        /// </summary>
        public string pay { get; set; }


        /// <summary>
        /// remark
        /// </summary>
        public string remark { get; set; }
    }

    /// <summary>
    /// 取消订单
    /// </summary>
    public class WeChatCancelOrderM : WeChatBaseM
    {
//        {{first.DATA}}

//您已成功取消订单
//分店：{{hotelName.DATA}}
//价格：{{pay.DATA}}
//入住日期：{{arriveDate.DATA}}
//离店日期：{{departureDate.DATA}}
//{{remark.DATA}}
        /// <summary>
        /// 
        /// </summary>
        public string first { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hotelName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pay { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string arriveDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string departureDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
    }


//    问题咨询处理进度提醒

//{{serviceInfo.DATA}}
//服务类型：{{serviceType.DATA}}
//处理状态：{{serviceStatus.DATA}}
//提交时间：{{time.DATA}}
    //{{remark.DATA}}    VVGZDsyLuIyNaXvsKoU5mB2lbNVF80dtxQtNFWHmiso
    /// <summary>
    /// 问题咨询处理进度提醒
    /// </summary>
    public class WeChatQuestionM : WeChatBaseM
    {
        /// <summary>
        /// serviceInfo
        /// </summary>
        public string serviceInfo { get; set; }

        /// <summary>
        /// serviceType
        /// </summary>
        public string serviceType { get; set; }

        /// <summary>
        /// serviceStatus
        /// </summary>
        public string serviceStatus { get; set; }

        /// <summary>
        /// time
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// remark
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// StoreID
        /// </summary>
        public int StoreID { get; set; }

        /// <summary>
        /// CommentID
        /// </summary>
        public int CommentID { get; set; }
    }



    /// <summary>
    /// 会员储值
    /// {{first.DATA}}
///客户主体ID：{{keyword1.DATA}}
///交易类型：{{keyword2.DATA}}
///变动金额：{{keyword3.DATA}}
///储值余额：{{keyword4.DATA}}
///支付流水号：{{keyword5.DATA}}
///{{remark.DATA}}
    /// </summary>
    public class WeChatChargeMon : WeChatBaseM
    {
        /// <summary>
        /// first
        /// </summary>
        public string first { get; set; }

        /// <summary>
        /// keyword1
        /// </summary>
        public string keyword1 { get; set; }


        /// <summary>
        /// keyword2
        /// </summary>
        public string keyword2 { get; set; }


        /// <summary>
        /// keyword3
        /// </summary>
        public string keyword3 { get; set; }

        /// <summary>
        /// keyword4
        /// </summary>
        public string keyword4 { get; set; }

        /// <summary>
        /// keyword5
        /// </summary>
        public string keyword5 { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        public int Ing_StoreID { get; set; }
    }
}
