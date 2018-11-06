using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_FirstCheck_Config
    /// </summary>
    public class FirstCheckConfigM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_ID {get;set;}

        ///<summary>
        ///日期
        /// </summary>
        public DateTime? dt_Date {get;set;}

        ///<summary>
        ///总数
        /// </summary>
        public int Ing_TotalNum {get;set;}

        ///<summary>
        ///使用次数
        /// </summary>
        public int Ing_UserNum {get;set;}


        ///<summary>
        ///类型   0：微信端的控制
        /// </summary>
        public int Ing_Type { get; set; }

        ///<summary>
        ///门店id
        /// </summary>
        public int Ing_StoreID {get;set;}



    }    
}