namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

	/// <summary>
	/// SyllabusFirstCourse 先修课程
	/// </summary>
	public partial class SyllabusFirstCourse : BaseEntity
    {
        public SyllabusFirstCourse() : base()
        {

        }

        #region Public Properties

        /// <summary>
        /// 课程编号
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }

        /// <summary>
        /// 教学大纲
        /// </summary>
        public virtual Syllabus Syllabus { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        public virtual Course1 Course { get; set; }


        #endregion

    }
}





