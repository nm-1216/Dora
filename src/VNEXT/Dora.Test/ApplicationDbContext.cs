using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Database;
using Dora.Infrastructure.Extensions;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dora.Test
{
    public class ApplicationDbContext: DoraContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
