//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeachingPlan.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:55:22</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TeachingPlan 授课计划
    /// </summary>
    public partial class TeachingPlan: BaseEntity
    {
        public TeachingPlan() : base()
        {
            this.TeachingPlanId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 授课计划编号 
        /// </summary>
        public virtual string TeachingPlanId { get; set; }

        /// <summary>
        /// 教学任务ID
        /// </summary>
        public virtual string TeachingTaskId { get; set; }

        /// <summary>
        /// Gets or sets 课程信息表自增主键 
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// Gets or sets Term 学年 17-18-1,17-18-2
        /// </summary>
        public virtual string Term { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets SubTime 
        /// </summary>
        public virtual DateTime? SubTime { get; set; } 


        /// <summary>
        /// Gets or sets UseSta 在用    停用
        /// </summary>
        public virtual int? UseSta { get; set; } 


        /// <summary>
        /// Gets or sets SubSta 未提交    已提交
        /// </summary>
        public virtual int? SubSta { get; set; } 


        /// <summary>
        /// Gets or sets AudOrd 
        /// </summary>
        public virtual int? AudOrd { get; set; } 


        /// <summary>
        /// Gets or sets AudName 
        /// </summary>
        public virtual string AudName { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets AudRes 
        /// </summary>
        public virtual int? AudRes { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course1 Course { get; set; }

        public virtual ICollection<TeachingPlanTeacher> Teacher { get; set; }
        public virtual ICollection<TeachingPlanClass> Class { get; set; }
        public virtual ICollection<TeachingPlanApproval> TeachingPlanApprovals { get; set; }
        public virtual ICollection<TeachingPlanLog> TeachingPlanLogs { get; set; }
        public virtual ICollection<TeachingPlanDetail> TeachingPlanDetails { get; set; }


        #endregion

    }
}





