using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School 
{
    public partial class SyllabusFirstCourseService : BaseService<SyllabusFirstCourse>, ISyllabusFirstCourseService
    {
        public SyllabusFirstCourseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
