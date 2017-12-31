namespace Dora.Domain.Entities.School
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// 学校学生
    /// </summary>
    public class SchoolUser : IdentityUser
    {
        /// <summary>
        /// 学生类型
        /// </summary>
        public virtual SchoolUserType UserType { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        [MaxLength(256)]
        public virtual string WxOpenId { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        [MaxLength(256)]
        public virtual string WxName { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        [MaxLength(256)]
        public virtual string WxAvatar { get; set; }

        /// <summary>
        /// 用户的学生身份
        /// </summary>
        public virtual Student Student { get; set; }

        /// <summary>
        /// 用户的教师身份
        /// </summary>
        public virtual Teacher Teacher { get; set; }
    }
}
