using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_ShareRecord
    /// </summary>
    public class ShareRecordM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_Pk_id {get;set;}

        ///<summary>
        ///分享者的会员卡ID
        /// </summary>
        public int Ing_VipCardID {get;set;}

        ///<summary>
        ///被推荐人的openid
        /// </summary>
        public string str_openid {get;set;}

        ///<summary>
        ///被推荐人的储值状态   0：还未储值   1：已经储值
        /// </summary>
        public int Ing_sta {get;set;}

        ///<summary>
        ///储值时间
        /// </summary>
        public DateTime? dt_ChargeMon {get;set;}



    }
}