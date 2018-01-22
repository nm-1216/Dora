namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;
    using Dora.Domain.Entities.Application;

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

        #region 主外键

        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }


        /// <summary>
        /// Gets or sets 课程信息表自增主键 
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// 分院---分配给系
        /// </summary>
        public virtual string OrganizationId { get; set; }

        /// <summary>
        /// 系----分配给教师
        /// </summary>
        public virtual string TeacherId { get; set; }

        #endregion

        #region property
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


        #endregion

        /// <summary>
        /// 版本
        /// </summary>
        public virtual string Version { get; set; }


        #region File
        /// <summary>
        /// Gets or sets 课程大纲文件路径 
        /// </summary>
        public virtual string TeaProPath { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 课程组讨论会议纪要路径 
        /// </summary>
        public virtual string MeeSumPath { get; set; } = string.Empty;
        #endregion


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
        /// 院系
        /// </summary>
        public virtual Organization Organization { get; set; }

        /// <summary>
        /// 编写老师
        /// </summary>
        public virtual Teacher Teacher { get; set; }

        /// <summary>
        /// 建议选用教材及教学参考资料
        /// </summary>
        public virtual ICollection<SyllabusBook> SyllabusBooks { get; set; }
        public virtual ICollection<SyllabusApproval> SyllabusApprovals { get; set; }
        public virtual ICollection<SyllabusLog> SyllabusLogs { get; set; }
        public virtual ICollection<SyllabusPeriod> SyllabusPeriods { get; set; }
        public virtual ICollection<SyllabusFirstCourse> SyllabusFirstCourse { get; set; }
        public virtual ICollection<SyllabusProfessional> SyllabusProfessional { get; set; }

        
        #endregion
    }
}





