using Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public  class StoreSumD : BaseTable
    {
       public StoreSumD()
           : base("T_StoreSum", "Ing_StoreSumID")
        {
            this.Sqlca = SqlcaWeChat();
       }
    }
}
