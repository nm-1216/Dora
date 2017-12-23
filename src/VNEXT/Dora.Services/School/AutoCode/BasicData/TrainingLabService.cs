using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TrainingLabService : BaseService<TrainingLab>, ITrainingLabService// : IBaseService<TrainingLab>
    {
        public TrainingLabService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
