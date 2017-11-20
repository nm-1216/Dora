

namespace Dora.Database
{
    using Domain.Entities.School;
    using Dora.Domain.Entities.System;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext
    {
        #region System
        public DbSet<Dict> Dicts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolUser> SchoolUsers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SchoolUserInClass> SchoolUserInClass { get; set; }

        #endregion
    }
}
