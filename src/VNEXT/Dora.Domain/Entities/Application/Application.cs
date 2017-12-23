////----------------------------------------------------------------------------------------------------------------------------
//// <copyright file="Applications.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
//// <author>Craze</author>
//// <datetime>2015/12/20 20:42:33</datetime>
//// <discription>
//// </discription>
////----------------------------------------------------------------------------------------------------------------------------

//namespace Dora.Domain.Entities.Application
//{
//    using System;
//    using System.Collections.Generic;
//    using Infrastructure.Domains;

//    public class Application : Application<string>
//    {
//        public Application()
//        {
//            ApplicationId = Guid.NewGuid().ToString();
//        }

//        public Application(string applicationName, string description) : this()
//        {
//            this.ApplicationName = applicationName;
//            this.Description = description;
//        }
//    }

//    /// <summary>
//    /// Applications 实体类
//    /// </summary>
//    public partial class Application<TKey> : BaseEntity where TKey : IEquatable<TKey>
//    {
//        #region Public Properties

//        /// <summary>
//        /// Gets or sets ApplicationId 
//        /// </summary>
//        public virtual TKey ApplicationId { get; set; }


//        /// <summary>
//        /// Gets or sets ApplicationName 
//        /// </summary>
//        public virtual string ApplicationName { get; set; }


//        /// <summary>
//        /// Gets or sets Description 
//        /// </summary>
//        public virtual string Description { get; set; }


//        public virtual int OrderBy { get; set; }
//        #endregion

//        #region virtual
//        public virtual ICollection<Action<TKey>> Actions { get; set; }
//        #endregion
//    }
//}