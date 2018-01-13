namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class TrainingProjectService : BaseService<TrainingProject>, ITrainingProjectService
    {
        public TrainingProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
