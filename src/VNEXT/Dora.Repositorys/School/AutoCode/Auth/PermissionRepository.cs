namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class PermissionRepository : BaseRepository<Permission>, IPermissionRepository//: IBaseRepository<Permission>
    {
        public PermissionRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
