namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// 教学大纲
    /// </summary>
    [Authorize]
    public class SyllabusController : BaseUserController<SyllabusController>
    {
        private readonly ISyllabusService _SyllabusService;
        private readonly ISyllabusBookService _SyllabusBookService;
        private readonly ICourseService _CourseService;
        private readonly ITeacherService _teacherService;
        private readonly ISyllabusLogService _syllabusLogService;

        public SyllabusController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , ISyllabusService SyllabusService,
          ISyllabusBookService SyllabusBookService
        , ICourseService CourseService
        , ITeacherService teacherService
		, ISyllabusLogService syllabusLogService
        ) : base(roleManager, userManager, loggerFactory)
        {
            this._SyllabusService = SyllabusService;
            this._SyllabusBookService = SyllabusBookService;
            this._CourseService = CourseService;
            this._teacherService = teacherService;
            this._syllabusLogService = syllabusLogService;
        }


        #region 产生任务
        public async Task<IActionResult> CourseList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;
            var user = await GetCurrentUserAsync();

            var list = new PageList<Course>(_CourseService.GetAll().Include(b => b.Syllabuss)
                .Where(
                b => string.IsNullOrEmpty(searchKey) ||
                b.CourseId.Contains(searchKey) ||
                b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, user.PageSize);

            return View(list);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="courseId">课程编码</param>
        /// <param name="isRestTask">是否修订</param>
        /// <returns></returns>
        public async Task<IActionResult> Create(string courseId, bool isRestTask)
        {
            var course = await _CourseService.GetAll().Include(b => b.Syllabuss).FirstOrDefaultAsync(b => b.CourseId == courseId);

            if (course != null)
            {
                ///是修订
                if (isRestTask)
                {
                    course.Syllabuss.Add(new Syllabus() { SyllabusLogs=new List<SyllabusLog>(){new SyllabusLog(){ Memo="创建课程教学大纲" }} });
                    await _CourseService.Update(course);
                    return Json(new AjaxResult("操作成功") { result = 1 });
                }
                else
                {
                    if (course.Syllabuss.Count() > 0)
                    {
                        return Json(new AjaxResult("操作失败，数据已存在") { result = 0 });
                    }
                    else
                    {
						course.Syllabuss.Add(new Syllabus() { SyllabusLogs = new List<SyllabusLog>() { new SyllabusLog() { Memo = "创建课程教学大纲" } } });
                        await _CourseService.Update(course);
                        return Json(new AjaxResult("操作成功") { result = 1 });
                    }
                }
            }
            else
            {
                return Json(new AjaxResult("操作失败，课程不存在") { result = 0 });
            }



        }
        #endregion

        #region 分配任务
        public IActionResult SetGroup(string syllabusId, string groupId)
        {
            return View();
        }

        /// <summary>
        /// Sets the teacher().
        /// </summary>
        /// <returns>The teacher.</returns>
        /// <param name="syllabusId">Syllabus identifier.</param>
        /// <param name="teacherId">Teacher identifier.</param>
        /// <param name="page">Page.</param>
        public async Task<IActionResult> SetTeacher(string syllabusId, string teacherId, int page = 1)
        {

            if (!string.IsNullOrEmpty(syllabusId) && !string.IsNullOrEmpty(teacherId))
            {
                var model = _SyllabusService.Find(b => b.SyllabusId == syllabusId);
                model.TeacherId = teacherId;
                await _SyllabusService.Update(model);
            }

            var teachers = _teacherService.GetAll().Select(b => new SelectListItem() { Value = b.TeacherId, Text = b.Name }).ToList();
            teachers.Insert(0, new SelectListItem() { Text = "==请选择教师==", Value = "" });
            ViewBag.teachers = teachers;

            var user = await GetCurrentUserAsync();
            ///var list= ;

            var list = new PageList<Syllabus>(_SyllabusService.GetAll()
                .Include(b => b.Teacher)
                .Include(b => b.Organization)
                .Include(b => b.Course)
                .OrderByDescending(o => o.CreateTime), page, user.PageSize);

            return View(list);

        }

        #endregion


        #region 修改大纲
        /// <summary>
        /// 编辑教学大纲
        /// </summary>
        /// <param name="id">课程ID或者大纲ID</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = _SyllabusService.GetAll().Include(b => b.Course).Include(b => b.Teacher).FirstOrDefault(b => b.SyllabusId == id);

            ViewBag.msg = "";
             
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromServices]IHostingEnvironment env, Syllabus model, IList<IFormFile> files)
        {
            var _files = string.Empty;

            if (files != null && files.Count > 0)
            {
                var file = files[0];
                _files = BaseDataController.SaveFile(env, "Syllabus", file);
            }

            var item = _SyllabusService.Find(b => b.SyllabusId == model.SyllabusId);

            item.ConReq = model.ConReq;
            item.EvaWay = model.EvaWay;
            item.PraCon = model.PraCon;
            item.Pro = model.Pro;
            item.Tar = model.Tar;
            item.Version = model.Version;
            item.UpdateTime = DateTime.Now;

            if (!string.IsNullOrEmpty(_files))
            {
                item.TeaProPath = _files;
            }

            await _SyllabusService.Update(item);

            var v = _SyllabusService.GetAll().Include(b => b.Course).Include(b => b.Teacher).FirstOrDefault(b => b.SyllabusId == model.SyllabusId);

            ViewBag.msg = "保存成功";

            return View(v);
        }
        #endregion

        #region 送审

        #endregion

        /// <summary>
        /// 各教师大纲列表(用于查询大纲)
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var list = _SyllabusService.GetAll().Include(b => b.Course).Include(b => b.Teacher).Where(b => b.TeacherId == user.Id);

            return View(list);
        }

        public IActionResult Details(string id)
        {
            var model = _SyllabusService.GetAll().Include(b => b.Course).Include(b => b.Teacher).FirstOrDefault(b => b.SyllabusId == id);

            return View(model);
        }

        [HttpPost]
        public string GetSyllabusBooks(string id)
        {
            //  var SyllabusBook = _SyllabusService.GetAll().Include(b => b.SyllabusBooks).FirstOrDefault(r => r.SyllabusId == id).SyllabusBooks;

            var SyllabusBook = _SyllabusBookService.GetAll().Where(r => r.SyllabusId == id);
            string json = JsonConvert.SerializeObject(SyllabusBook);
            return json;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SyllabusBook model)
        {
            if (ModelState.IsValid)
            {
                model.SyllabusBookId = Guid.NewGuid().ToString();
                await _SyllabusBookService.Add(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,数据格式有误") { result = 0 });
            }
        }
         
        [HttpPost]
        public async Task<IActionResult> DeleteSyllabusBook(string id)
        {
            var model = _SyllabusBookService.Find(r => r.SyllabusBookId == id);
            if (model != null)
            {
                await _SyllabusBookService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }


    }
}