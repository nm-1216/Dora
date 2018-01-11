
namespace Dora.Domain.Entities.School
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class SchoolRole : IdentityRole
    {
        public SchoolRole() : base() { }

        public SchoolRole(string roleName) : base(roleName) { }

        /// <summary>
        /// 排序用的索引
        /// </summary>
        public virtual int index { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual ICollection<Permission> Permissions { get; set; }

    }
}
