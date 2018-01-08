//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:55:49</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TeaInfo 实体类
    /// </summary>
    public partial class Teacher: BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Code 
        /// </summary>
        public virtual string TeacherId { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets Name 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public virtual string IdCard { get; set; }

        /// <summary>
        /// Gets or sets JobTit 教师职称
        /// </summary>
        public virtual string JobTit { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 组织架构ID 所属部门
        /// </summary>
        public virtual string OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets Status 
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 组织架构ID 所属部门
        /// </summary>
        public virtual Organization Department { get; set; }

        /// <summary>
        /// 学校用户身份
        /// </summary>
        public virtual SchoolUser SchoolUser { get; set; }



        #endregion
    }
}





