namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class ModuleRepository : BaseRepository<Module>, IModuleRepository//: IBaseRepository<Module>
    {
        public ModuleRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
