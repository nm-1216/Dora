//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PraTraPro.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:54:01</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TrainingProject 实训项目
    /// </summary>
    public partial class TrainingProject : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets 实训项目 
        /// </summary>
        public virtual string TrainingProjectId { get; set; }

        /// <summary>
        /// Gets or sets 项目名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 项目内容 
        /// </summary>
        public virtual string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 所属基地 
        /// </summary>
        public virtual string Base { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 所属实训中心 
        /// </summary>
        public virtual string Center { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 当前使用状态 
        /// </summary>
        public virtual BaseStatus Status { get; set; } 

        #endregion
    }
}





