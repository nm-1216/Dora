
//namespace Dora.Domain.Entities.Application
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//    using static Constants;

//    // Add profile data for application users by adding properties to the ApplicationUser class
//    public class ApplicationUser : IdentityUser
//    {
//        //#region 用户帐号
//        //public virtual UserType UserType { get; set; }

//        //public virtual string LockIp { get; set; }
//        //#endregion

//        //#region 用户资料
//        //public virtual byte[] Photo { get; set; }

//        //[MaxLength(64)]
//        //public virtual string Cname { get; set; }

//        //[MaxLength(64)]
//        //public virtual string Ename { get; set; }

//        //[MaxLength(64)]
//        //public virtual string IDCard { get; set; }

//        //[Required]
//        //public virtual Sex Sex { get; set; }

//        //[MaxLength(16)]
//        //public virtual string DOB { get; set; }

//        //[MaxLength(16)]
//        //public virtual string Tel { get; set; }

//        //[MaxLength(16)]
//        //public virtual string Mobile { get; set; }

//        //[MaxLength(32)]
//        //public virtual string NO { get; set; }

//        //[MaxLength(128)]
//        //public virtual string Group { get; set; }

//        //[MaxLength(128)]
//        //public virtual string ProfessionalTitle { get; set; }

//        //[MaxLength(10)]
//        //public virtual string Ext { get; set; }

//        //public virtual DateTime? HireDate { get; set; }

//        //public virtual DateTime? ResignationDate { get; set; }

//        //#endregion

//        //#region 个人设置
//        //public virtual int PageSize { get; set; } = 10;

//        //#endregion

//        //#region 通用记录

//        ///// <summary>
//        ///// 建档时间
//        ///// </summary>
//        //[Required]
//        //public virtual DateTime CreateDate
//        //{
//        //    get;
//        //    set;
//        //}

//        ///// <summary>
//        ///// 描述备注
//        ///// </summary>
//        //[MaxLength(128)]
//        //public virtual string Description
//        //{
//        //    get;
//        //    set;
//        //}

//        //#endregion

//        #region 外键
//        //public virtual ICollection<UserInGroup<TKey>> Groups { get; } = new List<UserInGroup<TKey>>();
//        //public virtual ICollection<PersonalizationPerUser<TKey>> Paths { get; } = new List<PersonalizationPerUser<TKey>>();
        
//        //public virtual ICollection<LoginLog> LoginLogs { get; set; }
//        //public virtual ICollection<EventLog> EventLogs { get; set; }

//        #endregion
//    }
//}
