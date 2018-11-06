using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_News
    /// </summary>
    public class NewsM
    {
        ///<summary>
        ///自动增长
        /// </summary>
        public int Ing_NewsID {get;set;}

        ///<summary>
        ///文章标题
        /// </summary>
        public string str_Title {get;set;}

        ///<summary>
        ///str_TitleImg
        /// </summary>
        public string str_TitleImg {get;set;}

        ///<summary>
        ///文章内容
        /// </summary>
        public string str_NContent {get;set;}

        ///<summary>
        ///作者
        /// </summary>
        public string str_Author {get;set;}

        ///<summary>
        ///创建时间
        /// </summary>
        public DateTime? dt_Createtime {get;set;}

        ///<summary>
        ///修改人
        /// </summary>
        public string str_Modify {get;set;}

        ///<summary>
        ///修改时间
        /// </summary>
        public DateTime? dt_ModifyDate {get;set;}

        ///<summary>
        ///阅读次数
        /// </summary>
        public int? Ing_ReadNum {get;set;}

        ///<summary>
        ///文章大类
        /// </summary>
        public int? Ing_FCaption {get;set;}

        ///<summary>
        ///文章子类
        /// </summary>
        public int? Ing_ChildCaption {get;set;}

        ///<summary>
        ///Ing_Del
        /// </summary>
        public int? Ing_Del {get;set;}

        ///<summary>
        ///是否置顶（0 否 1是）
        /// </summary>
        public int? Ing_IsTop {get;set;}

        ///<summary>
        ///0：未审核 1：已审核 2:未通过
        /// </summary>
        public int? Ing_Checked {get;set;}

        ///<summary>
        ///审核人
        /// </summary>
        public string str_audit {get;set;}

        ///<summary>
        ///审核时间
        /// </summary>
        public DateTime? dt_auditTime {get;set;}

        ///<summary>
        ///Ing_sort
        /// </summary>
        public int? Ing_sort {get;set;}

        ///<summary>
        ///str_summary
        /// </summary>
        public string str_summary {get;set;}



    }

    /// <summary>
    /// 优惠列表页面
    /// </summary>
    public class PromotionListM
    {
        /// <summary>
        ///  优惠列表
        /// </summary>
        public List<NewsM> list { get; set; }
    }
}