namespace Dora.School.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Dora.Repositorys.School.Interfaces;
    using Dora.Services.School.Interfaces;

    /// <summary>
    /// 教学大纲
    /// </summary>
    public class SyllabusController : Controller
    {
        private readonly ILogger _logger;
        private ISyllabusRepository _SyllabusRepository;
        private ISyllabusService _SyllabusService;
        private ICourseRepository _CourseRepository;
        private ICourseService _CourseService;


        public SyllabusController(ILoggerFactory loggerFactory
            ,ISyllabusRepository SyllabusRepository, ISyllabusService SyllabusService
            ,ICourseRepository CourseRepository, ICourseService CourseService

            )
        {
            _logger = loggerFactory.CreateLogger<SyllabusController>();

            _SyllabusRepository = SyllabusRepository;
            _SyllabusService = SyllabusService;
            _CourseRepository = CourseRepository;
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
            var list = _CourseRepository.GetAll();
            return View(list);
        }

        /// <summary>
        /// 编辑教学大纲
        /// </summary>
        /// <param name="id">课程ID或者大纲ID</param>
        /// <returns></returns>
        public IActionResult edit(string id)
        {
            var model = _SyllabusRepository.Find(b => b.SyllabusId == id || b.CourseId == id);

            return View(model);
        }
    }
}