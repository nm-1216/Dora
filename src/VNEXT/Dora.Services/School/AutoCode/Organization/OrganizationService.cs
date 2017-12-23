﻿using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class OrganizationService : BaseService<Organization>, IOrganizationService// : IBaseService<Organization>
    {
        public OrganizationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
