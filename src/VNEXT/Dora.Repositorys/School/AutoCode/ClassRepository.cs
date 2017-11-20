namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class ClassRepository : BaseRepository<Class>, IClassRepository//: IBaseRepository<Class>
    {
        public ClassRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
