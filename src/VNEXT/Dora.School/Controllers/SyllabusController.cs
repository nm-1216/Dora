namespace Dora.School.Controllers
{
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

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

        /// <summary>
        /// 各教师大纲列表(用于查询大纲)
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 各教师需要编写的课程列表
        /// </summary>
        /// <returns></returns>
        public IActionResult CourseList()
        {
            var list = _CourseService.GetAll();
            return View(list);
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