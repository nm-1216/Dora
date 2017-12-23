using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class BasicDataService : BaseService<BasicData>, IBasicDataService// : IBaseService<BasicData>
    {
        public BasicDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
