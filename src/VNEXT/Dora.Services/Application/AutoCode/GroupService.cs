namespace Dora.Services.Application
{
    using Domain.Entities.Application;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public class GroupService : BaseService<Group>, IGroupService// IBaseService<BankList>
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
