using System.ComponentModel.DataAnnotations.Schema;

namespace Dora.Infrastructure.Domains
{
    using System;

    /// <summary>
    /// 基础模型
    /// </summary>
    public abstract class BaseEntity
    {
        //CreateUser, UpdateUser, CreateTime, UpdateTime, LastAction

        public BaseEntity()
        {
            this.CreateTime = this.UpdateTime = DateTime.Now;
            this.CreateUser = this.UpdateUser = string.Empty;
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
                if (CreateTime != null)
                {
                    System.DateTime startTime =
                        TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (CreateTime.Ticks - startTime.Ticks) / 10000;
                    return t;
                }
                else
                {
                    return 0;
                }
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
                if (UpdateTime != null)
                {
                    System.DateTime startTime =
                        TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
                    long t = (UpdateTime.Ticks - startTime.Ticks) / 10000;
                    return t;
                }
                else
                {
                    return 0;
                }
                
            }
        }

    }
}
