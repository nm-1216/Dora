namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class CourseClassTeacherRepository : BaseRepository<CourseClassTeacher>, ICourseClassTeacherRepository//: IBaseRepository<CourseClassTeacher>
    {
        public CourseClassTeacherRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
