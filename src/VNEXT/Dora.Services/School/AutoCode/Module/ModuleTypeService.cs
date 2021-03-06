﻿using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class ModuleTypeService : BaseService<ModuleType>, IModuleTypeService// : IBaseService<ModuleType>
    {
        public ModuleTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
