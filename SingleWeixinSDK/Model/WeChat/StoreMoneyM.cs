using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.WeChat
{
    public class StoreMoneyM
    {
       
        public int Ing_Pk_id { get; set; }
        public int Ing_StoreID { get; set; }
        public int Ing_charge_type { get; set; }
        public string str_trade_type { get; set; }
        public decimal dec_charge_price { get; set; }
        public int Ing_charge_num { get; set; }
        public decimal dec_balance { get; set; }
        public DateTime dt_charge_time { get; set; }
        public string str_remark { get; set; }
        public int Ing_state { get; set; }
        public DateTime dt_modify_time { get; set; }
        public string str_trade_no { get; set; }
    }
}
