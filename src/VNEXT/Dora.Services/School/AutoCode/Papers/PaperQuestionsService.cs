﻿namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class PaperQuestionsService : BaseService<PaperQuestions>, IPaperQuestionsService
    {
        public PaperQuestionsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
