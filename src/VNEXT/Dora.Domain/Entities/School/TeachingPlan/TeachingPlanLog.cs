//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaLogDet.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:56:01</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;


    /// <summary>
    /// TeaLogDet 教学日志明细表
    /// </summary>
    public partial class TeachingPlanLog : BaseEntity
    {
        public TeachingPlanLog() : base()
        {
            this.TeachingPlanLogId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual string TeachingPlanLogId { get; set; }


        /// <summary>
        /// Gets or sets 授课计划编号 
        /// </summary>
        public virtual string TeachingPlanId { get; set; }


        /// <summary>
        /// Gets or sets 授课序号 
        /// </summary>
        public virtual int? Order { get; set; }


        /// <summary>
        /// Gets or sets 授课教师 
        /// </summary>
        public virtual string Teacher { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 授课日期 
        /// </summary>
        public virtual string Date { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 授课节次 
        /// </summary>
        public virtual string Section { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 授课方式 
        /// </summary>
        public virtual string Mode { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 授课时数 
        /// </summary>
        public virtual decimal? Period { get; set; }


        /// <summary>
        /// Gets or sets 教学资源 
        /// </summary>
        public virtual string Assets { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 授课内容 
        /// </summary>
        public virtual string TeaCon { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 随堂测试 
        /// </summary>
        public virtual string Test { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 作业 
        /// </summary>
        public virtual string Job { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 实验实训 
        /// </summary>
        public virtual string PraTra { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 学生人数 
        /// </summary>
        public virtual int? StuNum { get; set; }


        /// <summary>
        /// Gets or sets 课时调整建议 
        /// </summary>
        public virtual string PerAdj { get; set; } = string.Empty;


        public virtual TeachingPlan TeachingPlan { get; set; }
        #endregion

    }
}





