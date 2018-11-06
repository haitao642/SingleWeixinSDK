using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class WeChatB
    {
        public DAL.WeChatD dal = new DAL.WeChatD();


                /// <summary>
        /// 支付房费成功
        /// {{first.DATA}}

//订单号：{{folioId.DATA}}
//已成功支付房费{{roomRate.DATA}}元，房间整晚保留！
//{{remark.DATA}}
        /// </summary>
        /// <param name="model"></param>
        public void WeChatPaySuccess(WeChatPaySuccessM model)
        {
            dal.WeChatPaySuccess(model);
        }

    }
}
