namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class Courseware : BaseEntity
    {
        /// <summary>
        /// 学习日志id
        /// </summary>
        public virtual string CoursewareId { get; set; }

        /// <summary>
        /// 教师
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }
    }
}
