namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class CourseProfessionalService : BaseService<CourseProfessional>, ICourseProfessionalService
    {
        public CourseProfessionalService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
