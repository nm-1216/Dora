

namespace Dora.Database
{
    using Dora.Domain.Entities.System;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext
    {
        #region System
        public DbSet<Dict> Dicts { get; set; }

        #endregion
    }
}
