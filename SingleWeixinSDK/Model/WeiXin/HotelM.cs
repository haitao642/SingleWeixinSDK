using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 查询门店用到的参数
    /// </summary>
    public class HotelM : JSPayModel
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        public string cityname { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public string longitude { get; set; }

        ///<summary>
        ///完整地址
        /// </summary>
        public string formatted_address { get; set; }

        /// <summary>
        /// 来期
        /// </summary>
        public DateTime dtArr { get; set; }

        /// <summary>
        /// 来期的字符串
        /// </summary>
        public string strArr
        {
            get
            {
                return dtArr.ToString("M月d日");
            }
        }

        /// <summary>
        /// 离期
        /// </summary>
        public DateTime dtDep { get; set; }

        /// <summary>
        /// 离期的字符串
        /// </summary>
        public string strDep
        {
            get
            {
                return dtDep.ToString("M月d日");
            }
        }

        /// <summary>
        /// 房晚
        /// </summary>
        public int day
        {
            get
            {
                return dtDep.Date.Subtract(dtArr.Date).Days;
            }
        }

        /// <summary>
        /// 城市列表
        /// </summary>
        public List<string> listcity { get; set; }

        /// <summary>
        /// 是否显示 今晨六点之前   今晨六点之后   1：显示   0：不显示
        /// </summary>
        public int showAddOneNight { get; set; }


    }


    /// <summary>
    /// 门店查询页面用到的类
    /// </summary>
    public class ListSearchHotelM
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        public HotelM searchM { get; set; }

        /// <summary>
        /// 门店列表
        /// </summary>
        public List<StoreM> list { get; set; }

        /// <summary>
        /// 是否显示 今晨六点之前   今晨六点之后   1：显示   0：不显示
        /// </summary>
        public int showAddOneNight { get; set; }


        /// <summary>
        /// 选中了六点之前
        /// </summary>
        public int Front6Hour { get; set; }


        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }
    }

    /// <summary>
    /// 单个门店详情
    /// </summary>
    public class HotelDetailM
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 返回的url
        /// </summary>
        public string backurl { get; set; }

        /// <summary>
        /// 总的评论数
        /// </summary>
        public int Ing_TotalComment { get; set; }

        /// <summary>
        /// 好评数
        /// </summary>
        public int Ing_GoodComment { get; set; }

        /// <summary>
        /// 好评率
        /// </summary>
        public string str_Good
        {
            get
            {
                if (Ing_TotalComment == 0) return "100%";
                double d = Ing_GoodComment * 100.0 / Ing_TotalComment;
                return string.Format("{0}%", d.ToString("F1"));
            }
        }
        public double dou_Star
        {
            get
            {
                if (Ing_TotalComment == 0) return 5.0;
                double d = Ing_GoodComment * 5.0 / Ing_TotalComment;
                return d;
            }
        }
        /// <summary>
        /// 总评分  5分为最高
        /// </summary>
        public string str_Star
        {
            get
            {
                if (Ing_TotalComment == 0) return "5.0";
                double d = Ing_GoodComment * 5.0 / Ing_TotalComment;
                return string.Format("{0}", d.ToString("F1"));
            }
        }
        /// <summary>
        /// 会员第一次入住的主单号
        /// </summary>
        public int Ing_FirstMaster { get; set; }

        /// <summary>
        /// 订单首日的首住88的名额余额
        /// </summary>
        public int Ing_LeftFirstMaster { get; set; }



        /// <summary>
        /// 查询条件
        /// </summary>
        public HotelM searchM { get; set; }

        /// <summary>
        /// 门店信息
        /// </summary>
        public StoreM storeDetailM { get; set; }

        /// <summary>
        /// 房型列表
        /// </summary>
        public List<RoomType1M> listroomtype { get; set; }

        /// <summary>
        /// 酒店图片
        /// </summary>
        public List<StoreImgM> listimg { get; set; }

        /// <summary>
        /// web地址
        /// </summary>
        public string webroot { get; set; }

        /// <summary>
        /// 是否显示 今晨六点之前   今晨六点之后   1：显示   0：不显示
        /// </summary>
        public int showAddOneNight { get; set; }


        /// <summary>
        /// 选中了六点之前
        /// </summary>
        public int Front6Hour { get; set; }



        /// <summary>
        /// 旅游信息
        /// </summary>
        public List<ZBInfoM> strtour { get; set; }

        /// <summary>
        /// 商场
        /// </summary>
        public List<ZBInfoM> strmarket { get; set; }

        /// <summary>
        /// 医疗
        /// </summary>
        public List<ZBInfoM> strhospital { get; set; }

        /// <summary>
        /// 银行
        /// </summary>
        public List<ZBInfoM> strbank { get; set; }


        /// <summary>
        /// 美食
        /// </summary>
        public List<ZBInfoM> strdiet { get; set; }


        /// <summary>
        /// 交通
        /// </summary>
        public string strtraffic { get; set; }
        /// <summary>
        /// 时租房开始时间
        /// </summary>
        public int HourStart { get; set; }
        /// <summary>
        /// 时租房结束时间
        /// </summary>
        public int HourEnd { get; set; }
        /// <summary>
        /// 钟点房到店时间
        /// </summary>
        public int strtime { get; set; }

    }


    /// <summary>
    /// 绑定周边信息的类
    /// </summary>
    public class ZBInfoM
    {
        /// <summary>
        /// name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// city
        /// </summary>
        public string city { get; set; }

        /// <summary>
        /// address
        /// </summary>
        public string address { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        public string distance { get; set; }

        /// <summary>
        /// district
        /// </summary>
        public string district { get; set; }

        /// <summary>
        /// lng
        /// </summary>
        public string lng { get; set; }

        /// <summary>
        /// lat
        /// </summary>
        public string lat { get; set; }
    }

    /// <summary>
    /// 房型
    /// </summary>
    public class RoomType1M
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
        /// 门市价
        /// </summary>
        public decimal price0 { get; set; }

        /// <summary>
        /// 白金
        /// </summary>
        public decimal price1 { get; set; }

        /// <summary>
        /// 黄金
        /// </summary>
        public decimal price2 { get; set; }

        /// <summary>
        /// 银卡
        /// </summary>
        public decimal price3 { get; set; }

        /// <summary>
        /// 普卡
        /// </summary>
        public decimal price4 { get; set; }

        /// <summary>
        /// 能用的房间
        /// </summary>
        public int CanUseRoom { get; set; }

        /// <summary>
        /// 这种房型有几间
        /// </summary>
        public int roomnum { get; set; }


        /// <summary>
        /// 会员首住的房价
        /// </summary>
        public decimal dec_FirstLivePrice { get; set; }
        /// <summary>
        /// 房型显示顺序
        /// </summary>
        public string display_order { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string display_orderIcon { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public string str_Area { get; set; }
        /// <summary>
        /// 床宽
        /// </summary>
        public string str_Bed_w { get; set; }

        /// <summary>
        /// 床型
        /// </summary>
        public string str_BedType { get; set; }

        /// <summary>
        /// 是否有窗户 (0代表没有,1代表有)
        /// </summary>
        public int Ing_window { get; set; }
        /// <summary>
        /// 是否有窗户
        /// </summary>

        public string strWindow
        {
            get
            {

                if (Ing_window == 0)
                {
                    return "无";
                }
                else
                {
                    return "有";
                }
            }
        }
        /// <summary>
        /// 所在楼层
        /// </summary>
        public string str_CurrentFloor { get; set; }
        /// <summary>
        /// 入住人数
        /// </summary>

        public string str_NumberGuest { get; set; }
        /// <summary>
        /// 备注
        /// </summary>

        public string str_Remark { get; set; }
        /// <summary>
        /// 房型图片
        /// </summary>
        public List<StoreImgM> listimg { get; set; }
    }


    /// <summary>
    /// 预订页面用到的类
    /// </summary>
    public class WriteOrderM
    {
        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 返回的url
        /// </summary>
        public string backurl { get; set; }

        /// <summary>
        /// 此url
        /// </summary>
        public string rawurl { get; set; }


        /// <summary>
        /// 门店名称
        /// </summary>
        public string str_StoreName { get; set; }


        /// <summary>
        /// 门店全称 
        /// </summary>
        public string str_StoreFullName { get; set; }


        /// <summary>
        /// 来期
        /// </summary>
        public DateTime dtArr { get; set; }

        /// <summary>
        /// 来期的字符串
        /// </summary>
        public string strArr
        {
            get
            {
                return dtArr.ToString("MM月dd日");
            }
        }

        /// <summary>
        /// 离期
        /// </summary>
        public DateTime dtDep { get; set; }

        /// <summary>
        /// 离期的字符串
        /// </summary>
        public string strDep
        {
            get
            {
                return dtDep.ToString("MM月dd日");
            }
        }

        /// <summary>
        /// 房晚
        /// </summary>
        public int day
        {
            get
            {
                return dtDep.Date.Subtract(dtArr.Date).Days;
            }
        }

        /// <summary>
        /// 订房数
        /// </summary>
        public int Ing_RoomNum { get; set; }


        /// <summary>
        /// 房型编码
        /// </summary>
        public string RoomTypeCode { get; set; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string str_CusName { get; set; }


        /// <summary>
        /// 手机号
        /// </summary>
        public string str_mobile { get; set; }

        /// <summary>
        /// 会员卡ID
        /// </summary>
        public int lngvipcardid { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }


        /// <summary>
        /// 一间房   一天的价格
        /// </summary>
        public decimal price { get; set; }


        /// <summary>
        /// 总的价格
        /// </summary>
        public decimal totalprice { get; set; }

        /// <summary>
        /// 可用数量
        /// </summary>
        public int CanUserNum { get; set; }


        /// <summary>
        /// 对应的房价码
        /// </summary>
        public string VipRateCode { get; set; }

        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 是否显示 今晨六点之前   今晨六点之后   1：显示   0：不显示
        /// </summary>
        public int showAddOneNight { get; set; }


        /// <summary>
        /// 选中了六点之前
        /// </summary>
        public int Front6Hour { get; set; }

        /// <summary>
        /// 会员首住的房价
        /// </summary>
        public decimal dec_FirstLivePrice { get; set; }

        /// <summary>
        /// 钟点房方案，如果为0，则表示全天房
        /// </summary>
        public int HourID { get; set; }

        /// <summary>
        /// 实际房价
        /// </summary>
        public decimal dec_ActualRate { get; set; }

        /// <summary>
        /// 房型id
        /// </summary>
        public int roomtypeid { get; set; }


        public string token { get; set; }
        
    }

    /// <summary>
    /// 预订成功后的页面
    /// </summary>
    public class OrderSuccessM
    {
        /// <summary>
        /// 错误信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 主单id
        /// </summary>
        public int MasterID { get; set; }

        /// <summary>
        /// 门店全称 
        /// </summary>
        public string str_StoreFullName { get; set; }

        /// <summary>
        /// 门店全称 
        /// </summary>
        public string str_StoreName { get; set; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName { get; set; }

        /// <summary>
        /// 保留时间
        /// </summary>
        public DateTime dt_Res { get; set; }

        /// <summary>
        /// 当天房价
        /// </summary>
        public decimal dec_ActualRate { get; set; }

        /// <summary>
        /// 门店ID
        /// </summary>
        public int Ing_StoreID { get; set; }

        /// <summary>
        /// 房价变更优惠券
        /// </summary>
        public List<ResultCouponM> CouponPirceList { get; set; }
    }
}
