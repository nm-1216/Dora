namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository//: IBaseRepository<Teacher>
    {
        public TeacherRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
