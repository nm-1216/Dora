﻿
namespace Dora.Weixin.MP.AppStore
{
    /// <summary>
    /// 获取微信会员信息结果
    /// </summary>
    public class GetMemberResult : AppResult<NormalAppData>
    {
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public WeixinSex Sex { get; set; }
        /// <summary>
        /// Base64格式的头像信息，当提供HeadImageUrl时不再提供HeadImageBase64
        /// </summary>
        public string HeadImageBase64 { get; set; }
        /// <summary>
        /// 头像URL地址
        /// </summary>
        public string HeadImageUrl { get; set; }
    }
}
