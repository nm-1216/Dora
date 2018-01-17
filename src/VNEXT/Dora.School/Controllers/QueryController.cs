namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 查询
    /// </summary>
    public class QueryController : BaseUserController<QueryController>
    {
        private readonly ISyllabusService _SyllabusService;

        public QueryController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , ISyllabusService SyllabusService
        ) : base(roleManager, userManager, loggerFactory)
        {
            _SyllabusService = SyllabusService;
        }

        /// <summary>
        /// 课程大纲查询
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> SyllabusList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;
            var user = await GetCurrentUserAsync();

            var list = new PageList<Syllabus>(_SyllabusService.GetAll()
                .Include(b => b.Teacher)
                .Include(b => b.Course)
                .Include(b => b.Course)
                .Where(b => string.IsNullOrEmpty(searchKey) || b.CourseId.Contains(searchKey) || b.Course.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime)
                , page, user.PageSize);

            return View(list);
        }
    }
}