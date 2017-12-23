//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Dora.Infrastructure.Domains;
//using Newtonsoft.Json;

//namespace Dora.Domain.Entities.School
//{
//    /// <summary>
//    /// 学生与班级关系
//    /// </summary>
//    public class SchoolUserInClass:BaseEntity
//    {
//        /// <summary>
//        /// 班级编号
//        /// </summary>
//        public string ClassId { get; set; }

//        /// <summary>
//        /// 学生编号
//        /// </summary>
//        public string UserId { get; set; }

//        /// <summary>
//        /// 学生
//        /// </summary>
//        [JsonIgnore]
//        public virtual SchoolUser User { get; set; }

//        /// <summary>
//        /// 班级
//        /// </summary>
//        [JsonIgnore]
//        public virtual Class Class { get; set; }
//    }
//}
