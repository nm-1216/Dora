

using System;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之年审通知
    /// </summary>
    public class RequestMessageEvent_AnnualRenew : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.annual_renew; }
        }

        /// <summary>
        /// 有效期 (整形)，指的是时间戳，将于该时间戳认证过期，需尽快年审
        /// </summary>
        public DateTime ExpiredTime { get; set; }
    }
}
