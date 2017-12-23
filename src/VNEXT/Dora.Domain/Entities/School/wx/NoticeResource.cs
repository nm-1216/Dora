using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dora.Domain.Entities.School
{
    
    public class NoticeResource
    {
        /// <summary>
        /// 资源编号
        /// </summary>
        public string ResourceId { get; set; }

        /// <summary>
        /// 公告编号
        /// </summary>
        public string NoticeId { get; set; }
    }
}
