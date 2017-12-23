namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class ProfessionalRepository : BaseRepository<Professional>, IProfessionalRepository//: IBaseRepository<Professional>
    {
        public ProfessionalRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
