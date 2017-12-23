namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingPlanDetailRepository : BaseRepository<TrainingPlanDetail>, ITrainingPlanDetailRepository//: IBaseRepository<TrainingPlanDetail>
    {
        public TrainingPlanDetailRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
