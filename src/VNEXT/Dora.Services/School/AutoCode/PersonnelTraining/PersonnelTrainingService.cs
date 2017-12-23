using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class PersonnelTrainingService : BaseService<PersonnelTraining>, IPersonnelTrainingService// : IBaseService<PersonnelTraining>
    {
        public PersonnelTrainingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
