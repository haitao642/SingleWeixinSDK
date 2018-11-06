using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_StoreImg
    /// </summary>
    public class StoreImgM
    {
        ///<summary>
        ///编号
        /// </summary>
        public int Ing_PK_ImgID {get;set;}

        ///<summary>
        ///门店ID
        /// </summary>
        public int Ing_StoreID {get;set;}

        ///<summary>
        ///上传路径
        /// </summary>
        public string str_DLPath {get;set;}

        ///<summary>
        ///图片名称
        /// </summary>
        public string str_FileName {get;set;}

        ///<summary>
        ///图片标识
        /// </summary>
        public int Ing_IsTop {get;set;}

        /// <summary>
        /// 顺序
        /// </summary>
        public int order { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        public string display { get; set; }

        /// <summary>
        /// id名称
        /// </summary>
        public string strid { get {
            return string.Format("divimgshow{0}", order);
        } }

        /// <summary>
        /// 房型
        /// </summary>
        public string str_Room { get; set; }
    }
}