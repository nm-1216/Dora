namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class SyllabusRepository : BaseRepository<Syllabus>, ISyllabusRepository//: IBaseRepository<Syllabus>
    {
        public SyllabusRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
