using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class PermissionService : BaseService<Permission>, IPermissionService// : IBaseService<Permission>
    {
        public PermissionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
