﻿namespace Dora.Repositorys.Systems
{
    using Dora.Domain.Entities.System;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Repositorys;
    using Dora.Repositorys.Systems.Interfaces;

    public partial class DictRepository : BaseRepository<Dict>, IDictRepository
    {
        public DictRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
