﻿namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Dora.ViewModels.Extensions;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeachingTaskController : BaseUserController<SyllabusController>
    {
        private IClassService _ClassService;
        private ITeachingTaskService _TeachingTaskService;
        private ITeachingTaskDetailService _TeachingTaskDetailService;
        private ITeachingPlanService _TeachingPlanService;
        private ICourseService _CourseService;
        private ISyllabusTeacherService _SyllabusTeacherService;

        public TeachingTaskController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager,
            ILoggerFactory loggerFactory
            , IClassService classService
            , ITeachingTaskService teachingTaskService
            , ITeachingTaskDetailService teachingTaskDetailService
            , ITeachingPlanService teachingPlanService
            , ICourseService CourseService
            , ISyllabusTeacherService SyllabusTeacherService
        ) : base(roleManager, userManager, loggerFactory)
        {
            _ClassService = classService;
            _TeachingTaskService = teachingTaskService;
            _TeachingTaskDetailService = teachingTaskDetailService;
            _TeachingPlanService = teachingPlanService;
            _CourseService = CourseService;
            _SyllabusTeacherService = SyllabusTeacherService;
        }


        public IActionResult Index(string IndexsearchKey)
        {
            ViewData["IndexsearchKey"] = IndexsearchKey;
            var list = _TeachingTaskService.GetAll()
                .Include(b=>b.Course)
                .Include(b=>b.Teachers).ThenInclude(c=>c.Teacher)
                .Include(b=>b.Classes).ThenInclude(c=>c.Class)
                
                .Where(r => (IndexsearchKey == null || r.Term.Contains(IndexsearchKey)));

            return View(list);
        }

        #region 导入

        public async Task<IActionResult> ImportTeachingTask([FromServices] IHostingEnvironment env,
            IList<IFormFile> files)
        {
            var _list = new List<TeachingTask>();

            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".xls") && !fileExtension.Equals(".xlsx"))
                {
                    return new JsonResult(new AjaxResult("文件格式不正确") {result = 0});
                }

                var dir = Path.Combine(env.WebRootPath, "upload", "temp", DateTime.Now.ToString("yyMMdd"));
                var fileName = Path.Combine(env.WebRootPath, "upload", "temp", DateTime.Now.ToString("yyMMdd"),
                    Guid.NewGuid() + fileExtension).ToLower();
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                IWorkbook workbook = null;
                ISheet sheet = null;
                using (var Read = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    if (fileExtension.Equals(".xlsx")) // 2007版本
                        workbook = new XSSFWorkbook(Read);
                    else
                        workbook = new HSSFWorkbook(Read);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheet("教学任务");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var course = GetValue(row.GetCell(0));
                    var teacher = GetValue(row.GetCell(1));
                    var term = GetValue(row.GetCell(2));
                    var classes = GetValue(row.GetCell(3));
                    var BegWeek = GetValue(row.GetCell(4));
                    var EndWeek = GetValue(row.GetCell(5));
                    var Memo = GetValue(row.GetCell(6));

                    if (!course.Equals("课程")
                        || !term.Equals("学期")
                        || !term.Equals("学期")
                        || !classes.Equals("班级")
                        || !BegWeek.Equals("开始周次")
                        || !EndWeek.Equals("结束周次")
                        || !Memo.Equals("备注"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") {result = 0});
                    }


                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null)
                            continue;

                        if (GetValue(row.GetCell(0)) == "")
                            continue;

                        course = GetValue(row.GetCell(0));
                        teacher = GetValue(row.GetCell(1));
                        term = GetValue(row.GetCell(2));
                        classes = GetValue(row.GetCell(3));
                        BegWeek = GetValue(row.GetCell(4));
                        EndWeek = GetValue(row.GetCell(5));
                        Memo = GetValue(row.GetCell(6));

                        if (!string.IsNullOrEmpty(course)
                            && !string.IsNullOrEmpty(teacher)
                            && !string.IsNullOrEmpty(term)
                            && !string.IsNullOrEmpty(classes)
                            && !string.IsNullOrEmpty(BegWeek)
                            && !string.IsNullOrEmpty(EndWeek) //备注可以为空
                        )
                        {
                            var _teacher = new List<TeachingTaskTeacher>();
                            var _class = new List<TeachingTaskClass>();

                            foreach (var item in classes.Split(','))
                            {
                                _class.Add(new TeachingTaskClass() {ClassId = item.Trim()});
                            }

                            foreach (var item in teacher.Split(','))
                            {
                                _teacher.Add(new TeachingTaskTeacher() {TeacherId = item.Trim()});
                            }

                            //教学任务
                            var model = new Domain.Entities.School.TeachingTask()
                            {
                                Term = term,
                                BegWeek = Convert.ToInt32(BegWeek),
                                EndWeek = Convert.ToInt32(EndWeek),
                                Memo = Memo,
                                Classes = _class,
                                Teachers = _teacher,
                                CourseId = course
                            };

                            _list.Add(model);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            var result = await _TeachingTaskService.AddRange(_list);

            return new JsonResult(new AjaxResult("导入成功") {result = 1});
        }


        public async Task<IActionResult> ImportTeachingTaskDetail([FromServices] IHostingEnvironment env,
            IList<IFormFile> files, string TeachingTaskId)
        {
            var _list = new List<TeachingTaskDetail>();

            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".xls") && !fileExtension.Equals(".xlsx"))
                {
                    return new JsonResult(new AjaxResult("文件格式不正确") {result = 0});
                }

                var dir = Path.Combine(env.WebRootPath, "upload", "temp", DateTime.Now.ToString("yyMMdd"));
                var fileName = Path.Combine(env.WebRootPath, "upload", "temp", DateTime.Now.ToString("yyMMdd"),
                    Guid.NewGuid() + fileExtension).ToLower();
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                IWorkbook workbook = null;
                ISheet sheet = null;
                using (var Read = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    if (fileExtension.Equals(".xlsx")) // 2007版本
                        workbook = new XSSFWorkbook(Read);
                    else
                        workbook = new HSSFWorkbook(Read);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheet("教学任务");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var ClaRoomCode = GetValue(row.GetCell(0));
                    var StrWeek = GetValue(row.GetCell(1));
                    var Section = GetValue(row.GetCell(2));

                    if (!ClaRoomCode.Equals("教室编号")
                        || !StrWeek.Equals("星期")
                        || !Section.Equals("上课节次"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") {result = 0});
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null)
                            continue;

                        if (GetValue(row.GetCell(0)) == "")
                            continue;

                        ClaRoomCode = GetValue(row.GetCell(0));
                        StrWeek = GetValue(row.GetCell(1));
                        Section = GetValue(row.GetCell(2));

                        if (!string.IsNullOrEmpty(ClaRoomCode)
                            && !string.IsNullOrEmpty(StrWeek)
                            && !string.IsNullOrEmpty(Section) //备注可以为空
                        )
                        {
                            if (_TeachingTaskDetailService.GetAll().Where(r =>
                                    r.TeachingTaskId == TeachingTaskId && r.ClaRoomCode == ClaRoomCode &&
                                    (int) r.Week == Convert.ToInt32(StrWeek) &&
                                    (int) r.Section == Convert.ToInt32(Section)).FirstOrDefault() == null)
                            {
                                //教学任务
                                var model = new Domain.Entities.School.TeachingTaskDetail()
                                {
                                    TeachingTaskId = TeachingTaskId,
                                    ClaRoomCode = ClaRoomCode,
                                    Week = (Week) Enum.Parse(typeof(Week), StrWeek),
                                    Section = ((SectionType) Convert.ToInt32(Section)),
                                };
                                _list.Add(model);
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            var result = await _TeachingTaskDetailService.AddRange(_list);

            return new JsonResult(new AjaxResult("导入成功"));
        }


        private string GetValue(ICell cell)
        {
            if (cell == null)
            {
                return null;
            }

            if (cell.CellType == CellType.Boolean)
            {
                return cell.BooleanCellValue.ToString();
            }
            else if (cell.CellType == CellType.Numeric)
            {
                Double doubleVal = cell.NumericCellValue;


                return doubleVal.ToString("#.####");
            }
            else
            {
                return cell.StringCellValue.Trim();
            }
        }

        #endregion

        // GET: TeachingTask/Create
        public ActionResult Create()
        {
            List<SelectListItem> type;
            type = (SectionType.节1_2).ToSelectListItem();

            ViewBag.SectionType = type;

            return View();
        }

        // POST: TeachingTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeachingTask model, IFormCollection form)
        {
            try
            {
                string classes = form["Classes"];
                string teacher = form["Teachers"];
                var _teacher = new List<TeachingTaskTeacher>();
                var _class = new List<TeachingTaskClass>();

                if (!String.IsNullOrEmpty(classes))
                {
                    foreach (var item in classes.Split(','))
                    {
                        _class.Add(new TeachingTaskClass() {ClassId = item.Trim()});
                    }
                }

                if (!String.IsNullOrEmpty(teacher))
                {
                    foreach (var item in teacher.Split(','))
                    {
                        _teacher.Add(new TeachingTaskTeacher() {TeacherId = item.Trim()});
                    }
                }

                model.Classes = _class;
                model.Teachers = _teacher;
                await this._TeachingTaskService.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeachingTask/Edit/5
        public ActionResult Edit(string id)
        {
            var model = this._TeachingTaskService.GetAll().Include(r => r.Classes).Include(r => r.Teachers)
                .Where(b => b.TeachingTaskId == id).FirstOrDefault();
            //GetAll().Include(r=> r.Teachers).Include(r=> r.Classes).Where

            #region 上课节次

//            List<SelectListItem> type;
            //type = ((Enum)SectionType.节1_2).ToSelectListItem(model.Section.ToString());

            //ViewBag.SectionType = type;

            #endregion

            #region 教师

            String strTeachers = "";
            var _teachers = model.Teachers;
            if (_teachers != null)
            {
                foreach (var item in _teachers)
                {
                    strTeachers += item.TeacherId + ",";
                }
            }

            ViewBag.Teacher = strTeachers.Length > 0 ? strTeachers.Substring(0, strTeachers.Length - 1) : "";

            #endregion

            #region 班级 

            String strClasses = "";
            var _Classes = model.Classes;
            if (_Classes != null)
            {
                foreach (var item in _Classes)
                {
                    strClasses += item.ClassId + ",";
                }
            }

            ViewBag.Class = strClasses.Length > 0 ? strClasses.Substring(0, strClasses.Length - 1) : "";

            #endregion

            return View(model);
        }

        // POST: TeachingTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TeachingTask model, IFormCollection form)
        {
            try
            {
                var newItem = this._TeachingTaskService.GetAll().Include(r => r.Classes).Include(r => r.Teachers)
                    .Where(b => b.TeachingTaskId == model.TeachingTaskId).FirstOrDefault();

                newItem.Term = model.Term;
                newItem.BegWeek = model.BegWeek;
                newItem.EndWeek = model.EndWeek;
                //newItem.ClaRoomCode = model.ClaRoomCode;
                //newItem.Week = model.Week;
                //newItem.Section = model.Section;
                newItem.Memo = model.Memo;
                newItem.CourseId = model.CourseId;
                newItem.UpdateTime = DateTime.Now;

                string classes = form["Classes"];
                string teacher = form["Teachers"];
                List<TeachingTaskTeacher> _teacher = null;
                List<String> _class = null;

                #region 计算出应该保存的class

                if (!String.IsNullOrEmpty(classes))
                {
                    _class = new List<String>();
                    foreach (var item in classes.Split(','))
                    {
                        _class.Add(item.Trim());
                    }
                }

                #endregion

                #region 找需要删除的，删掉

                if (newItem.Classes != null)
                {
                    List<TeachingTaskClass> remove_class = new List<TeachingTaskClass>();
                    foreach (var item in newItem.Classes)
                    {
                        if (!_class.Contains(item.ClassId))
                        {
                            remove_class.Add(item);
                        }
                    }

                    foreach (var r in remove_class)
                    {
                        newItem.Classes.Remove(r);
                    }
                }

                #endregion

                #region 找需要添加的，添加

                List<TeachingTaskClass> add_class = new List<TeachingTaskClass>();
                if (_class != null)
                {
                    foreach (var item in _class)
                    {
                        if (newItem.Classes == null ||
                            newItem.Classes.Where(r => r.ClassId == item).FirstOrDefault() == null)
                        {
                            add_class.Add(new TeachingTaskClass() {ClassId = item});
                        }
                    }
                }

                if (add_class.Count != 0)
                {
                    if (newItem.Classes == null) //有可能之前是空的
                        newItem.Classes = new List<TeachingTaskClass>();

                    foreach (var r in add_class)
                    {
                        newItem.Classes.Add(r);
                    }
                }

                #endregion


                #region 计算出应该保存的teacher

                if (!String.IsNullOrEmpty(teacher))
                {
                    _teacher = new List<TeachingTaskTeacher>();
                    foreach (var item in teacher.Split(','))
                    {
                        _teacher.Add(new TeachingTaskTeacher() {TeacherId = item.Trim()});
                    }
                }

                #endregion

                #region 找需要删除的，删掉

                if (newItem.Teachers != null)
                {
                    List<TeachingTaskTeacher> remove_Teacher = new List<TeachingTaskTeacher>();
                    foreach (var item in newItem.Teachers)
                    {
                        if (_teacher.Where(r => r.TeacherId == item.TeacherId).FirstOrDefault() == null)
                        {
                            remove_Teacher.Add(item);
                        }
                    }

                    foreach (var r in remove_Teacher)
                    {
                        newItem.Teachers.Remove(r);
                    }
                }

                #endregion

                #region 找需要添加的，添加

                List<TeachingTaskTeacher> add_Teacher = new List<TeachingTaskTeacher>();
                if (_teacher != null)
                {
                    foreach (var item in _teacher)
                    {
                        if (newItem.Teachers == null ||
                            newItem.Teachers.Where(r => r.TeacherId == item.TeacherId).FirstOrDefault() == null)
                        {
                            add_Teacher.Add(item);
                        }
                    }
                }

                if (add_Teacher.Count != 0)
                {
                    if (newItem.Teachers == null) //有可能之前是空的
                        newItem.Teachers = new List<TeachingTaskTeacher>();

                    foreach (var r in add_Teacher)
                    {
                        newItem.Teachers.Add(r);
                    }
                }

                #endregion

                await _TeachingTaskService.Update(newItem);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: TeachingTask/Detail/5
        public ActionResult Detail(string id, string searchKey)
        {
            ViewData["searchKey"] = searchKey;
            ViewBag.Details = this._TeachingTaskDetailService.GetAll().Where(b =>
                b.TeachingTaskId == id && (searchKey == null || b.ClaRoomCode.Contains(searchKey)));

            ViewBag.TeachingTaskId = id;

            return View();
        }


        // GET: TeachingTask/Detail/5
        public ActionResult Detail2(string id, string searchKey)
        {
            ViewData["searchKey"] = searchKey;
            ViewBag.Details = this._TeachingTaskDetailService.GetAll().Where(b =>
                b.TeachingTaskId == id && (searchKey == null || b.ClaRoomCode.Contains(searchKey)));

            ViewBag.TeachingTaskId = id;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var model = _TeachingTaskService.Find(b => b.TeachingTaskId == id);
            if (model != null)
            {
                await _TeachingTaskService.Remove(model);
                return Json(new AjaxResult("操作成功") {result = 1});
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") {result = 0});
            }
        }


        //[HttpPost]
        //public async Task<IActionResult> DeleteDetail(int id)
        //{
        //    var model = _TeachingTaskDetailService.Find(b => b.TeachingTaskDetailId == id);
        //    if (model != null)
        //    {
        //        await _TeachingTaskDetailService.Remove(model);
        //        return Json(new AjaxResult("操作成功") { result = 1 });
        //    }
        //    else
        //    {
        //        return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> DeleteDetail(string id, int week, int section)
        {
            var model = _TeachingTaskDetailService.Find(b =>
                b.TeachingTaskId == id && (int) b.Week == week && (int) b.Section == section);
            if (model != null)
            {
                await _TeachingTaskDetailService.Remove(model);
                return Json(new AjaxResult("操作成功") {result = 1});
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") {result = 0});
            }
        }


        [HttpPost]
        public async Task<IActionResult> Push(string id)
        {
            var model = _TeachingTaskService.GetAll().Include(r => r.Classes).Include(r => r.Teachers)
                .Where(b => b.TeachingTaskId == id).FirstOrDefault();
            if (model != null)
            {
                TeachingPlan tp = new TeachingPlan();
                tp.TeachingTaskId = id;
                tp.CourseId = model.CourseId;
                tp.Term = model.Term;
                tp.UseSta = 0;
                tp.SubSta = 0;

                #region class

                var _class = new List<TeachingPlanClass>();

                if (model.Classes != null)
                {
                    foreach (var item in model.Classes)
                    {
                        _class.Add(new TeachingPlanClass() {ClassId = item.ClassId});
                    }
                }

                tp.Class = _class;

                #endregion

                #region teacher

                var _teacher = new List<TeachingPlanTeacher>();

                if (model.Teachers != null)
                {
                    foreach (var item in model.Teachers)
                    {
                        _teacher.Add(new TeachingPlanTeacher() {TeacherId = item.TeacherId});
                    }
                }

                tp.Teacher = _teacher;

                #endregion

                await _TeachingPlanService.Add(tp);

                model.IsPush = true;
                await _TeachingTaskService.Update(model);
                return Json(new AjaxResult("操作成功") {result = 1});
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") {result = 0});
            }
        }
    }
}


