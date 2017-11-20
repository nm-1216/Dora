using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Infrastructure.Domains;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course : BaseEntity
    {
        public Course() : base()
        {
            this.CourseId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 课程编号
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// 课程名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 课程下班级
        /// </summary>
        public virtual ICollection<Class> Classes { get; set; }
    }
}
