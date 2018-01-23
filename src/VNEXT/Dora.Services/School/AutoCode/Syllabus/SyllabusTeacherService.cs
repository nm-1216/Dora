using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class SyllabusTeacherService : BaseService<SyllabusTeacher>, ISyllabusTeacherService
    {
        public SyllabusTeacherService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
