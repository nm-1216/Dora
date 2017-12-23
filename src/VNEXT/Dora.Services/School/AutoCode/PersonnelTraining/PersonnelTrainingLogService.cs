using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class PersonnelTrainingLogService : BaseService<PersonnelTrainingLog>, IPersonnelTrainingLogService// : IBaseService<PersonnelTrainingLog>
    {
        public PersonnelTrainingLogService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
