
namespace Dora.School
{
    using Dora.Database;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DoraContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
