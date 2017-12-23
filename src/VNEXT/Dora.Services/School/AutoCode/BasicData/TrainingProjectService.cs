using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class TrainingProjectService : BaseService<TrainingProject>, ITrainingProjectService// : IBaseService<TrainingProject>
    {
        public TrainingProjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
