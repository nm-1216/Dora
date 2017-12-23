namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingLabRepository : BaseRepository<TrainingLab>, ITrainingLabRepository//: IBaseRepository<TrainingLab>
    {
        public TrainingLabRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
