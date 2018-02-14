
using Dora.Weixin.Entities.Request;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 文本类型消息
    /// </summary>
    public class RequestMessageText : RequestMessageBase, IRequestMessageBase, IRequestMessageText
    {
        public override RequestMsgType MsgType
        {
            get { return RequestMsgType.Text; }
        }

        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
}
