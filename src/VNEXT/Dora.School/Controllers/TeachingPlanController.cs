namespace Dora.School.Controllers
{
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeachingPlanController : BaseUserController<TeachingPlanController>
    {
        private ITeachingPlanService _TeachingPlanService;
        private ITeachingPlanDetailService _TeachingPlanDetailService;
        private ICourseService _CourseService;

        public TeachingPlanController(
            RoleManager<SchoolRole> roleManager,
            UserManager<SchoolUser> userManager,
            ILoggerFactory loggerFactory,
            ITeachingPlanService TeachingPlanService,
            ICourseService courseService,
            ITeachingPlanDetailService TeachingPlanDetailService) : base(roleManager, userManager, loggerFactory)
        {
            _TeachingPlanService = TeachingPlanService;
            _TeachingPlanDetailService = TeachingPlanDetailService;
            _CourseService = courseService;
        }

        public IActionResult Index()
        {
            var list = _TeachingPlanService.GetAll().Include(b => b.Course).Include(b => b.Teacher);

            return View(list);
        }

        /// <summary>
        /// 教学任务明细
        /// </summary>
        /// <param name="id">TeachingPlanID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = _TeachingPlanService.GetAll()
                .Include(b => b.Course)
                .Include(b => b.Teacher)
                .FirstOrDefault(b => b.TeachingPlanId == id);

            var xx = _CourseService.Find(b => b.CourseId == model.CourseId);

            model.Course = xx;

            await _TeachingPlanService.Update(model);

            var list = _TeachingPlanDetailService.GetAll().Where(r => r.TeachingPlanId == id).OrderBy(r => r.Order);
            ViewBag.model = model;
            return View(list);
        }

        // POST: TeachingTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TeachingPlan model, IFormCollection form)
        {
            var tp = _TeachingPlanService.GetAll().Include(b => b.Course).Include(b => b.Teacher).FirstOrDefault(b => b.TeachingPlanId == model.TeachingPlanId);

            IList<TeachingPlanDetail> list = new List<TeachingPlanDetail>();

            int Period = Convert.ToInt32(tp.Course.Period);
            //int Period = 64;
            for (int i = 0; i < Period / 2; i++)
            {
                TeachingPlanDetail item = new TeachingPlanDetail();
                item.TeachingPlanId = model.TeachingPlanId;
                item.Order = i + 1;
                list.Add(item);
            }
            await _TeachingPlanDetailService.AddRange(list);
            return RedirectToAction(nameof(Edit));
        }
    }
}