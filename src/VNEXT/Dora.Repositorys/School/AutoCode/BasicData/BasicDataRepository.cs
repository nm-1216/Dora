namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class BasicDataRepository : BaseRepository<BasicData>, IBasicDataRepository//: IBaseRepository<BasicData>
    {
        public BasicDataRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
