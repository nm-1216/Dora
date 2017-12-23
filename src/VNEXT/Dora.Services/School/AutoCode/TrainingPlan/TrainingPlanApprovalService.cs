using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TrainingPlanApprovalService : BaseService<TrainingPlanApproval>, ITrainingPlanApprovalService// : IBaseService<TrainingPlanApproval>
    {
        public TrainingPlanApprovalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
