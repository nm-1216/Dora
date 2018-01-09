namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        public TeacherService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
