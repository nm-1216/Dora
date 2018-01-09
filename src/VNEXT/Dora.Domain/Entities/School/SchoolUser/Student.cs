namespace Dora.Domain.Entities.School
{
    using Dora.Infrastructure.Domains;
    /// <summary>
    /// 学生
    /// </summary>
    public partial class Student : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets Code 
        /// </summary>
        public virtual string StudentId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Name 
        /// </summary>
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// 身份证
        /// </summary>
        public virtual string IdCard { get; set; }

        /// <summary>
        /// 班级编号
        /// </summary>
        public virtual string ClassId { get; set; }

        /// <summary>
        /// Gets or sets Status 在读    休学     等
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public virtual int Sex { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public virtual Class Class { get; set; }

        /// <summary>
        /// 学校用户身份
        /// </summary>
        public virtual SchoolUser SchoolUser { get; set; }

        #endregion

    }
}





