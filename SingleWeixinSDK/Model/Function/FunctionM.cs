using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Function
{

    /// <summary>
    /// 酒店特色界面用到的类
    /// </summary>
    public class HotelFunctionM
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }


        /// <summary>
        /// 返回url
        /// </summary>
        public string backurl { get; set; }
        /// <summary>
        /// 门店全称 
        /// </summary>
        public string str_StoreFullName { get; set; }

        /// <summary>
        /// 门店全称 
        /// </summary>
        public string str_StoreName { get; set; }


        /// <summary>
        /// 根目录分类
        /// </summary>
        public List<FunctionM> rootFunctions { get; set; }

    }

    //功能介绍
    public class FunctionM
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Ing_id { get; set; }
        /// <summary>
        /// 门店号 维护管理平台
        /// </summary>

        public int Ing_Pkid { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int parentid { get; set; }
        /// <summary>
        /// 是否为根级  0为根级
        /// </summary>
        public int isRoot { get; set; }


        /// <summary>
        /// 标题（只适用于根系列）
        /// </summary>
        public int title { get; set; }

    
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 图片文件id
        /// </summary>
        public int  Ing_Fk_fileID { get; set; }


        ///<summary>
        ///上传路径
        /// </summary>
        public string str_DLPath { get; set; }

        ///<summary>
        ///图片名称
        /// </summary>
        public string str_FileName { get; set; }
        /// <summary>
        /// 是否删除 0：删除 1：启用
        /// </summary>
        public int is_Deleted { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime dt_CreateTime { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime dt_ModifyTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string str_Modify { get; set; }

        /// <summary>
        /// 排序，数组越大越优先
        /// </summary>
        public int sort { get; set; }


        public List<FunctionM> subList { get; set; }
    }
    /// <summary>
    /// 酒店活动
    /// </summary>
    public class ActivityM
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Ing_id { get; set; }

        /// <summary>
        /// 门店号 维护管理平台
        /// </summary>

        public int Ing_Pkid { get; set; }


        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 图片文件id
        /// </summary>
        public int Ing_Fk_fileID { get; set; }

        /// <summary>
        /// 是否删除 0：删除 1：启用
        /// </summary>
        public int is_Deleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime dt_CreateTime { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime dt_ModifyTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string str_Modify { get; set; }

        /// <summary>
        /// 排序，数组越大越优先
        /// </summary>
        public int sort { get; set; }
    }
}
