﻿namespace Dora.Infrastructure.Domains
{
    using System;

    /// <summary>
    /// 基础模型
    /// </summary>
    public abstract class BaseEntity
    {
        //CreateUser, UpdateUser, CreateTime, UpdateTime, LastAction

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastAction { get; set; }

    }
}
