using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class ApprovalWorkflowService : BaseService<ApprovalWorkflow>, IApprovalWorkflowService// : IBaseService<ApprovalWorkflow>
    {
        public ApprovalWorkflowService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
