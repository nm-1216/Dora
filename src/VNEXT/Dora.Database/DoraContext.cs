namespace Dora.Database
{
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext : DbContext, IDbContext
    {
        public DoraContext(DbContextOptions options) : base(options)
        {
        }
    }
}
