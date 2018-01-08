//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="Groups.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2015/12/20 20:47:17</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.Application
{
    using System;
    using System.Collections.Generic;
    using Infrastructure.Domains;

    public class Group : Group<string>
    {
        public Group()
        {
            this.GroupId = Guid.NewGuid().ToString();
        }

        public Group(string groupName, string description, string parentId) : this()
        {
            this.GroupId = groupName;
            this.Description = description;
            this.ParentId = parentId;
        }
    }

    /// <summary>
    /// Groups 实体类
    /// </summary>
    public partial class Group<TKey> : BaseEntity where TKey : IEquatable<TKey>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets GroupId 
        /// </summary>
        public virtual TKey GroupId { get; set; }

        /// <summary>
        /// Gets or sets GroupName 
        /// </summary>
        public virtual string GroupName { get; set; }

        /// <summary>
        /// Gets or sets Description 
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets or sets ParentId 
        /// </summary>
        public virtual TKey ParentId { get; set; }

        #endregion

        public virtual Group<TKey> Parent { get; set; }

        public virtual ICollection<Group<TKey>> Childs { get; set; }

    }
}





