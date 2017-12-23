namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingPlanRepository : BaseRepository<TrainingPlan>, ITrainingPlanRepository//: IBaseRepository<TrainingPlan>
    {
        public TrainingPlanRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
