
namespace Dora.School.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Dora.Domain.Entities.School;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;


    public class TestController : BaseUserController<TestController>
    {
        public TestController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory) : base(roleManager, userManager, loggerFactory)
        {
        }

        public async Task<IActionResult> Index()
        {
            //var user = await GetCurrentUserAsync();
            return Content("");
        }
    }
}