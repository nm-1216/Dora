//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="OrgStrSon.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:50:21</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    /// <summary>
    /// OrgStrSon 实体类relationship
    /// </summary>
    public partial class OrganizationRelationship : BaseEntity
    {

        public OrganizationRelationship(string selfId, string sonId) : base()
        {
            this.SelfId = selfId;
            this.SonId = sonId;
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 组织架构ID 
        /// </summary>
        public virtual string SelfId { get; set; }

        /// <summary>
        /// Gets or sets 组织架构ID 
        /// </summary>
        public virtual string SonId { get; set; }

        /// <summary>
        /// Gets or sets Status 在用    停用
        /// </summary>
        public virtual BaseStatus Status { get; set; }


        public virtual Organization Self { get; set; }

        public virtual Organization Son { get; set; }


        #endregion

    }
}





