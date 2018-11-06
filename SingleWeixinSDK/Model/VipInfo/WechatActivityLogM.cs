using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   /// <summary>
   /// 参与记录
   /// </summary>
   public class WechatActivityLogM
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Ing_PKID { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Ing_Type { get; set; }

       /// <summary>
       /// 活动类型
       /// </summary>
        public string str_Type 
        {
            get 
            {
                switch (Ing_Type) 
                {
                    case 0:
                        return "中秋节活动";
                    case 1:
                        return "国庆节活动";
                    default:
                        return "";
                }
            
            }
          
        }

        /// <summary>
        /// 微信openid
        /// </summary>
        public string str_Openid { get; set; }
        
        /// <summary>
        /// 礼包id
        /// </summary>
        public int Ing_VipPackageId { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string str_Remark { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? dt_Create { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string str_Creator { get; set; }

    }
}
