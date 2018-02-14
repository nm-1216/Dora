
namespace Dora.Weixin.MP.Entities
{
    public class RequestMessageEvent_Card_Not_Pass_Check : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 卡券未通过审核
        /// </summary>
        public override Event Event
        {
            get { return Event.card_not_pass_check; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 审核不通过原因
        /// </summary>
        public string RefuseReason { get; set; }
    }
}
