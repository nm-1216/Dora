namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeachingPlanRepository : BaseRepository<TeachingPlan>, ITeachingPlanRepository//: IBaseRepository<TeachingPlan>
    {
        public TeachingPlanRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
