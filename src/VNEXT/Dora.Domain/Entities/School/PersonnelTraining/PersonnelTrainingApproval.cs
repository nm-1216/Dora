//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PerCulProAud.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:50:54</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// PersonnelTrainingApproval 专业人才培养方案审核记录表
    /// </summary>
    public partial class PersonnelTrainingApproval : BaseEntity
    {

        public PersonnelTrainingApproval() : base()
        {
            this.PersonnelTrainingApprovalId = Guid.NewGuid().ToString();
        }


        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual string PersonnelTrainingApprovalId { get; set; }

        /// <summary>
        /// Gets or sets 专业人才培养方案表
        /// </summary>
        public virtual string PersonnelTrainingId { get; set; }

        /// <summary>
        /// Gets or sets 审核次序 
        /// </summary>
        public virtual int AudOrd { get; set; }

        /// <summary>
        /// Gets or sets 审核名称 
        /// </summary>
        public virtual string AudName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 审核结果 
        /// </summary>
        public virtual int AudRes { get; set; }

        /// <summary>
        /// Gets or sets 备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        /// <summary>
        /// 附件
        /// </summary>
        public virtual string File { get; set; } = string.Empty;


        public virtual PersonnelTraining PersonnelTraining { get; set; }

        #endregion

    }
}





