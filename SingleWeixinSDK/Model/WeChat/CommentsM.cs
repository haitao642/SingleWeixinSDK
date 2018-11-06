using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_Comments
    /// </summary>
    public class CommentsM
    {
        ///<summary>
        ///主键
        /// </summary>
        public int Ing_Pk_comID {get;set;}

        ///<summary>
        ///门店ID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///会员卡ID
        /// </summary>
        public int Ing_VipcardID {get;set;}

        ///<summary>
        ///评论时间
        /// </summary>
        public DateTime dt_comDate {get;set;}


        ///<summary>
        ///总的评价   0:满意  1：不满意
        /// </summary>
        public int Ing_total {get;set;}

        ///<summary>
        ///优点
        /// </summary>
        public string str_good {get;set;}

        ///<summary>
        ///str_bad
        /// </summary>
        public string str_bad {get;set;}

        ///<summary>
        ///酒店服务   从好到坏，0 1 2
        /// </summary>
        public int Ing_col1 {get;set;}

        ///<summary>
        ///干净卫生   从好到坏，0 1 2
        /// </summary>
        public int Ing_col2 {get;set;}

        ///<summary>
        ///房内休息环境(空间/噪音/气味等)   从好到坏，0 1 2
        /// </summary>
        public int Ing_col3 {get;set;}

        ///<summary>
        ///睡床舒适度   从好到坏，0 1 2
        /// </summary>
        public int Ing_col4 {get;set;}

        ///<summary>
        ///床上用品   从好到坏，0 1 2
        /// </summary>
        public int Ing_col5 {get;set;}

        ///<summary>
        ///淋浴   从好到坏，0 1 2
        /// </summary>
        public int Ing_col6 {get;set;}

        ///<summary>
        ///封包浴巾   从好到坏，0 1 2
        /// </summary>
        public int Ing_col7 {get;set;}

        ///<summary>
        ///WIFI网络   从好到坏，0 1 2
        /// </summary>
        public int Ing_col8 {get;set;}

        ///<summary>
        ///房间设施及装修   从好到坏，0 1 2
        /// </summary>
        public int Ing_col9 {get;set;}

        ///<summary>
        ///酒店照明   从好到坏，0 1 2
        /// </summary>
        public int Ing_col10 {get;set;}

        ///<summary>
        ///删除标志
        /// </summary>
        public int Ing_del {get;set;}

        ///<summary>
        ///备注
        /// </summary>
        public string str_memo {get;set;}

        /// <summary>
        /// 主单id
        /// </summary>
        public int Ing_MasterID {get;set;}


        /// <summary>
        /// 房型
        /// </summary>
        public string str_RoomType { get; set; }

        /// <summary>
        /// 房间号
        /// </summary>
        public string str_RoomNo { get; set; }



    }
}