namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class OrganizationRelationshipRepository : BaseRepository<OrganizationRelationship>, IOrganizationRelationshipRepository//: IBaseRepository<OrganizationRelationship>
    {
        public OrganizationRelationshipRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
