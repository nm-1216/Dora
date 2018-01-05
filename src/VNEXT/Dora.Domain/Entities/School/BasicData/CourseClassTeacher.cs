
namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    public class CourseClassTeacher : BaseEntity
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// 班级编号
        /// </summary>
        public virtual string ClassId { get; set; }

        /// <summary>
        /// 教师编号
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// 学期学年
        /// </summary>
        public virtual string Term { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public virtual Class Class { get; set; }

        /// <summary>
        /// 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }
    }
}
