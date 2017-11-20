using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Infrastructure.Domains;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 公告
    /// </summary>
    public class Notice:BaseEntity
    {
        /// <summary>
        /// 公告编号
        /// </summary>
        public string NoticeId{ get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
    }
}
