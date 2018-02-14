
namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// IRequestMessageEventBase
    /// </summary>
    public interface IRequestMessageEventBase : IRequestMessageBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        Event Event { get; }
        ///// <summary>
        ///// 事件KEY值，与自定义菜单接口中KEY值对应
        ///// </summary>
        //string EventKey { get; set; }
    }

    /// <summary>
    /// 请求消息的事件推送消息基类
    /// </summary>
    public class RequestMessageEventBase : RequestMessageBase, IRequestMessageEventBase
    {
        public override RequestMsgType MsgType
        {
            get { return RequestMsgType.Event; }
        }

        /// <summary>
        /// 事件类型
        /// </summary>
        public virtual Event Event
        {
            get { return Event.ENTER; }
        }
    }
}
