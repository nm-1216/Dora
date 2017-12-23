namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class PersonnelTrainingApprovalRepository : BaseRepository<PersonnelTrainingApproval>, IPersonnelTrainingApprovalRepository//: IBaseRepository<PersonnelTrainingApproval>
    {
        public PersonnelTrainingApprovalRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
