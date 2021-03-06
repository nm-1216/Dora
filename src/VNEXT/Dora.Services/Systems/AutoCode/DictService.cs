﻿
namespace Dora.Services.Systems
{
    using Domain.Entities.Application;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.Systems.Interfaces;

    public partial class DictService : BaseService<Dict>, IDictService
    {
        public DictService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
