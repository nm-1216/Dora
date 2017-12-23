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
    /// TeaProMod 教学大纲审核记录
    /// </summary>
    public partial class SyllabusApproval : BaseEntity
    {
        public SyllabusApproval() : base()
        {
            this.SyllabusApprovalId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 教学大纲审核记录 
        /// </summary>
        public virtual string SyllabusApprovalId { get; set; }


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





