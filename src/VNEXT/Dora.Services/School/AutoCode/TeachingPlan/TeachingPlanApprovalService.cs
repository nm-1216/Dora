using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TeachingPlanApprovalService : BaseService<TeachingPlanApproval>, ITeachingPlanApprovalService// : IBaseService<TeachingPlanApproval>
    {
        public TeachingPlanApprovalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
