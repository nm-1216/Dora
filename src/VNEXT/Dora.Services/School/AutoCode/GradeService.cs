namespace Dora.Services.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Services;
    using Interfaces;

    public partial class GradeService : BaseService<Grade>, IGradeService//: IBaseService<Grade>
    {
        public GradeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }

}
