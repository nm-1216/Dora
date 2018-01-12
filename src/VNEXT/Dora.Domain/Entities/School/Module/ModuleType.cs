//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="ModuleType.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:49:40</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// ModuleType 模块类别表
    /// </summary>
    public partial class ModuleType: BaseEntity
    {
        public ModuleType() : base()
        {
            this.ModuleTypeId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 模块类别表 
        /// </summary>
        public virtual string ModuleTypeId { get; set; }

        /// <summary>
        /// Gets or sets 名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Discription { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Index { get; set; } = 1;

        /// <summary>
        /// 模块
        /// </summary>
        public virtual ICollection<Module> Modules { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual ICollection<Permission> Permissions { get; set; }

        #endregion

    }
}





