//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="CouSpeInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:48:29</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// Professional 专业
    /// </summary>
    public partial class Professional : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets 专业 ProfessionalId 
        /// </summary>
        public virtual string ProfessionalId { get; set; } 

        /// <summary>
        /// Gets or sets 专业名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Status 
        /// </summary>
        public virtual BaseStatus Status { get; set; }


        public virtual ICollection<CourseProfessional> CourseProfessionals { get; set; }

        #endregion
    }
}





