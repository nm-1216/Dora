using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class SyllabusLogService : BaseService<SyllabusLog>, ISyllabusLogService// : IBaseService<SyllabusLog>
    {
        public SyllabusLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
