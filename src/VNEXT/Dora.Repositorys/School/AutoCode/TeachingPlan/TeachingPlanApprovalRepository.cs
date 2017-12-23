namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeachingPlanApprovalRepository : BaseRepository<TeachingPlanApproval>, ITeachingPlanApprovalRepository//: IBaseRepository<TeachingPlanApproval>
    {
        public TeachingPlanApprovalRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
