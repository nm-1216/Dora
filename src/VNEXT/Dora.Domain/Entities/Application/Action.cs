//namespace Dora.Domain.Entities.Application
//{
//    using System.Collections.Generic;
//    using global::System;
//    using Infrastructure.Domains;

//    public partial class Action : Action<string>
//    {
//        public Action()
//        {
//            this.ActionId = Guid.NewGuid().ToString();
//        }

//        public Action(string name, string parentId, string description) : this()
//        {
//            this.ActionName = name;
//            this.Description = description;
//            this.ParentId = parentId;
//        }

//    }

//    /// <summary>
//    /// Actions 实体类
//    /// </summary>
//    public partial class Action<TKey>: BaseEntity where TKey : IEquatable<TKey>
//    {
//        #region Public Properties

//        /// <summary>
//        /// Gets or sets ActionId 
//        /// </summary>
//        public virtual TKey ActionId { get; set; }


//        /// <summary>
//        /// Gets or sets ActionName 
//        /// </summary>
//        public virtual string ActionName { get; set; }

//        public virtual string ActionCategory { get; set; }

//        /// <summary>
//        /// Gets or sets PathId 
//        /// </summary>
//        public virtual TKey ParentId { get; set; }

//        public virtual TKey ApplicationId { get; set; }

//        /// <summary>
//        /// Gets or sets Description 
//        /// </summary>
//        public virtual string Description { get; set; }

//        public virtual ICollection<Action<TKey>> Childs { get; set; }

//        public virtual ICollection<ActionInRole<TKey>> Roles { get; set; }

//        #endregion
//    }
//}





