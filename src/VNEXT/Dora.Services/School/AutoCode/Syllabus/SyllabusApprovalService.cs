using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class SyllabusApprovalService : BaseService<SyllabusApproval>, ISyllabusApprovalService// : IBaseService<SyllabusApproval>
    {
        public SyllabusApprovalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
