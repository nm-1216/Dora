namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class StudentRepository : BaseRepository<Student>, IStudentRepository//: IBaseRepository<Student>
    {
        public StudentRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
