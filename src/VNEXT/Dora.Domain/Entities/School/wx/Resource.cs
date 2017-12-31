using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 资源
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// 资源编号
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// 资源地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 资源类型
        /// </summary>
        public virtual ResourceType ResourceType { get; set; }

    }
}
