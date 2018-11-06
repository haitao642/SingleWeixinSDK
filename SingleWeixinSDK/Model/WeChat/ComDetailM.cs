using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_ComDetail
    /// </summary>
    public class ComDetailM
    {
        ///<summary>
        ///主键，自增ID
        /// </summary>
        public int Ing_DetailID {get;set;}

        ///<summary>
        ///评论表的主键
        /// </summary>
        public int? Ing_ComID {get;set;}

        ///<summary>
        ///评论或者回复的内容
        /// </summary>
        public string str_Result {get;set;}

        ///<summary>
        ///时间
        /// </summary>
        public DateTime? dt_Com {get;set;}

        ///<summary>
        ///满意度  0：满意，  1：不满意
        /// </summary>
        public int? Ing_Result {get;set;}

        ///<summary>
        ///如果是店长回复的，就为店长的id
        /// </summary>
        public int Ing_UserID {get;set;}

        /// <summary>
        /// 要接收人员的微信id集合  以逗号分隔
        /// </summary>
        public string openids { get; set; }



    }
}