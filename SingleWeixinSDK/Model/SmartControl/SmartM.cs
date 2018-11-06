using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SmartControl
{
    public class SmartM
    {
        /// <summary>
        /// 
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipcardid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int vipid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int custid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string custName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ing_storeID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string storename { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int masterid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int roomid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roomNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean isOnline { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<DeviceM> info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 之前是否领取智能遥控器优惠券
        /// </summary>
        public int Ing_SHActivity { get; set; }

        /// <summary>
        /// 领取是否成功
        /// </summary>
        public int Ing_SHActivity0 { get; set; }
        /// <summary>
        /// 是否显示领取界面
        /// </summary>
        public int Ing_SHShow { get; set; }
    }
}
