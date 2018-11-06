using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace Model
{
    /// <summary>
    /// 基类返回类型
    /// </summary>
    public class BaseResponseModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseResponseModel() { }

        /// <summary>
        /// 状态编码， 0 为成功，
        /// </summary>
        public int status = 0;

        /// <summary>
        /// 返回给客户端的具体数据
        /// </summary>
        public object data = null;


        /// <summary>
        /// 返回给客户端的具体数据,目前就树形结构的json用到
        /// </summary>
        public object children = null;

        /// <summary>
        /// 分页用到的记录条数
        /// </summary>
        public int Total = 0;


        /// <summary>
        /// 简易的返回信息
        /// </summary>
        public String message = String.Empty;


        /// <summary>
        /// 详细的返回信息，可直接被客户端用于显示
        /// </summary>
        public String friendlyMessage = String.Empty;

        /// <summary>
        /// 客户端的请求id, 出现异常的时候，便于根据requestId 查找原因
        /// </summary>
        public String requestId = string.Empty;

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool success
        {
            get
            {
                return status == 0;
            }
        }
    }

    /// <summary>
    /// 微信调用接口用到的model
    /// </summary>
    public class BaseWechatM
    {
        /// <summary>
        /// // 开启调试模式,调用的所有api的返回值会在客户端alert出来，若要查看传入的参数，可以在pc端打开，参数信息会通过log打出，仅在pc端时才会打印。
        /// </summary>
        public bool debug { get; set; }

        /// <summary>
        /// 必填，公众号的唯一标识
        /// </summary>
        public string appId
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["AppID"];
            }
        }
        /// <summary>
        /// 必填，生成签名的时间戳
        /// </summary>
        public long timestamp { get; set; }
        
        /// <summary>
        /// 生成签名的随机串 
        /// </summary>
        public string nonceStr { get; set; }

        /// <summary>
        /// 必填，签名，见附录1
        /// </summary>
        public string signature { get; set; }
        
        /// <summary>
        /// 需要使用的JS接口列表，所有JS接口列表见附录2
        /// </summary>
        public string jsApiList { get; set; }

        /// <summary>
        /// 分享链接
        /// </summary>
        public string str_ShareUrl { get; set; }

        /// <summary>
        /// 图片url
        /// </summary>
        public string str_ShareHeaderimgUrl { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string str_Title { get; set; }

        /// <summary>
        /// 类型 0优惠券，1礼包
        /// </summary>
        public int ing_Type { get; set; }

        /// <summary>
        /// 上面的主键（获取门店范围用到）
        /// </summary>
        public int ing_pkid { get; set; }
    }
}
