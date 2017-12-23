using System;

namespace Dora.Weixin.Entities
{
    /// <summary>
    /// 企业微信 JSON 返回结果
    /// </summary>
    [Serializable]
    public class WorkJsonResult : BaseJsonResult
    {
        /// <summary>
        /// 返回代码
        /// </summary>
        public ReturnCode_Work errcode { get; set; }

        /// <summary>
        /// 返回消息代码数字（同errcode枚举值）
        /// </summary>
        public override int ErrorCodeValue { get { return (int)errcode; } }
    }
}
