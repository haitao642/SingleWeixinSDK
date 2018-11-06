using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 散客预订的房型列表
    /// </summary>
    public class FitReservationM
    {
        /// <summary>
        /// 房型主键
        /// </summary>
        public int Ing_Pk_RoomTypeID { get; set; }

        /// <summary>
        /// 房型code
        /// </summary>
        public string strRoomTypeCode { get; set; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string strRoomTypeName { get; set; }


        /// <summary>
        /// 非会员价
        /// </summary>
        public decimal price1 { get; set; }


        /// <summary>
        /// 会员价
        /// </summary>
        public decimal price2 { get; set; }

        /// <summary>
        /// 能用的房间
        /// </summary>
        public int CanUseRoom { get; set; }

    }
}
