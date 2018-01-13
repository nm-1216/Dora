namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class TrainingLabDeviceService : BaseService<TrainingLabDevice>, ITrainingLabDeviceService
    {
        public TrainingLabDeviceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
