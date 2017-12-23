namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class ModuleTypeRepository : BaseRepository<ModuleType>, IModuleTypeRepository//: IBaseRepository<ModuleType>
    {
        public ModuleTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
