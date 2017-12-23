//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="CoachRecord.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:47:47</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    /// <summary>
    /// CoachRecord 辅导记录
    /// </summary>
    public partial class CoachRecord: BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets 辅导记录 
        /// </summary>
        public virtual string CoachRecordId { get; set; }


        /// <summary>
        /// Gets or sets 教师信息表自增主键 
        /// </summary>
        public virtual string TeacherId { get; set; }


        /// <summary>
        /// Gets or sets 辅导日期 
        /// </summary>
        public virtual string Date { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 辅导时间 
        /// </summary>
        public virtual string Time { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 辅导地点 
        /// </summary>
        public virtual string Addr { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 辅导内容 
        /// </summary>
        public virtual string Content { get; set; } = string.Empty;

        /// <summary>
        /// 教师信息
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        #endregion
    }
}





