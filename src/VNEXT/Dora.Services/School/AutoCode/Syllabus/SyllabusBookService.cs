using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class SyllabusBookService : BaseService<SyllabusBook>, ISyllabusBookService// : IBaseService<SyllabusBook>
    {
        public SyllabusBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
