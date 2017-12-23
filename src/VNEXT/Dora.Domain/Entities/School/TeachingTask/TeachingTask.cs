//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeachingTask.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:55:33</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TeachingTask 教学任务
    /// </summary>
    public partial class TeachingTask : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 教学任务 
        /// </summary>
        public virtual string TeachingTaskId { get; set; }


        /// <summary>
        /// Gets or sets 课程信息表自增主键 
        /// </summary>
        public virtual string CourseId { get; set; }


        /// <summary>
        /// Gets or sets TIID 此授课计划对应的维护人员
        /// </summary>
        public virtual string TeacherId { get; set; }


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
        public virtual Course Course { get; set; }

        /// <summary>
        /// Gets or sets TIID 此授课计划对应的维护人员
        /// </summary>
        public virtual Teacher Teacher { get; set; }


        public virtual ICollection<TeachingTaskDetail> TeachingTaskDetails { get; set; }


        #endregion

    }
}





