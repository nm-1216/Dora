namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeachingTaskRepository : BaseRepository<TeachingTask>, ITeachingTaskRepository//: IBaseRepository<TeachingTask>
    {
        public TeachingTaskRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
