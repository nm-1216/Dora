using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TeachingPlanLogService : BaseService<TeachingPlanLog>, ITeachingPlanLogService// : IBaseService<TeachingPlanLog>
    {
        public TeachingPlanLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
