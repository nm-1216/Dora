
namespace Dora.Weixin.MP.Entities
{
    /// <summary>
    /// 事件之小程序审核成功
    /// </summary>
    public class RequestMessageEvent_WeAppAuditSuccess : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override Event Event
        {
            get { return Event.weapp_audit_success; }
        }

        /// <summary>
        /// 审核成功时的时间（整型），时间戳
        /// </summary>
        public string SuccTime { get; set; }
    }
}
