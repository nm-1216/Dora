//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraTraPlanAud.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:53:25</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// PraTraPlanAud 实训计划审核记录表
    /// </summary>
    public partial class TrainingPlanApproval : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets 实训计划审核记录表 
        /// </summary>
        public virtual string TrainingPlanApprovalId { get; set; }

        /// <summary>
        /// Gets or sets 实训计划编号 
        /// </summary>
        public virtual string TrainingPlanId { get; set; }

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
        public virtual DateTime? Time { get; set; }

        /// <summary>
        /// Gets or sets 审核备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        public virtual TrainingPlan TrainingPlan { get; set; }

        #endregion

    }
}





