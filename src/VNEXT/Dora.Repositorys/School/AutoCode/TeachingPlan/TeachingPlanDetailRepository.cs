namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeachingPlanDetailRepository : BaseRepository<TeachingPlanDetail>, ITeachingPlanDetailRepository//: IBaseRepository<TeachingPlanDetail>
    {
        public TeachingPlanDetailRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
