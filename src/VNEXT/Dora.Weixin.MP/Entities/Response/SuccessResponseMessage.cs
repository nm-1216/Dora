
using Dora.Weixin.Entities;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 只返回"success"等指定字符串的响应信息
    /// </summary>
    public class SuccessResponseMessage : SuccessResponseMessageBase, IResponseMessageBase
    {
        public ResponseMsgType MsgType
        {
            get { return ResponseMsgType.SuccessResponse; }
        }
    }
}
