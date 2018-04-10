namespace Dora.Domain.Entities.School
{
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;
    using System;

    /// <summary>
    /// TeachingTask 教学任务
    /// </summary>
    public partial class TeachingTask : BaseEntity
    {
        public TeachingTask():base()
        {
            TeachingTaskId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 教学任务 
        /// </summary>
        public virtual string TeachingTaskId { get; set; }

        /// <summary>
        /// Gets or sets 学期 
        /// </summary>
        public virtual string Term { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 开始周次
        /// </summary>
        public virtual int? BegWeek { get; set; }

        /// <summary>
        /// Gets or sets 结束周次 
        /// </summary>
        public virtual int? EndWeek { get; set; }

        /// <summary>
        /// Gets or sets 备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        /// <summary>
        /// 课程
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// 是否下发，推送
        /// </summary>
        public virtual bool IsPush { get; set; } = false;
        
        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course1 Course { get; set; }
        
        /// <summary>
        /// 班级
        /// </summary>
        public virtual ICollection<TeachingTaskClass> Classes { get; set; }

        /// <summary>
        /// Gets or sets TIID 此授课计划对应的维护人员
        /// </summary>
        public virtual ICollection<TeachingTaskTeacher> Teachers { get; set; }

        /// <summary>
        /// 明细
        /// </summary>
        public virtual ICollection<TeachingTaskDetail> TeachingTaskDetails { get; set; }

        #endregion

    }
}





