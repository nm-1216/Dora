//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PerCulPro.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:50:38</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// PersonnelTraining 专业人才培养方案表
    /// </summary>
    public partial class PersonnelTraining : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 主键 
        /// </summary>
        public virtual string PersonnelTrainingId { get; set; }

        /// <summary>
        /// Gets or sets 所属专业(组织架构表) 
        /// </summary>
        [Display(Name = "专业")]
        [Required]
        public virtual string OrganizationId { get; set; }



        /// <summary>
        /// Gets or sets 学制 
        /// </summary>
        [Display(Name = "学制")]
        public virtual string LenOfSch { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 培养目标 
        /// </summary>
        public virtual string TraObj { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 毕业要求 
        /// </summary>
        public virtual string GraReq { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 就业岗位 
        /// </summary>
        public virtual string Post { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 课程设置和教学基本要求 
        /// </summary>
        public virtual string BasReq { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实施意见与说明 
        /// </summary>
        public virtual string OpiExp { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 招生对象 
        /// </summary>
        public virtual string EnrTar { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 录取年份 
        /// </summary>
        [Display(Name ="录取年份")]
        public virtual string Year { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 使用状态 
        /// </summary>
        [Required]
        public virtual BaseStatus Status { get; set; }


        /// <summary>
        /// Gets or sets 提交时间 
        /// </summary>
        public virtual DateTime? SubTime { get; set; }


        /// <summary>
        /// Gets or sets 培养方案文件路径 
        /// </summary>
        [Display(Name ="培养方案")]
        public virtual string CulProPath { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 审议会议纪要路径 
        /// </summary>
        [Display(Name = "审议会议纪要")]
        public virtual string MeeSumPath { get; set; } = string.Empty;


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
        #endregion

        public virtual ICollection<PersonnelTrainingLog> PersonnelTrainingLogs { get; set; }

        public virtual ICollection<PersonnelTrainingApproval> PersonnelTrainingApprovals { get; set; }

        /// <summary>
        /// 此班级所属的 专业 
        /// </summary>
        public virtual Organization Professional { get; set; }

    }
}





