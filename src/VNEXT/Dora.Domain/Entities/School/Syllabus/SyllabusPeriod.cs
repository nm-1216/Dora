//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PeriodAllot.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:51:29</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    using System;

    /// <summary>
    /// SyllabusPeriod 课程学时分配表
    /// </summary>
    public partial class SyllabusPeriod : BaseEntity
    {
        public SyllabusPeriod() : base()
        {
            this.SyllabusPeriodId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual string SyllabusPeriodId { get; set; }


        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }


        /// <summary>
        /// Gets or sets 单元序号
        /// </summary>
        public virtual int? UnitOrdNum { get; set; }


        /// <summary>
        /// Gets or sets 课程内容 
        /// </summary>
        public virtual string CouCon { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 讲授课时 
        /// </summary>
        public virtual decimal? TeaPer { get; set; }


        /// <summary>
        /// Gets or sets 实验课时 
        /// </summary>
        public virtual decimal? ExpPer { get; set; }



        public virtual Syllabus Syllabus { get; set; }

        #endregion

    }
}





