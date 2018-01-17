namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class TermService : BaseService<Term>, ITermService
    {
        public TermService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

