using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class PublicClassRoomService : BaseService<PublicClassRoom>, IPublicClassRoomService// : IBaseService<PublicClassRoom>
    {
        public PublicClassRoomService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
