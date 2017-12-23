﻿using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Services;
using Dora.Services.School.Interfaces;

namespace Dora.Services.School
{
    public partial class SyllabusPeriodService : BaseService<SyllabusPeriod>, ISyllabusPeriodService// : IBaseService<SyllabusPeriod>
    {
        public SyllabusPeriodService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
