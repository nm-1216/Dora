using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TrainingLabDeviceService : BaseService<TrainingLabDevice>, ITrainingLabDeviceService// : IBaseService<TrainingLabDevice>
    {
        public TrainingLabDeviceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
