//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraTraPlan.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:53:05</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// 实训计划
    /// </summary>
    public partial class TrainingPlan : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 实训计划编号 
        /// </summary>
        public virtual string TrainingPlanId { get; set; }


        /// <summary>
        /// Gets or sets 班级
        /// </summary>
        public virtual string ClassId { get; set; }


        /// <summary>
        /// Gets or sets 课程
        /// </summary>
        public virtual string CourseId { get; set; }


        /// <summary>
        /// Gets or sets 教师
        /// </summary>
        public virtual string TeacherId { get; set; }


        /// <summary>
        /// Gets or sets 学期 
        /// </summary>
        public virtual string Term { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 使用状态
        /// </summary>
        public virtual int? UseSta { get; set; }


        /// <summary>
        /// Gets or sets 提交时间 
        /// </summary>
        public virtual DateTime? SubTime { get; set; }


        /// <summary>
        /// Gets or sets 提交状态
        /// </summary>
        public virtual int? SubSta { get; set; }


        /// <summary>
        /// Gets or sets 审核次序 
        /// </summary>
        public virtual int? AudOrd { get; set; }


        /// <summary>
        /// Gets or sets 审核名称 
        /// </summary>
        public virtual string AudName { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 审核结果 
        /// </summary>
        public virtual int? AudRes { get; set; }


        /// <summary>
        /// Gets or sets 班级
        /// </summary>
        public virtual Class Class { get; set; }

        /// <summary>
        /// Gets or sets 课程
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// Gets or sets 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<TrainingPlanApproval> TrainingPlanApprovals { get; set; }

        public virtual ICollection<TrainingPlanDetail> TrainingPlanDetails { get; set; }

        public virtual ICollection<TrainingPlanLog> TrainingPlanLogs { get; set; }


        #endregion

    }
}





