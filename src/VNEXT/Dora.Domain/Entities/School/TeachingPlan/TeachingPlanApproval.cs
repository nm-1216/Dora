//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaPlanAud.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:56:13</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TeaPlanAud 授课计划审核记录表
    /// </summary>
    public partial class TeachingPlanApproval : BaseEntity
    {
        public TeachingPlanApproval() : base()
        {
            this.TeachingPlanApprovalId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 授课计划审核记录 
        /// </summary>
        public virtual string TeachingPlanApprovalId { get; set; }

        /// <summary>
        /// Gets or sets 授课计划编号 
        /// </summary>
        public virtual string TeachingPlanId { get; set; }

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
        /// Gets or sets 审核人 
        /// </summary>
        public virtual string User { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 审核时间 
        /// </summary>
        public virtual DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets 备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        public virtual TeachingPlan TeachingPlan { get; set; }

        #endregion

    }
}





