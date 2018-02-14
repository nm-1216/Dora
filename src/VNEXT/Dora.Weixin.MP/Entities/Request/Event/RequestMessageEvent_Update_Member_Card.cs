
namespace Dora.Weixin.MP.Entities
{
    public class RequestMessageEvent_Update_Member_Card : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 卡券未通过审核
        /// </summary>
        public override Event Event
        {
            get { return Event.update_member_card; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// code序列号。
        /// </summary>
        public string UserCardCode { get; set; }
        /// <summary>
        /// 变动的积分值。
        /// </summary>
        public int ModifyBonus { get; set; }
        /// <summary>
        /// 变动的余额值。
        /// </summary>
        public int ModifyBalance { get; set; }
    }
}
