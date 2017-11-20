using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Infrastructure.Domains;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 年级
    /// </summary>
    public class Grade:BaseEntity
    {
        public string GradeId { get; set; }
        public string Name { get; set; }
    }
}
