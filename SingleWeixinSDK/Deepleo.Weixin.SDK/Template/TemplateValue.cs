using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Deepleo.Weixin.SDK.Template
{
    /// <summary>
    /// 模板消息值
    /// </summary>
    public class TemplateValue
    {
        /// <summary>
        /// 这个用来对应模板消息内容   1:绑定成功通知  2:订单提交成功   3:取消订单提醒
        /// </summary>
        public int LylOrderID { get; set; }

        /// <summary>
        /// 以逗号分隔的openid
        /// </summary>
        public string LylOpenID { get; set; }


        /// <summary>
        /// 点击详情跳转的地址
        /// </summary>
        public string LylUrl { get; set; }


        /// <summary>
        /// accessToken
        /// </summary>
        public string LylaccessToken { get; set; }



        #region  下面都是要替换的变量参数

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
        /// remark
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// orderID
        /// </summary>
        public string orderID { get; set; }

        /// <summary>
        /// orderMoneySum
        /// </summary>
        public string orderMoneySum { get; set; }

        /// <summary>
        /// backupFieldName
        /// </summary>
        public string backupFieldName { get; set; }

        /// <summary>
        /// backupFieldData
        /// </summary>
        public string backupFieldData { get; set; }


        /// <summary>
        /// hotelName
        /// </summary>
        public string hotelName { get; set; }

        /// <summary>
        /// pay
        /// </summary>
        public string pay { get; set; }

        /// <summary>
        /// arriveDate
        /// </summary>
        public string arriveDate { get; set; }

        /// <summary>
        /// departureDate
        /// </summary>
        public string departureDate { get; set; }

        #endregion
    }
}
