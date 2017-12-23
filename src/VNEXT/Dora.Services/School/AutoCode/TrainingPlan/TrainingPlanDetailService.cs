using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TrainingPlanDetailService : BaseService<TrainingPlanDetail>, ITrainingPlanDetailService// : IBaseService<TrainingPlanDetail>
    {
        public TrainingPlanDetailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
