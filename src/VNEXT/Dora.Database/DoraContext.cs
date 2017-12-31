namespace Dora.Database
{
    using Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public partial class DoraContext : IdentityDbContext<SchoolUser>, IDbContext
    {
        public DoraContext(DbContextOptions options) : base(options)
        {
            
        }

        public void init()
        {

            //Application app = new Application("基础模块", "基础模块部分")
            //{
            //    Actions = new List<Action<string>>() {
            //        new Action() { ActionName="系统应用", Description="SystemApp" , ActionCategory="S01" ,Childs= new List<Action<string>>() {
            //            new Action() { ActionName="应用资料管理", ActionCategory="S01M01", Description="SystemApp/Applications" },
            //            new Action() { ActionName="应用模块管理", ActionCategory="S01M02", Description="SystemApp/Paths" },
            //            new Action() { ActionName="部门资料管理", ActionCategory="S01M03", Description="SystemApp/Groups" },
            //            new Action() { ActionName="角色资料管理", ActionCategory="S01M04", Description="SystemApp/Roles" },
            //            new Action() { ActionName="用户资料管理", ActionCategory="S01M05", Description="SystemApp/Users" },
            //            new Action() { ActionName="事件日志管理", ActionCategory="S01M06", Description="SystemApp/EventLogs"},
            //        } },

            //        new Action() { ActionName="系统维护", Description="SystemMaintenance", ActionCategory="S02" ,Childs= new List<Action<string>>() {
            //            new Action() { ActionName="系统运行状态", ActionCategory="S02M01", Description="SystemMaintenance/SystemState" },
            //            new Action() { ActionName="系统错误日志", ActionCategory="S02M02", Description="SystemMaintenance/SystemErrorLog" },
            //            new Action() { ActionName="系统环境配置", ActionCategory="S02M03", Description="SystemMaintenance/SystemConfig" },
            //        } },
            //    }
            //};

            //Applications.Add(app);

            SaveChanges();

        }
    }
}
