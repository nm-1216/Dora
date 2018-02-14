
namespace Dora.Weixin.MP.Entities
{
    public class RequestMessageEvent_Card_Sku_Remind : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 进入会员卡
        /// </summary>
        public override Event Event
        {
            get { return Event.card_sku_remind; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 报警详细信息
        /// </summary>
        public string Detail { get; set; }

    }
}
