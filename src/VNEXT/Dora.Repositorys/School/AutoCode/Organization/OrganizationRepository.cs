namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository//: IBaseRepository<Organization>
    {
        public OrganizationRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
