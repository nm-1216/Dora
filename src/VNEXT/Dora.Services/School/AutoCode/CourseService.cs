namespace Dora.Services.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public partial class CourseService : BaseService<Course>, ICourseService// : IBaseService<Course>
    {
        public CourseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

}
