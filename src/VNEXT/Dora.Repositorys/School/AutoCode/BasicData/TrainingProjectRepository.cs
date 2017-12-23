namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingProjectRepository : BaseRepository<TrainingProject>, ITrainingProjectRepository//: IBaseRepository<TrainingProject>
    {
        public TrainingProjectRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
