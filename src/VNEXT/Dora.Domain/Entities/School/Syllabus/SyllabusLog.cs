//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaProMod.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:56:54</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;
    /// <summary>
    /// SyllabusLog 教学大纲修改记录
    /// </summary>
    public partial class SyllabusLog : BaseEntity
    {
        public SyllabusLog() : base()
        {
            this.SyllabusLogId = Guid.NewGuid().ToString();
        }


        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual string SyllabusLogId { get; set; }

        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }

        /// <summary>
        /// Gets or sets 描述备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        public virtual Syllabus Syllabus { get; set; }

        #endregion

    }
}





