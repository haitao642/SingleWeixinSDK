using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 客人与店长互动页面的类
    /// </summary>
    public class QuestionM
    {
        /// <summary>
        /// 评论id
        /// </summary>
        public int CommentID { get; set; }

        /// <summary>
        /// 门店名称
        /// </summary>
        public string StoreName { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public CommentsM comM { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string CusName { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime dtArr { get; set; }

        /// <summary>
        /// 如果是店长，这个大于0，如果是客人，这个为0
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 要发送的微信id列表
        /// </summary>
        public List<string> listopenid { get; set; }

        /// <summary>
        /// 以逗号分隔的openid
        /// </summary>
        public string stropenid {
            get {
                return string.Join(",",listopenid.ToArray());
            }
        }

        /// <summary>
        /// 回复列表
        /// </summary>
        public List<ComDetailM> list { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string message { get; set; }
    }
}
