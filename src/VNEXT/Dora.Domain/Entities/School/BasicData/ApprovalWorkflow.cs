//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="AuditConfigInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:46:33</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// 审批工作流
    /// </summary>
    public partial class ApprovalWorkflow: BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets ID 
        /// </summary>
        public virtual string ApprovalWorkflowId { get; set; } 


        /// <summary>
        /// Gets or sets Type 1=专业人才培养方案    2=课程大纲
        /// </summary>
        public virtual ApprovalWorkflowType Type { get; set; }


        /// <summary>
        /// Gets or sets 组织架构ID 所属部门
        /// </summary>
        public virtual string OrganizationId { get; set; }


        /// <summary>
        /// Gets or sets 角色 
        /// </summary>
        public virtual string RoleId { get; set; } 


        /// <summary>
        /// Gets or sets Order 描述审核的次序，次序为1的角色先审核，审核通过后再流转到次序为2的角色审核，一次类推
        /// </summary>
        public virtual int Order { get; set; } 


        /// <summary>
        /// Gets or sets Name 如：系主任审核、分院审查、教务处审查等文字描述
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets Status 
        /// </summary>
        public virtual int Status { get; set; } 

        /// <summary>
        /// Gets or sets Memo 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;


        /// <summary>
        /// 组织架构ID 所属部门
        /// </summary>
        public virtual Organization Department { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public virtual IdentityRole Role { get; set; }
        #endregion


    }
}





