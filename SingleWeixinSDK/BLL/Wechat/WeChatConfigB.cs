using Model;
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
        //public WeChatConfigM GetWeixinConfig(int storeid)
        //{
        //    return wcd.GetWeixinConfig(storeid);
        //}
        public WeChatFileM GetOne(int Ing_PK_FileID)
        {
            return wcd.GetOne(Ing_PK_FileID);
        }



        public Model.WeChatConfigM GetWeixinConfigForOta(string storeid)
        {
            return wcd.GetWeixinConfigForOta(storeid);
        }
        /// <summary>
        /// 根据酒店ID获取门店图片
        /// </summary>
        /// <param name="Ing_Fk_SPkID"></param>
        /// <returns></returns>
        public List<WeChatFileM> getStoreImgList(string Ing_Fk_SPkID)
        {
            return wcd.getStoreImgList(Ing_Fk_SPkID);
        }
    }
}
