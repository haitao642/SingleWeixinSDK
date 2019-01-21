using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.System
{
    public class SysParaB
    {
        SysParaD dal = new SysParaD();
        public SysParaM GetRecord(string str_ParaType,int storeid)
        {
            return dal.GetRecord(str_ParaType,storeid);
        }
    }
}
