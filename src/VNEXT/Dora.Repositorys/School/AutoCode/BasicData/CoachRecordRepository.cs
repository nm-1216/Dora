namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class CoachRecordRepository : BaseRepository<CoachRecord>, ICoachRecordRepository//: IBaseRepository<CoachRecord>
    {
        public CoachRecordRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
