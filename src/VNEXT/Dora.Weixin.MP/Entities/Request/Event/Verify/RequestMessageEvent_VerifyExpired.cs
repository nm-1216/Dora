
using System;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之认证过期失效通知
    /// </summary>
    public class RequestMessageEvent_VerifyExpired : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.verify_expired; }
        }

        /// <summary>
        /// 有效期 (整形)，指的是时间戳，表示已于该时间戳认证过期，需要重新发起微信认证
        /// </summary>
        public DateTime ExpiredTime { get; set; }
    }
}
