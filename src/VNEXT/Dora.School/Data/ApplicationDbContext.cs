using Microsoft.EntityFrameworkCore;
using Dora.Domain.Entities.School;

namespace Dora.School
{
    using Dora.Database;
    using Dora.Domain.Entities.School;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DoraContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var user = builder.Entity<SchoolUser>();
            user.HasMany(u => u.Roles).WithOne().HasForeignKey(ur => ur.UserId);
        }
    }
}
