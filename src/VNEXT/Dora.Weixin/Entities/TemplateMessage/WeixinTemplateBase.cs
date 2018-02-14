using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dora.Weixin.Entities.TemplateMessage
{
    /// <summary>
    /// 模板消息数据基础类接口
    /// </summary>
    public interface ITemplateMessageBase
    {
        /// <summary>
        /// Url，为null时会自动忽略
        /// </summary>
        string TemplateId { get; set; }
        /// <summary>
        /// Url，为null时会自动忽略
        /// </summary>
        string Url { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        string TemplateName { get; set; }
    }

    /// <summary>
    /// 模板消息数据基础类
    /// </summary>
    public class TemplateMessageBase : ITemplateMessageBase
    {
        /// <summary>
        /// 每个公众号都不同的templateId
        /// </summary>
        public string TemplateId { get; set; }
        /// <summary>
        /// Url，为null时会自动忽略
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TemplateName { get; set; }

        public TemplateMessageBase(string templateId, string url, string templateName)
        {
            TemplateId = templateId;
            Url = url;
            TemplateName = templateName;
        }
    }
}
