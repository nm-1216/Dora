﻿
namespace Dora.Weixin.MP.Entities
{
    public class RequestMessageEvent_Card_Pay_Order : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 进入会员卡
        /// </summary>
        public override Event Event
        {
            get { return Event.card_pay_order; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 商户自定义code值。非自定code推送为空串。
        /// </summary>
        public string UserCardCode { get; set; }
        /// <summary>
        /// 商户自定义二维码渠道参数，用于标识本次扫码打开会员卡来源来自于某个渠道值的二维码
        /// </summary>
        public string OuterStr { get; set; }
    }
}
