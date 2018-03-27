namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class PaperAnswerDetailsService : BaseService<PaperAnswerDetails>, IPaperAnswerDetailsService
    {
        public PaperAnswerDetailsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
