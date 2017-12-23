//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraTraPlanDet.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:53:44</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;
    using Newtonsoft.Json;
    /// <summary>
    /// TrainingPlanDetail 实训计划明细表
    /// </summary>
    public partial class TrainingPlanDetail : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 实训计划明细表 
        /// </summary>
        public virtual long TrainingPlanDetailId { get; set; }

        /// <summary>
        /// Gets or sets 实训计划编号 
        /// </summary>
        public virtual string TrainingPlanId { get; set; }

        /// <summary>
        /// Gets or sets 实训项目 
        /// </summary>
        public virtual string TrainingProjectId { get; set; }

        /// <summary>
        /// Gets or sets 设备编号 
        /// </summary>
        public virtual string TrainingLabDeviceId { get; set; }

        /// <summary>
        /// Gets or sets 教师
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// Gets or sets 实训序号 
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        /// Gets or sets 实训方式 
        /// </summary>
        public virtual string Mode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 课时数 
        /// </summary>
        public virtual decimal? Period { get; set; }

        /// <summary>
        /// Gets or sets 实训内容 
        /// </summary>
        public virtual string TeaCon { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 实训资源 
        /// </summary>
        public virtual string Assets { get; set; } = string.Empty;

        public virtual TrainingPlan TrainingPlan { get; set; }

        /// <summary>
        /// Gets or sets 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// Gets or sets 实训项目 
        /// </summary>
        public virtual TrainingProject TrainingProject { get; set; }

        /// <summary>
        /// Gets or sets 设备编号 
        /// </summary>
        public virtual TrainingLabDevice TrainingLabDevice { get; set; }

        #endregion

    }
}





