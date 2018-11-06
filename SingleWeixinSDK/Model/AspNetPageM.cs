using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 分页查询用到的参数
    /// </summary>
    public class AspNetPageM
    {
        /// <summary>
        /// 要分页显示的表名
        /// </summary>
        public string TableNames { get; set; }

        /// <summary>
        /// 用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
        /// </summary>
        public string PrimaryKey { get; set; }

        /// <summary>
        /// 以逗号分隔的要显示的字段列表,如果不指定,则显示所有字段 
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 每页的大小(记录数) 
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 要显示的页码 
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 查询条件 
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// 暂时不可用（传空值即可）
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 以逗号分隔的排序字段列表,可以指定在字段后面指定DESC/ASC   --  用于指定排序顺序 
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 门店
        /// </summary>

        public int Ing_StoreID { get; set; }
    }

    /// <summary>
    /// 列表分页所传参数的基类
    /// </summary>
    public class AspNetPageBaseM
    {
        ///<summary>
        ///Ing_StoreID    全部:-1
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 每页的大小(记录数) ，如果没传，就取 web.config里配置的，所以
        /// 一般情况下可以不传
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// 要显示的页码 ，如果没传，就取1
        /// </summary>
        public int page { get; set; }
    }
}
