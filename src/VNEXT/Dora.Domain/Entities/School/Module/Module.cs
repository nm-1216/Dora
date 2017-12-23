//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:49:21</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;


    /// <summary>
    /// ModuleInfo 模块
    /// </summary>
    public partial class Module: BaseEntity
    {

        public Module() : base()
        {
            this.ModuleId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 模块表Id 
        /// </summary>
        public virtual string ModuleId { get; set; }

        /// <summary>
        /// Gets or sets 模块类别表 
        /// </summary>
        public virtual string ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets 名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// 图标
        /// </summary>
        public virtual string Ico { get; set; } = string.Empty;

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string Url { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Module_Status
        /// </summary>
        public virtual BaseStatus Status { get; set; }

        /// <summary>
        /// 模块类别表
        /// </summary>
        public virtual ModuleType ModuleType { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual ICollection<Permission> Permissions { get; set; }
        #endregion

    }
}





