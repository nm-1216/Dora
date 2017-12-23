//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaTaskDet.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:57:16</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TeaTaskDet 教学任务明细表
    /// </summary>
    public partial class TeachingTaskDetail : BaseEntity
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets 教学任务明细表 
        /// </summary>
        public virtual long TeachingTaskDetailId { get; set; }

        /// <summary>
        /// Gets or sets 教学任务 
        /// </summary>
        public virtual string TeachingTaskId { get; set; }

        /// <summary>
        /// Gets or sets 班级 
        /// </summary>
        public virtual string ClassId { get; set; }

        /// <summary>
        /// Gets or sets 教室编号 
        /// </summary>
        public virtual string ClaRoomCode { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 星期
        /// </summary>
        public virtual string Week { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 上课节次  1:表示1，2节课，2：表示3，4节课，7表示：1，2，3，4节课，8：表示5678节课
        /// </summary>
        public virtual SectionType Section { get; set; }

        /// <summary>
        /// Gets or sets 备注 
        /// </summary>
        public virtual string Memo { get; set; } = string.Empty;

        public virtual TeachingTask TeachingTask { get; set; }

        #endregion

    }
}





