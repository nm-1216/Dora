using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Infrastructure.Domains;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 课程专业关系表（多对多）
    /// </summary>
    public partial class CourseProfessional : BaseEntity
    {
        /// <summary>
        /// 课程编号
        /// </summary>
        public virtual string CourseId { get; set; }

        /// <summary>
        /// Gets or sets 专业 ProfessionalId 
        /// </summary>
        public virtual string ProfessionalId { get; set; }

        /// <summary>
        /// 课程编号
        /// </summary>
        public virtual Course Course  { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public virtual Professional Professional { get; set; }

    }
}
