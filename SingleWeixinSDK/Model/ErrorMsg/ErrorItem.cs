using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ErrorMsg
{
    /// <summary>
    /// 错误类型
    /// </summary>
    public class ErrorItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="eId"></param>
        /// <param name="emsg"></param>
        /// <param name="eFriendmsg"></param>
        public ErrorItem(int eId, String emsg, String eFriendmsg)
        {
            errorId = eId;
            errorMessage = emsg;
            errorFriendlyMessage = eFriendmsg;
        }
        /// <summary>
        /// 错误id
        /// </summary>
        public int errorId { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public String errorMessage { get; set; }

        /// <summary>
        /// 错误友好提示
        /// </summary>
        public String errorFriendlyMessage { get; set; }
    }
}
