namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class PublicClassRoomService : BaseService<PublicClassRoom>, IPublicClassRoomService
    {
        public PublicClassRoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
