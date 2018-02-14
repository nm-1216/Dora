
namespace Dora.Weixin.MP.Entities
{
    public class ResponseMessageText : ResponseMessageBase, IResponseMessageBase
    {
        public new virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Text; }
        }

        public string Content { get; set; }
    }
}
