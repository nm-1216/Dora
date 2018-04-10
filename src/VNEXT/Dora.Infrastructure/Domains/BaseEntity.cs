namespace Dora.Infrastructure.Domains
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// 基础模型
    /// </summary>
    public abstract class BaseEntity
    {
        //CreateUser, UpdateUser, CreateTime, UpdateTime, LastAction

        public BaseEntity()
        {
            CreateTime = UpdateTime = DateTime.Now;
            CreateUser = UpdateUser = string.Empty;
        }

        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }


        [NotMapped]
        public long CreateTimeTimeStamp {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);  
                return Convert.ToInt64((CreateTime.ToUniversalTime() - epoch).TotalMilliseconds);
            }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        
        [NotMapped]
        public long UpdateTimeTimeStamp {
            get
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);  
                return Convert.ToInt64((CreateTime.ToUniversalTime() - epoch).TotalMilliseconds);
            }
        }

    }
}
