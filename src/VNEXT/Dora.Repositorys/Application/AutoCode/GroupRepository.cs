

namespace Dora.Repositorys.Application
{
    using Interfaces;
    using Infrastructure.Repositorys;
    using Domain.Entities.Application;
    using Infrastructure.Infrastructures.Interfaces;

    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}


