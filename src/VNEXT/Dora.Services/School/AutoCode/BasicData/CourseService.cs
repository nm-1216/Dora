namespace Dora.Services.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public partial class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

}
