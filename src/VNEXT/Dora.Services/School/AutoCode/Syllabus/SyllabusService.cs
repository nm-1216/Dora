using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class SyllabusService : BaseService<Syllabus>, ISyllabusService// : IBaseService<Syllabus>
    {
        public SyllabusService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
