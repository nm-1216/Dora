using System;

namespace Dora.Weixin.Entities
{
    /// <summary>
    /// 企业号 JSON 返回结果
    /// </summary>
    [Serializable]
    public class QyJsonResult : BaseJsonResult
    {
        /// <summary>
        /// 返回代码
        /// </summary>
        public ReturnCode_QY errcode { get; set; }

        /// <summary>
        /// 返回消息代码数字（同errcode枚举值）
        /// </summary>
        public override int ErrorCodeValue { get { return (int)errcode; } }
    }
}
