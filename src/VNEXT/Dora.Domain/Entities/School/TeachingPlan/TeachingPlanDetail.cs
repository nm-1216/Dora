//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaPlanDet.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:56:24</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TeaPlanDet 授课计划明细表
    /// </summary>
    public partial class TeachingPlanDetail : BaseEntity
    {
        public TeachingPlanDetail() : base()
        {
            this.TeachingPlanDetailId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual string TeachingPlanDetailId { get; set; }


        /// <summary>
        /// Gets or sets 授课计划编号 
        /// </summary>
        public virtual string TeachingPlanId { get; set; }


        ///// <summary>
        ///// Gets or sets TIID 对应的授课教师
        ///// </summary>
        //public virtual string TeacherId { get; set; }


        /// <summary>
        /// Gets or sets Order 授课序号
        /// </summary>
        public virtual int? Order { get; set; }


        /// <summary>
        /// Gets or sets Mode 授课方式
        /// </summary>
        public virtual string Mode { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 课时数 
        /// </summary>
        public virtual decimal? Period { get; set; }


        /// <summary>
        /// Gets or sets 教学内容 
        /// </summary>
        public virtual string TeaCon { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets Assets 教学资源
        /// </summary>
        public virtual string Assets { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 是否随堂测试
        /// </summary>
        public virtual YesOrNo Test { get; set; }


        /// <summary>
        /// Gets or sets 作业 
        /// </summary>
        public virtual string Job { get; set; } = string.Empty;

        public virtual TeachingPlan TeachingPlan { get; set; }
        public virtual string Teacher { get; set; }
        #endregion

    }
}





