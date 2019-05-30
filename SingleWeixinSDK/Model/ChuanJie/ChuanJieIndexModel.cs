using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ChuanJie
{
    public class ChuanJieBaseModel
    {
        public string message { get; set; }
        /// <summary>
        /// 返回的url
        /// </summary>
        public string backurl { get; set; }
        public StoreM storeM { get; set; }
        public List<StoreImgM> listimg { get; set; }
    }

    public class ChuanJieIndexModel: ChuanJieBaseModel
    {
        
    }
    public class HotSpringIndexModel: ChuanJieBaseModel
    {
        
    }

    public class RestaurantIndexModel : ChuanJieBaseModel
    {

    }

    public class GlofIndexModel : ChuanJieBaseModel
    {

    }

    public class EquestrianIndexModel : ChuanJieBaseModel
    {

    }
}
