namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingPlanApprovalRepository : BaseRepository<TrainingPlanApproval>, ITrainingPlanApprovalRepository//: IBaseRepository<TrainingPlanApproval>
    {
        public TrainingPlanApprovalRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
