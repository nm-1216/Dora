
using System;

namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之资质认证成功（此时立即获得接口权限）
    /// </summary>
    public class RequestMessageEvent_QualificationVerifyFail : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.qualification_verify_fail; }
        }

        /// <summary>
        /// 有效期 (整形)，指的是时间戳，将于该时间戳认证过期
        /// </summary>
        public DateTime FailTime { get; set; }
        /// <summary>
        /// 失败发生时间 (整形)，时间戳
        /// </summary>

        public string FailReason { get; set; }
    }
}
