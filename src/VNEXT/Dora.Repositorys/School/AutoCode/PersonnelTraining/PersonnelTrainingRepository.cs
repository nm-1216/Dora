namespace Dora.Repositorys.School
{
    using Domain.Entities.School;
    using Infrastructure.Infrastructures.Interfaces;
    using Infrastructure.Repositorys;
    using Interfaces;

    public partial class PersonnelTrainingRepository : BaseRepository<PersonnelTraining>, IPersonnelTrainingRepository//: IBaseRepository<PersonnelTraining>
    {
        public PersonnelTrainingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }

}
