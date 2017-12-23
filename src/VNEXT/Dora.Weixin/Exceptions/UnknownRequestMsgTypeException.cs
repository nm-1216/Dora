using System;

namespace Dora.Weixin.Exceptions
{
    /// <summary>
    /// 未知请求类型异常
    /// </summary>
    public class UnknownRequestMsgTypeException : MessageHandlerException //ArgumentOutOfRangeException
    {
        public UnknownRequestMsgTypeException(string message)
            : this(message, null)
        {
        }

        public UnknownRequestMsgTypeException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}
