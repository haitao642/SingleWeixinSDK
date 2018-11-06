using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 发送短信，所用到的类
    /// </summary>
    public class SMSSendM
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 短信类型
        /// </summary>
        public string SMSType { get; set; }


        /// <summary>
        /// 短信内容
        /// </summary>
        public string SMSContent { get; set; }


        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 发送人
        /// </summary>
        public string Sendman { get; set; }
        /// <summary>
        /// 发送结果
        /// </summary>
        public string rev { get; set; }
    }


    #region 门店的一些信息
    /// <summary>
    /// 门店的一些信息
    /// </summary>
    public class ParaForStoreM
    {
        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }


        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string PhnNo { get; set; }


    }
    #endregion

    #region 400预订发送的短信
    /// <summary>
    /// 400预订发送的短信
    /// </summary>
    public class ParaForR400M
    {
        /// <summary>
        /// 来期
        /// </summary>
        public string ArrDate { get; set; }

        /// <summary>
        /// 离期
        /// </summary>
        public string DepDate { get; set; }

        /// <summary>
        /// 房数
        /// </summary>
        public string RoomNum { get; set; }

        /// <summary>
        /// 房型
        /// </summary>
        public string RoomType { get; set; }

        /// <summary>
        /// 扣留时间
        /// </summary>
        public string ResDep { get; set; }


    }

    #endregion


#region 发送验证码
    /// <summary>
    /// 绑定的时候，发送验证码
    /// </summary>
    public class WechatBindM
    {
        /// <summary>
        /// 验证码
        /// </summary>
        public string yzcode { get; set; }
    }

#endregion
}
