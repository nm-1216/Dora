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
        private readonly ITeachingPlanService _TeachingPlanService;
        private readonly ITeachingPlanDetailService _TeachingPlanDetailService;

        public QueryController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , ISyllabusService SyllabusService
        , ITeachingPlanService TeachingPlanService
        , ITeachingPlanDetailService TeachingPlanDetailService
        ) : base(roleManager, userManager, loggerFactory)
        {
            _SyllabusService = SyllabusService;
            _TeachingPlanService = TeachingPlanService;
            _TeachingPlanDetailService = TeachingPlanDetailService;
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


        /// <summary>
        /// 授课计划查询
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> TeachingPlanList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;
            var user = await GetCurrentUserAsync();

            var list = new PageList<TeachingPlan>(_TeachingPlanService.GetAll()
                .Include(b => b.Teacher)
                .Include(b => b.Course)
                .Where(b => string.IsNullOrEmpty(searchKey) || b.Course.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime)
                , page, user.PageSize);

            return View(list);
        }



        /// <summary>
        /// 授课计划明细
        /// </summary>
        /// <returns></returns>
        public IActionResult TeachingPlanDetail(string id)
        {
            var list = _TeachingPlanDetailService.GetAll().Where(r => r.TeachingPlanId == id)
                .OrderBy(r => r.Order)
                .ToList();

            return View(list);
        }
    }
}