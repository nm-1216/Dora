namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

	/// <summary>
	/// SyllabusTeacher 教师表（师资力量）
	/// </summary>
	public partial class SyllabusTeacher : BaseEntity
    {
        public SyllabusTeacher() : base()
        {

        }

        #region Public Properties

        /// <summary>
        /// Gets or sets Code 
        /// </summary>
        public virtual string TeacherId { get; set; }

        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }

        /// <summary>
        /// 教学大纲
        /// </summary>
        public virtual Syllabus Syllabus { get; set; }

        /// <summary>
        /// 教师
        /// </summary>
        public virtual Teacher Teacher { get; set; }


        #endregion

    }
}





