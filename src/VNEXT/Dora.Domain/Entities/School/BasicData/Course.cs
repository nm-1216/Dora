namespace Dora.Domain.Entities.School
{
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// 课程
    /// </summary>
    public partial class Course : BaseEntity
    {
        public Course(string code) : base()
        {
            this.CourseId = code;
        }

        /// <summary>
        /// 课程编号
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// 课程名字
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets 适用层次 
        /// </summary>
        public virtual string AppLev { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 学分数 
        /// </summary>
        public virtual decimal? Credit { get; set; }

        /// <summary>
        /// Gets or sets 学时数 
        /// </summary>
        public virtual decimal? Period { get; set; }

        /// <summary>
        /// Gets or sets 课程性质 专业课    非专业课
        /// </summary>
        public virtual string CouNat { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 课程类别 理论课    理论+实践 课
        /// </summary>
        public virtual string CouType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 课程简介 
        /// </summary>
        public virtual string CouAbs { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 组织架构ID 所属部门
        /// </summary>
        public virtual string OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets Status 
        /// </summary>
        public virtual BaseStatus Status { get; set; }

        /// <summary>
        /// 组织架构ID 所属部门
        /// </summary>
        public virtual Organization Department { get; set; }

        /// <summary>
        /// 班级课程教师
        /// </summary>
        public virtual ICollection<CourseClassTeacher> CourseClassTeachers { get; set; }

        /// <summary>
        /// 课程专业
        /// </summary>
        public virtual ICollection<CourseProfessional> CourseProfessionals { get; set; }

        /// <summary>
        /// 课程专业
        /// </summary>
        public virtual ICollection<Syllabus> Syllabuss { get; set; }

        /// <summary>
        /// 授课计划
        /// </summary>
        public virtual ICollection<TeachingPlan> TeachingPlans { get; set; }

    }
}
