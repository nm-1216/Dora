using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TeachingTaskDetailService : BaseService<TeachingTaskDetail>, ITeachingTaskDetailService// : IBaseService<TeachingTaskDetail>
    {
        public TeachingTaskDetailService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
