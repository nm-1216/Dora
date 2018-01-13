namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class CoachRecordService : BaseService<CoachRecord>, ICoachRecordService
    {
        public CoachRecordService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
