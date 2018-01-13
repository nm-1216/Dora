namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 教学大纲
    /// </summary>
    [Authorize]
    public class SyllabusController : BaseUserController<SyllabusController>
    {
        private ISyllabusService _SyllabusService;
        private ICourseService _CourseService;

        public SyllabusController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , ISyllabusService SyllabusService
        , ICourseService CourseService
        ) : base(roleManager, userManager, loggerFactory)
        {
            _SyllabusService = SyllabusService;
            _CourseService = CourseService;
        }


        #region 产生任务
        public async Task<IActionResult> CourseList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;
            var user = await GetCurrentUserAsync();

            var list = new PageList<Course>(_CourseService.GetAll().Include(b=>b.Syllabuss)
                .Where(
                b => string.IsNullOrEmpty(searchKey) ||
                b.CourseId.Contains(searchKey) ||
                b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, user.PageSize);

            return View(list);
        }

        public IActionResult Create(string courseId)
        {
            return View();
        }
        #endregion

        #region 分配任务
        public IActionResult SetGroup(string syllabusId, string groupId)
        {
            return View();
        }
        public IActionResult SetTeacher(string syllabusId, string teacherId)
        {
            return View();
        }
        #endregion


        #region 修改大纲
        public IActionResult Edit(Syllabus model)
        {
            return View();
        }
        #endregion

        #region 送审

        #endregion

        /// <summary>
        /// 各教师大纲列表(用于查询大纲)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 编辑教学大纲
        /// </summary>
        /// <param name="id">课程ID或者大纲ID</param>
        /// <returns></returns>
        public IActionResult Edit(string id)
        {
            var model = _SyllabusService.Find(b => b.SyllabusId == id || b.CourseId == id);

            return View(model);
        }
    }
}