//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgStrInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:49:58</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;


    /// <summary>
    /// Organization 组织架构
    /// </summary>
    public partial class Organization : BaseEntity
    {

        public Organization() : base()
        {
            this.OrganizationId = Guid.NewGuid().ToString();
        }

        public Organization(string code) : base()
        {
            this.OrganizationId = code;
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 组织架构ID 
        /// </summary>
        public virtual string OrganizationId { get; set; } 

        /// <summary>
        /// Gets or sets Name 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// 1=教务处2=教学部门3=系4=专业
        /// </summary>
        public virtual OrganizationType Type { get; set; }

        /// <summary>
        /// Gets or sets Status 在用    停用
        /// </summary>
        public virtual BaseStatus Status { get; set; } 

        #endregion

    }
}





