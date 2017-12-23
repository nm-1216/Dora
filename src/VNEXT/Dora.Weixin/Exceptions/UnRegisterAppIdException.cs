using System;

namespace Dora.Weixin.Exceptions
{
    /// <summary>
    /// 未注册 AppId 异常
    /// </summary>
    public class UnRegisterAppIdException : WeixinException
    {
        public string AppId { get; set; }
        public UnRegisterAppIdException(string appId, string message, Exception inner = null)
            : base(message, inner)
        {
            AppId = appId;
        }
    }
}
