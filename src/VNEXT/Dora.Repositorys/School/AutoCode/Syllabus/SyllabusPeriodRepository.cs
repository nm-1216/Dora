namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class SyllabusPeriodRepository : BaseRepository<SyllabusPeriod>, ISyllabusPeriodRepository//: IBaseRepository<SyllabusPeriod>
    {
        public SyllabusPeriodRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
