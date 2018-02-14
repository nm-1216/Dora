namespace Dora.Weixin.Entities
{
    /// <summary>
    /// 响应回复消息基类接口
    /// </summary>
	public interface IResponseMessageBase : IMessageBase
	{
		//ResponseMsgType MsgType { get; }
		//string Content { get; set; }
		//bool FuncFlag { get; set; }
	}

	/// <summary>
	/// 响应回复消息基类
	/// </summary>
	public abstract class ResponseMessageBase : MessageBase, IResponseMessageBase
	{
        //public virtual ResponseMsgType MsgType
        //{
        //    get { return ResponseMsgType.Text; }
        //}
	}
}
