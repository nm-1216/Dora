//namespace Dora.Domain.Entities.Application
//{
//    using System;
//    using Infrastructure.Domains;

//    public class LoginLog : LoginLog<string>
//    {
//        public LoginLog()
//        {
//            this.Id = Guid.NewGuid().ToString();
//            this.AddTime = DateTime.Now;
//        }

//        public LoginLog(string userId, string ip, string description)
//        {
//            this.UserId = userId;
//            this.IP = ip;
//            this.Description = description;
//        }
//    }

//    public class LoginLog<TKey> : BaseEntity where TKey : IEquatable<TKey>
//    {
//        public virtual TKey Id { get; set; }

//        public virtual DateTime AddTime { get; set; }

//        public virtual string IP { get; set; }

//        public virtual string Description { get; set; }

//        public virtual string UserId { get; set; }

//        public virtual ApplicationUser ApplicationUser { get; set; }
//    }
//}
