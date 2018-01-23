namespace Dora.Domain.Entities.School
{
    using System;
    using Dora.Infrastructure.Domains;

    /// <summary>
    /// TextbookInfo 建议选用教材及教学参考资料
    /// </summary>
    public partial class SyllabusBook : BaseEntity
    {
        public SyllabusBook() : base()
        {
            this.SyllabusBookId = Guid.NewGuid().ToString();
        }

        #region Public Properties

        /// <summary>
        /// Gets or sets 建议选用教材及教学参考资料 
        /// </summary>
        public virtual string SyllabusBookId { get; set; }


        /// <summary>
        /// Gets or sets 教学大纲编号 
        /// </summary>
        public virtual string SyllabusId { get; set; }


        /// <summary>
        /// Gets or sets 教材名称 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 编著者 
        /// </summary>
        public virtual string Compiler { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 版次 
        /// </summary>
        public virtual string Edition { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 出版社 
        /// </summary>
        public virtual string Press { get; set; } = string.Empty;


        /// <summary>
        /// Gets or sets 出版时间 
        /// </summary>
        public virtual DateTime PreTime { get; set; }

        /// <summary>
        /// 教学大纲
        /// </summary>
        public virtual Syllabus Syllabus { get; set; }


        #endregion

    }
}





