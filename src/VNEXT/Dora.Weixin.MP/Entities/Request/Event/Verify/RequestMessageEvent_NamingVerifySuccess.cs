
using System;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之名称认证成功（即命名成功）
    /// </summary>
    public class RequestMessageEvent_NamingVerifySuccess : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.naming_verify_success; }
        }

        /// <summary>
        /// 有效期 (整形)，指的是时间戳，将于该时间戳认证过期
        /// </summary>
        public DateTime ExpiredTime { get; set; }
    }
}
