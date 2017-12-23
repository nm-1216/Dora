//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PerCulProMod.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:51:11</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// PersonnelTrainingLog 专业人才培养方案修改记录表
    /// </summary>
    public partial class PersonnelTrainingLog : BaseEntity
    {
        public PersonnelTrainingLog() : base()
        {
            this.PersonnelTrainingLogId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 主键 
        /// </summary>
        public virtual string PersonnelTrainingLogId { get; set; }


        /// <summary>
        /// Gets or sets 专业人才培养方案表
        /// </summary>
        public virtual string PersonnelTrainingId { get; set; }


        /// <summary>
        /// Gets or sets 备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        public virtual PersonnelTraining PersonnelTraining { get; set; }


        #endregion

    }
}





