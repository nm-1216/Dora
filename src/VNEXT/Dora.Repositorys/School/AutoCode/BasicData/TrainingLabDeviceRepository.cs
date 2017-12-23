namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TrainingLabDeviceRepository : BaseRepository<TrainingLabDevice>, ITrainingLabDeviceRepository//: IBaseRepository<TrainingLabDevice>
    {
        public TrainingLabDeviceRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
