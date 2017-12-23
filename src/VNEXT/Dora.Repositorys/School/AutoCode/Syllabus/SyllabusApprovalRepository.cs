namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class SyllabusApprovalRepository : BaseRepository<SyllabusApproval>, ISyllabusApprovalRepository//: IBaseRepository<SyllabusApproval>
    {
        public SyllabusApprovalRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
