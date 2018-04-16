namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class TimeCard : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual string TimeCardId { get; set; }
        
        /// <summary>
        /// 批次
        /// </summary>
        public virtual string Batch { get; set; }
        
        /// <summary>
        /// 时间戳
        /// </summary>
        public virtual long Time { get; set; }
        
        /// <summary>
        /// 教学任务
        /// </summary>
        public virtual string TeachingTaskId { get; set; }
        
        /// <summary>
        /// 学生
        /// </summary>
        public virtual string StudentId { get; set; }
    }
}