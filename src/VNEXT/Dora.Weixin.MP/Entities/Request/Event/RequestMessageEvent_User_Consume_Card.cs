﻿
namespace Dora.Weixin.MP.Entities
{
    public class RequestMessageEvent_User_Consume_Card : RequestMessageEventBase, IRequestMessageEventBase
    {
        /// <summary>
        /// 卡券核销
        /// </summary>
        public override Event Event
        {
            get { return Event.user_consume_card; }
        }

        /// <summary>
        /// 卡券ID
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 卡券Code码
        /// </summary>
        public string UserCardCode { get; set; }
        /// <summary>
        /// 核销来源。支持开发者统计API核销（FROM_API）、公众平台核销（FROM_MP）、卡券商户助手核销（FROM_MOBILE_HELPER）（核销员微信号）
        /// </summary>
        public string ConsumeSource { get; set; }

        /// <summary>
        /// 门店名称，当前卡券核销的门店名称（只有通过自助核销和买单核销时才会出现该字段）
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        ///核销该卡券核销员的openid（只有通过卡券商户助手核销时才会出现） 
        /// </summary>
        public string StaffOpenId { get; set; }
        /// <summary>
        /// 自助核销时，用户输入的验证码
        /// </summary>
        public string VerifyCode { get; set; }
        /// <summary>
        /// 自助核销时，用户输入的备注金额
        /// </summary>
        public string RemarkAmount { get; set; }
        /// <summary>
        /// 开发者发起核销时传入的自定义参数，用于进行核销渠道统计
        /// </summary>
        public string OuterStr { get; set; }
    }
}
