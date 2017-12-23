using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class OrganizationRelationshipService : BaseService<OrganizationRelationship>, IOrganizationRelationshipService// : IBaseService<OrganizationRelationship>
    {
        public OrganizationRelationshipService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
