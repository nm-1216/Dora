using System.Linq;

namespace Dora.Services.School
{
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Infrastructure.Services;
    using Dora.Services.School.Interfaces;

    public partial class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        
        public void SynchroUser(string AppID,string Appsecret)
        {
           
        }
    }
}
