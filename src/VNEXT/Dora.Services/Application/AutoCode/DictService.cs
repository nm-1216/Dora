namespace Dora.Services.Application
{
    using Domain.Entities.Application;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public class DictService : BaseService<Dict>, IDictService
    {
        public DictService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
