namespace Dora.Domain.Entities.School
{
    using System;
    using System.Collections.Generic;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// 班级
    /// </summary>
    public partial class Class : BaseEntity
    {
        public Class() : base()
        {
            this.ClassId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 班级编号
        /// </summary>
        public string ClassId { get; set; }

        /// <summary>
        /// 班级名称 默认是编辑编号
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邀请码
        /// </summary>
        public string InviteCode { get; set; }

        /// <summary>
        /// Gets or sets 组织架构父表自增主键 此班级所属的 系 
        /// </summary>
        public virtual string DepID { get; set; }

        /// <summary>
        /// Gets or sets 组织架构父表自增主键 班级所属的专业 
        /// </summary>
        public virtual string SpeID { get; set; }

        /// <summary>
        /// Gets or sets 专业人才培养 
        /// </summary>
        public virtual string PersonnelTrainingId { get; set; }

        /// <summary>
        /// Gets or sets Status 在用    停用
        /// </summary>
        public virtual BaseStatus Status { get; set; }

        /// <summary>
        /// 此班级所属的 系
        /// </summary>
        public virtual Organization Department { get; set; }

        /// <summary>
        /// 此班级所属的 专业 
        /// </summary>
        public virtual Organization Professional { get; set; }

        /// <summary>
        /// 专业人才培养方案
        /// </summary>
        public virtual PersonnelTraining PersonnelTraining { get; set; }

        /// <summary>
        /// 学生
        /// </summary>
        public virtual ICollection<Student> Students { get; set; }

        

        /// <summary>
        /// 教学大纲
        /// </summary>
        public virtual ICollection<Syllabus> Syllabus { get; set; }

    }
}
