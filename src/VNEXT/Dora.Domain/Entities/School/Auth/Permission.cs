//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:51:49</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// Permission 权限
    /// </summary>
    public partial class Permission : BaseEntity
    {
        public Permission() : base()
        {
            this.PermissionId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 权限编号 
        /// </summary>
        public virtual string PermissionId { get; set; }

        /// <summary>
        /// Gets or sets 模块表Id 
        /// </summary>
        public virtual string ModuleId { get; set; }

        /// <summary>
        /// Gets or sets 角色 
        /// </summary>
        public virtual string RoleId { get; set; }

        /// <summary>
        /// Gets or sets 权限 
        /// </summary>
        public virtual int Authority { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public virtual Module Module { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual IdentityRole Role { get; set; }


        #endregion

    }
}





