namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeachingPlanLogRepository : BaseRepository<TeachingPlanLog>, ITeachingPlanLogRepository//: IBaseRepository<TeachingPlanLog>
    {
        public TeachingPlanLogRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
