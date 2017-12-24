using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public class SyllabusApprovalService1 : BaseService<SyllabusApproval>, ISyllabusApprovalService
    {
        public SyllabusApprovalService1(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
