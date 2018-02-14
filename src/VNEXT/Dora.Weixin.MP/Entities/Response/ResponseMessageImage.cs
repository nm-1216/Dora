
namespace Dora.Weixin.MP.Entities
{
    public class ResponseMessageImage : ResponseMessageBase, IResponseMessageBase
    {
        public new virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Image; }
        }

        public Image Image { get; set; }

        public ResponseMessageImage()
        {
            Image = new Image();
        }
    }
}
