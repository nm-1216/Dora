namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class SyllabusLogRepository : BaseRepository<SyllabusLog>, ISyllabusLogRepository//: IBaseRepository<SyllabusLog>
    {
        public SyllabusLogRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
