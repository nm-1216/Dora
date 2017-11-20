namespace Dora.Services.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public partial class SchoolUserService : BaseService<SchoolUser>, ISchoolUserService// : IBaseService<SchoolUser>
    {
        public SchoolUserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

}
