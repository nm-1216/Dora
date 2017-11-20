using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Infrastructure.Domains;
using Newtonsoft.Json;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 班级
    /// </summary>
    public class Class : BaseEntity
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
        /// 班级编号
        /// </summary>
        public string CourseId { get; set; }

        /// <summary>
        /// 课程
        /// </summary>
        [JsonIgnore]
        public virtual Course Course { get; set; }

        /// <summary>
        /// 课程包含学生
        /// </summary>
        public virtual ICollection<SchoolUserInClass> User { get; set; }

    }
}
