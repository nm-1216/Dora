using System;

namespace Dora.Weixin.Exceptions
{
    /// <summary>
    /// 菜单异常
    /// </summary>
    public class WeixinMenuException : WeixinException
    {
        public WeixinMenuException(string message)
            : this(message, null)
        {
        }

        public WeixinMenuException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
