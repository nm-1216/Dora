using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TrainingPlanLogService : BaseService<TrainingPlanLog>, ITrainingPlanLogService// : IBaseService<TrainingPlanLog>
    {
        public TrainingPlanLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
