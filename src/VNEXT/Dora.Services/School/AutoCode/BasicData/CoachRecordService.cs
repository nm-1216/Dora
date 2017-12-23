using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class CoachRecordService : BaseService<CoachRecord>, ICoachRecordService// : IBaseService<CoachRecord>
    {
        public CoachRecordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
