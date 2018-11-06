using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class WechatWalletViewM:BaseMyAccountM
    {
        public List<WechatWalletM> list { get; set; }
    }
    /// <summary>
    /// T_Wechat_Wallet
    /// </summary>
    public class WechatWalletM
    {
        ///<summary>
        ///Ing_PKID
        /// </summary>
        public int Ing_PKID {get;set;}

        ///<summary>
        ///会员卡id
        /// </summary>
        public int? Ing_Fk_VipcardId {get;set;}

        ///<summary>
        ///主单id
        /// </summary>
        public int? Ing_Fk_MasterId {get;set;}

        ///<summary>
        ///类型（0充值,1支付）
        /// </summary>
        public int Ing_Type {get;set;}

        /// <summary>
        /// 中文类型
        /// </summary>
        public string str_Type 
        {
            get 
            {
                if (Ing_Type == 0)
                {
                    return "微信支付--返回";
                }
                else 
                {
                    return "微信钱包支付";
                }
            }
        }

        ///<summary>
        ///价格
        /// </summary>
        public decimal? dec_Price {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_Create {get;set;}

        ///<summary>
        ///操作员
        /// </summary>
        public string str_Creator {get;set;}

        /// <summary>
        /// 备注
        /// </summary>
        public string str_Memo { get; set; }
    }
}