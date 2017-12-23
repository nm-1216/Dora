using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class CourseProfessionalService : BaseService<CourseProfessional>, ICourseProfessionalService// : IBaseService<CourseProfessional>
    {
        public CourseProfessionalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
