using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TeachingPlanDetailService : BaseService<TeachingPlanDetail>, ITeachingPlanDetailService// : IBaseService<TeachingPlanDetail>
    {
        public TeachingPlanDetailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
