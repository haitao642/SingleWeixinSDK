using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// T_StoreSum
    /// </summary>
    public class StoreSumM
    {
        ///<summary>
        ///Ing_StoreSumID
        /// </summary>
        public int Ing_StoreSumID { get; set; }

        ///<summary>
        ///城市
        /// </summary>
        public string str_city { get; set; }

        ///<summary>
        ///门店数量
        /// </summary>
        public int Ing_Sum { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        public int Ing_order { get; set; }
    }

    /// <summary>
    /// 酒店统计列表
    /// </summary>
    public class StoreSumListM
    {
        /// <summary>
        /// 列表
        /// </summary>
        public List<StoreSumM> list { get; set; }
    }
}