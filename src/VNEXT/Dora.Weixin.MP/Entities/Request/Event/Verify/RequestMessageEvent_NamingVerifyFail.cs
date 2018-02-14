
using System;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之名称认证失败（这时虽然客户端不打勾，但仍有接口权限）
    /// </summary>
    public class RequestMessageEvent_NamingVerifyFail : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.naming_verify_fail; }
        }

        /// <summary>
        /// 失败发生时间 (整形)，时间戳
        /// </summary>
        public DateTime FailTime { get; set; }
        /// <summary>
        /// 认证失败的原因
        /// </summary>

        public string FailReason { get; set; }
    }
}
