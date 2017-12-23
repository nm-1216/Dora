namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeachingTaskDetailRepository : BaseRepository<TeachingTaskDetail>, ITeachingTaskDetailRepository//: IBaseRepository<TeachingTaskDetail>
    {
        public TeachingTaskDetailRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
