namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class PublicClassRoomRepository : BaseRepository<PublicClassRoom>, IPublicClassRoomRepository//: IBaseRepository<PublicClassRoom>
    {
        public PublicClassRoomRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
