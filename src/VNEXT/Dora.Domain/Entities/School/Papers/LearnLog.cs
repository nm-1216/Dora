namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class LearnLog: BaseEntity
    {
        /// <summary>
        /// 学习日志id
        /// </summary>
        public virtual string LearnLogId { get; set; }


        /// <summary>
        /// 日志类别
        /// </summary>
        public virtual int Types { get; set; } = 0;
        
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }
        
        /// <summary>
        /// 对象id
        /// </summary>
        public virtual string ObjectId { get; set; }
        
        
        /// <summary>
        /// 班级id
        /// </summary>
        public virtual string ClassId { get; set; }


        /// <summary>
        /// 课程id
        /// </summary>
        public virtual string CourseId { get; set; }



    }
}