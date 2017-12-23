using System;

namespace Dora.Weixin.Exceptions
{
    /// <summary>
    /// MessageHandler异常
    /// </summary>
    public class MessageHandlerException : WeixinException
    {
          public MessageHandlerException(string message)
            : this(message, null)
        {
        }

          public MessageHandlerException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
