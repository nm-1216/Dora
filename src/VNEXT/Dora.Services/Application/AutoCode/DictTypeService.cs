namespace Dora.Services.Application
{
    using Domain.Entities.Application;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public class DictTypeService : BaseService<DictType>, IDictTypeService
    {
        public DictTypeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
