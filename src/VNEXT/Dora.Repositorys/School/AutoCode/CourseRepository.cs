namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class CourseRepository : BaseRepository<Course>, ICourseRepository// : IBaseRepository<Course>
    {
        public CourseRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
