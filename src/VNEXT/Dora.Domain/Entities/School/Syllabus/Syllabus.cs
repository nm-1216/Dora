//----------------------------------------------------------------------------------------------------------------------------
// <copyright file="TeaProInfo.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2017/12/19 23:56:45</datetime>
// <discription>
// </discription>
//----------------------------------------------------------------------------------------------------------------------------

namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// Syllabus 教学大纲
    /// </summary>
    public partial class Syllabus : BaseEntity
    {
        public Syllabus() : base()
        {
            this.SyllabusId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }

        /// <summary>
        /// Gets or sets 课程信息表自增主键 
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// Gets or sets 先修课程代码一 
        /// </summary>
        public virtual string BefCouCode1 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程名称一 
        /// </summary>
        public virtual string BefCouName1 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程代码二 
        /// </summary>
        public virtual string BefCouCode2 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程名称二 
        /// </summary>
        public virtual string BefCouName2 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程代码三 
        /// </summary>
        public virtual string BefCouCode3 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程名称三 
        /// </summary>
        public virtual string BefCouName3 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程代码四 
        /// </summary>
        public virtual string BefCouCode4 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程名称四
        /// </summary>
        public virtual string BefCouName4 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程代码五 
        /// </summary>
        public virtual string BefCouCode5 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 先修课程名称五
        /// </summary>
        public virtual string BefCouName5 { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 教学目标 
        /// </summary>
        public virtual string Tar { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 教学内容及要求 
        /// </summary>
        public virtual string ConReq { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 课程实践教学内容 
        /// </summary>
        public virtual string PraCon { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 课程评价方法 
        /// </summary>
        public virtual string EvaWay { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 教学方法建议 
        /// </summary>
        public virtual string Pro { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets 提交时间 
        /// </summary>
        public virtual DateTime? SubTime { get; set; }


        /// <summary>
        /// Gets or sets 课程大纲文件路径 
        /// </summary>
        public virtual string TeaProPath { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 课程组讨论会议纪要路径 
        /// </summary>
        public virtual string MeeSumPath { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 使用状态 
        /// </summary>
        public virtual int? UseSta { get; set; }


        /// <summary>
        /// Gets or sets 提交状态 
        /// </summary>
        public virtual int? SubSta { get; set; }


        /// <summary>
        /// Gets or sets 审核次序 
        /// </summary>
        public virtual int? AudOrd { get; set; }


        /// <summary>
        /// Gets or sets 审核名称 
        /// </summary>
        public virtual string AudName { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 审核结果 
        /// </summary>
        public virtual int? AudRes { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course Course { get; set; }

        /// <summary>
        /// 建议选用教材及教学参考资料
        /// </summary>
        public virtual ICollection<SyllabusBook> SyllabusBooks { get; set; }
        public virtual ICollection<SyllabusApproval> SyllabusApprovals { get; set; }
        public virtual ICollection<SyllabusLog> SyllabusLogs { get; set; }
        public virtual ICollection<SyllabusPeriod> SyllabusPeriods { get; set; }



        #endregion

    }
}





