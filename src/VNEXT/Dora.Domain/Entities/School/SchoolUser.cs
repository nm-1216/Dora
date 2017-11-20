using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Infrastructure.Domains;

namespace Dora.Domain.Entities.School
{
    /// <summary>
    /// 学校学生
    /// </summary>
    public class SchoolUser : BaseEntity
    {
        public SchoolUser()
        {
            this.UserId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 学生编号
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 学生类型
        /// </summary>
        public SchoolUserType UserType { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string WxOpenId { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WxName { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        public string WxAvatar { get; set; }

        /// <summary>
        /// 学生加入的班级
        /// </summary>
        public virtual ICollection<SchoolUserInClass> Classes { get; set; }
    }
}
