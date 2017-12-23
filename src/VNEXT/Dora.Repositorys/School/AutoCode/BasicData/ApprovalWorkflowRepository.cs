namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class ApprovalWorkflowRepository : BaseRepository<ApprovalWorkflow>, IApprovalWorkflowRepository//: IBaseRepository<ApprovalWorkflow>
    {
        public ApprovalWorkflowRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
