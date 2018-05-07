namespace Dora.Services.School.Interfaces
{
    using Domain.Entities.School;
    using Dora.Infrastructure.Services.Interfaces;

    public partial interface IStudentService : IBaseService<Student>
    {
        void SynchroUser(string AppID,string Appsecret);
    }
}
