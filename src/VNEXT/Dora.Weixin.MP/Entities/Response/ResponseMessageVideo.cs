
namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 需要预先上传多媒体文件到微信服务器，只支持认证服务号。
    /// </summary>
    public class ResponseMessageVideo : ResponseMessageBase, IResponseMessageBase
    {
        public new virtual ResponseMsgType MsgType
        {
            get { return ResponseMsgType.Video; }
        }

        public Video Video { get; set; }

        public ResponseMessageVideo()
        {
            Video = new Video();
        }
    }
}
