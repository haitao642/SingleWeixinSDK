using Model.WeiXin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Wechat
{
    public class WeChatConfigB
    {
        DAL.Wechat.WeChatConfigD wcd = new DAL.Wechat.WeChatConfigD();
        public WeChatConfigM GetWeixinConfig(int storeid)
        {
            return wcd.GetWeixinConfig(storeid);
        }
    }
}
