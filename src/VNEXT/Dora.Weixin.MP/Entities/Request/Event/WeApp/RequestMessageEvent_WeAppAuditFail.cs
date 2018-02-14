
namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之小程序审核失败
    /// </summary>
    public class RequestMessageEvent_WeAppAuditFail : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.weapp_audit_fail; }
        }

        /// <summary>
        /// 审核失败的原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 审核失败时的时间（整型），时间戳
        /// </summary>
        public string FailTime { get; set; }
    }
}
