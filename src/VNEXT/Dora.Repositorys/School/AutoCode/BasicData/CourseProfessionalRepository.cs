namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class CourseProfessionalRepository : BaseRepository<CourseProfessional>, ICourseProfessionalRepository//: IBaseRepository<CourseProfessional>
    {
        public CourseProfessionalRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
