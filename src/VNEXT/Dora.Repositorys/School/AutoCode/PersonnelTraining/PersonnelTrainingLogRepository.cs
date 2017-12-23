namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class PersonnelTrainingLogRepository : BaseRepository<PersonnelTrainingLog>, IPersonnelTrainingLogRepository//: IBaseRepository<Class>
    {
        public PersonnelTrainingLogRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
