

namespace Dora.Database
{
    using Domain.Mapping.System;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.AddConfiguration(new DictMap());
        }
    }
}
