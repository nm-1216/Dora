//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraTraDet.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:52:27</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    /// <summary>
    /// PraTraDet 实训日志明细表
    /// </summary>
    public partial class TrainingPlanLog : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 实训日志明细表 
        /// </summary>
        public virtual string TrainingPlanLogId { get; set; }


        /// <summary>
        /// Gets or sets 实训计划编号 
        /// </summary>
        public virtual string TrainingPlanId { get; set; }

        /// <summary>
        /// Gets or sets 设备编号 
        /// </summary>
        public virtual string TrainingLabDeviceId { get; set; }

        /// <summary>
        /// Gets or sets 教师
        /// </summary>
        public virtual string TeacherId { get; set; }


        /// <summary>
        /// Gets or sets 实训室基本信息表实训室编号 
        /// </summary>
        public virtual string TrainingLabId { get; set; }


        /// <summary>
        /// Gets or sets 实训序号 
        /// </summary>
        public virtual int? Order { get; set; }


        /// <summary>
        /// Gets or sets 实训日期 
        /// </summary>
        public virtual string Date { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实训节次 
        /// </summary>
        public virtual string Section { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实训方式 
        /// </summary>
        public virtual string Mode { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实训时数 
        /// </summary>
        public virtual decimal? Period { get; set; }


        /// <summary>
        /// Gets or sets 实训资源 
        /// </summary>
        public virtual string Assets { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实训内容 
        /// </summary>
        public virtual string TeaCon { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 学生人数 
        /// </summary>
        public virtual int? StuNum { get; set; }


        /// <summary>
        /// Gets or sets 实训调整建议 
        /// </summary>
        public virtual string AdjSug { get; set; } = string.Empty;

        public virtual TrainingPlan TrainingPlan { get; set; }

        /// <summary>
        /// Gets or sets 设备编号 
        /// </summary>
        public virtual TrainingLabDevice TrainingLabDevice { get; set; }

        /// <summary>
        /// Gets or sets 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }


        /// <summary>
        /// Gets or sets 实训室基本信息表实训室编号 
        /// </summary>
        public virtual TrainingLab TrainingLab { get; set; }
        #endregion

    }
}





