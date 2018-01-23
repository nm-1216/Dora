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
        private ISyllabusPeriodService _SyllabusPeriodService;
        private ISyllabusFirstCourseService _SyllabusFirstCourseService;
        private ISyllabusProfessionalService _SyllabusProfessionalService;
        private ISyllabusTeacherService _SyllabusTeacherService;
        private ICourseService _CourseService;
        private IProfessionalService _ProfessionalService;
        private ITeacherService _TeacherService;

        public SyllabusController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , ISyllabusService SyllabusService
        , ISyllabusBookService SyllabusBookService
        , ISyllabusPeriodService SyllabusPeriodService
        , ISyllabusFirstCourseService SyllabusFirstCourseService
        , ISyllabusProfessionalService SyllabusProfessionalService
        , ISyllabusTeacherService SyllabusTeacherService
        , IProfessionalService ProfessionalService
        , ICourseService CourseService
        , ITeacherService teacherService
		, ISyllabusLogService syllabusLogService
        ) : base(roleManager, userManager, loggerFactory)
        {
            _SyllabusService = SyllabusService;
            _SyllabusBookService = SyllabusBookService;
            _SyllabusPeriodService = SyllabusPeriodService;
            _SyllabusFirstCourseService = SyllabusFirstCourseService;
            _SyllabusProfessionalService = SyllabusProfessionalService;
            _SyllabusTeacherService = SyllabusTeacherService;
            _ProfessionalService = ProfessionalService;
            _CourseService = CourseService;
            _TeacherService = teacherService;
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

            var teachers = _TeacherService.GetAll().Select(b => new SelectListItem() { Value = b.TeacherId, Text = b.Name }).ToList();
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

        #region 建议选用教材
        [HttpPost]
        public IActionResult GetSyllabusBooks(string id)
        {
            //  var SyllabusBook = _SyllabusService.GetAll().Include(b => b.SyllabusBooks).FirstOrDefault(r => r.SyllabusId == id).SyllabusBooks;

            var SyllabusBook = _SyllabusBookService.GetAll().Where(r => r.SyllabusId == id);
            return Json(SyllabusBook);
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
        public async Task<IActionResult> DeleteSyllabusBook(string id, string sid)
        {
            var model = _SyllabusBookService.Find(r => r.SyllabusBookId == id && r.SyllabusId == sid);
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
        #endregion

        #region 课程学时分配
        [HttpPost]
        public IActionResult GetSyllabusPeriod(string id)
        { 
            var SyllabusPeriod = _SyllabusPeriodService.GetAll().Where(r => r.SyllabusId == id); 
            return Json(SyllabusPeriod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSyllabusPeriod(SyllabusPeriod model)
        {
            if (ModelState.IsValid)
            {
                model.SyllabusPeriodId = Guid.NewGuid().ToString();
                await _SyllabusPeriodService.Add(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,数据格式有误") { result = 0 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSyllabusPeriod(string id, string sid)
        {
            var model = _SyllabusPeriodService.Find(r => r.SyllabusPeriodId == id && r.SyllabusId == sid);
            if (model != null)
            {
                await _SyllabusPeriodService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }
        #endregion


        #region 先修课程

        /// <summary>
        /// 根据搜索框内容，筛选出课程列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult GetCourses(string name)
        {
            //课程列表
            var Courses = _CourseService.GetAll().Where(r => r.Name.Contains(name));
            return Json(Courses);
        }

        /// <summary>
        /// 取已添加的课程
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetSyllabusFirstCourse(string id)
        {
            var SyllabusFirstCourse = _SyllabusFirstCourseService.GetAll().Where(r => r.SyllabusId == id).Select(r => r.Course);
            return Json(SyllabusFirstCourse);
        }
         
        /// <summary>
        /// 添加一条课程
        /// </summary>
        /// <param name="id">课程id</param>
        /// <param name="sid">SyllabusId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSyllabusFirstCourse(string id, string sid)
        {
            var item = _SyllabusFirstCourseService.Find(r => r.CourseId == id && r.SyllabusId == sid);
            if (item == null)
            {
                SyllabusFirstCourse model = new SyllabusFirstCourse();
                model.CourseId = id;
                model.SyllabusId = sid;
                await _SyllabusFirstCourseService.Add(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else 
            {
                return Json(new AjaxResult("该课程已添加") { result = 0 });
            }
        }

        /// <summary>
        /// 删除一条课程
        /// </summary>
        /// <param name="id">课程id</param>
        /// <param name="sid">SyllabusId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteSyllabusFirstCourse(string id, string sid)
        {
            var model = _SyllabusFirstCourseService.Find(r => r.CourseId == id && r.SyllabusId == sid);
            if (model != null)
            {
                await _SyllabusFirstCourseService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }
        #endregion


        #region 设置对应专业

        /// <summary>
        /// 根据搜索框内容，筛选出专业列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult GetProfessionals(string name)
        {
            //专业列表
            var Professionals = _ProfessionalService.GetAll().Where(r => r.Name.Contains(name));
            return Json(Professionals);
        }

        /// <summary>
        /// 取已添加的专业
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetSyllabusProfessional(string id)
        {
            var SyllabusProfessional = _SyllabusProfessionalService.GetAll().Where(r => r.SyllabusId == id).Select(r => r.Professional);
            return Json(SyllabusProfessional);
        }

        /// <summary>
        /// 添加一条专业
        /// </summary>
        /// <param name="id">专业id</param>
        /// <param name="sid">SyllabusId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSyllabusProfessional(string id, string sid)
        {
            var item = _SyllabusProfessionalService.Find(r => r.ProfessionalId == id && r.SyllabusId == sid);
            if (item == null)
            {
                SyllabusProfessional model = new SyllabusProfessional();
                model.ProfessionalId = id;
                model.SyllabusId = sid;
                await _SyllabusProfessionalService.Add(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("该专业已添加") { result = 0 });
            }
        }

        /// <summary>
        /// 删除一条专业
        /// </summary>
        /// <param name="id">专业id</param>
        /// <param name="sid">SyllabusId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteSyllabusProfessional(string id, string sid)
        {
            var model = _SyllabusProfessionalService.Find(r => r.ProfessionalId == id && r.SyllabusId == sid);
            if (model != null)
            {
                await _SyllabusProfessionalService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }
        #endregion


        #region 设置对应任课老师

        /// <summary>
        /// 根据搜索框内容，筛选出任课老师列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IActionResult GetTeachers(string name)
        {
            //任课老师列表
            var Teachers = _TeacherService.GetAll().Where(r => r.Name.Contains(name));
            return Json(Teachers);
        }

        /// <summary>
        /// 取已添加的任课老师
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetSyllabusTeacher(string id)
        {
            var SyllabusTeacher = _SyllabusTeacherService.GetAll().Where(r => r.SyllabusId == id).Select(r => r.Teacher);
            return Json(SyllabusTeacher);
        }

        /// <summary>
        /// 添加一条任课老师
        /// </summary>
        /// <param name="id">任课老师id</param>
        /// <param name="sid">SyllabusId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddSyllabusTeacher(string id, string sid)
        {
            var item = _SyllabusTeacherService.Find(r => r.TeacherId == id && r.SyllabusId == sid);
            if (item == null)
            {
                SyllabusTeacher model = new SyllabusTeacher();
                model.TeacherId = id;
                model.SyllabusId = sid;
                await _SyllabusTeacherService.Add(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("该任课老师已添加") { result = 0 });
            }
        }

        /// <summary>
        /// 删除一条任课老师
        /// </summary>
        /// <param name="id">任课老师id</param>
        /// <param name="sid">SyllabusId</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteSyllabusTeacher(string id, string sid)
        {
            var model = _SyllabusTeacherService.Find(r => r.TeacherId == id && r.SyllabusId == sid);
            if (model != null)
            {
                await _SyllabusTeacherService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }
        #endregion

    }
}