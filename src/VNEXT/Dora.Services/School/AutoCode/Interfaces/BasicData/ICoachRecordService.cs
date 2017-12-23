using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Domain.Entities.School;
using Dora.Infrastructure.Services.Interfaces;

namespace Dora.Services.School.Interfaces
{
    public partial interface ICoachRecordService : IBaseService<CoachRecord>
    {
    }
}
