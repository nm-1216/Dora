namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class SyllabusBookRepository : BaseRepository<SyllabusBook>, ISyllabusBookRepository//: IBaseRepository<SyllabusBook>
    {
        public SyllabusBookRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
