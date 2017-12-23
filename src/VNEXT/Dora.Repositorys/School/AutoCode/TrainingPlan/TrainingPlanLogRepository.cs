namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingPlanLogRepository : BaseRepository<TrainingPlanLog>, ITrainingPlanLogRepository//: IBaseRepository<TrainingPlanLog>
    {
        public TrainingPlanLogRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
