﻿namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// 公告
    /// </summary>
    public class Notice : BaseEntity
    {
        /// <summary>
        /// 公告编号
        /// </summary>
        public string NoticeId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public virtual Teacher Teacher { get; set; }
    }
}
