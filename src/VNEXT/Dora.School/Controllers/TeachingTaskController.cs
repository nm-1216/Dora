namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Dora.ViewModels.Extensions;
    using Microsoft.AspNetCore.Authorization;
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
        private ICourseService _CourseService;
        private ISyllabusTeacherService _SyllabusTeacherService;

        public TeachingTaskController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
         , IClassService classService
         , ITeachingTaskService teachingTaskService
         , ICourseService CourseService
         , ISyllabusTeacherService SyllabusTeacherService
            ) : base(roleManager, userManager, loggerFactory)
        {
            _ClassService = classService;
            _TeachingTaskService = teachingTaskService;
            _CourseService = CourseService;
            _SyllabusTeacherService = SyllabusTeacherService;
        }

        public IActionResult Index()
        {
            var list = _TeachingTaskService.GetAll();

            return View(list);
        }

        #region 导入
        public async Task<IActionResult> ImportTeachingTask([FromServices]IHostingEnvironment env, IList<IFormFile> files)
        {
            var _list = new List<TeachingTask>();

            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".xls") && !fileExtension.Equals(".xlsx"))
                {
                    return new JsonResult(new AjaxResult("文件格式不正确") { result = 0 });
                }

                var dir = Path.Combine(env.WebRootPath, "upload", "temp", DateTime.Now.ToString("yyMMdd"));
                var fileName = Path.Combine(env.WebRootPath, "upload", "temp", DateTime.Now.ToString("yyMMdd"), Guid.NewGuid() + fileExtension).ToLower();
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
                    var ClaRoomCode = GetValue(row.GetCell(6));
                    var Week = GetValue(row.GetCell(7));
                    var Section = GetValue(row.GetCell(8));
                    var Memo = GetValue(row.GetCell(9));

                    if (!course.Equals("课程")
                    || !term.Equals("学期")
                    || !term.Equals("学期")
                    || !classes.Equals("班级")
                    || !BegWeek.Equals("开始周次")
                    || !EndWeek.Equals("结束周次")
                    || !ClaRoomCode.Equals("教室编号")
                    || !Week.Equals("星期")
                    || !Section.Equals("上课节次")
                    || !Memo.Equals("备注"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") { result = 0 });
                    }



                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null)
                            continue;

                        course = GetValue(row.GetCell(0));
                        teacher = GetValue(row.GetCell(1));
                        term = GetValue(row.GetCell(2));
                        classes = GetValue(row.GetCell(3));
                        BegWeek = GetValue(row.GetCell(4));
                        EndWeek = GetValue(row.GetCell(5));
                        ClaRoomCode = GetValue(row.GetCell(6));
                        Week = GetValue(row.GetCell(7));
                        Section = GetValue(row.GetCell(8));
                        Memo = GetValue(row.GetCell(9));

                        if (string.IsNullOrEmpty(course))
                            continue;

                        if (!string.IsNullOrEmpty(course)
                            && !string.IsNullOrEmpty(teacher)
                            && !string.IsNullOrEmpty(term)
                            && !string.IsNullOrEmpty(classes)
                            && !string.IsNullOrEmpty(BegWeek)
                            && !string.IsNullOrEmpty(EndWeek)
                            && !string.IsNullOrEmpty(ClaRoomCode)
                            && !string.IsNullOrEmpty(Week)
                            && !string.IsNullOrEmpty(Section))//备注可以为空
                        {
                            var _teacher = new List<TeachingTaskTeacher>();
                            var _class = new List<TeachingTaskClass>();

                            foreach (var item in classes.Split(','))
                            {
                                _class.Add(new TeachingTaskClass() { ClassId = item.Trim() });
                            }

                            foreach (var item in teacher.Split(','))
                            {
                                _teacher.Add(new TeachingTaskTeacher() { TeacherId = item.Trim() });
                            }

                            //教学任务
                            var model = new Domain.Entities.School.TeachingTask()
                            {
                                Term = term,
                                BegWeek = Convert.ToInt32(BegWeek),
                                EndWeek = Convert.ToInt32(EndWeek),
                                ClaRoomCode = ClaRoomCode,
                                Week = Week,
                                Section = ((SectionType)Convert.ToInt32(Section)),
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

                foreach (var item in classes.Split(','))
                {
                    _class.Add(new TeachingTaskClass() { ClassId = item.Trim() });
                }

                foreach (var item in teacher.Split(','))
                {
                    _teacher.Add(new TeachingTaskTeacher() { TeacherId = item.Trim() });
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
            var model = this._TeachingTaskService.Find(b => b.TeachingTaskId == id);
            //GetAll().Include(r=> r.Teachers).Include(r=> r.Classes).Where

            #region 上课节次
            List<SelectListItem> type;
            type = ((Enum)SectionType.节1_2).ToSelectListItem(model.Section.ToString());

            ViewBag.SectionType = type;
            #endregion

            #region 教师
            String strTeachers = "";
            var _teachers = model.Teachers;
            foreach (var item in _teachers)
            {
                strTeachers += item.TeacherId + ",";
            }
            ViewBag.Teacher = strTeachers.Length > 0 ? strTeachers.Substring(0, strTeachers.Length - 1) : "";
            #endregion

            #region 班级 
            String strClasses = "";
            var _Classes = model.Classes;
            foreach (var item in _Classes)
            {
                strClasses += item.ClassId + ",";
            }
            ViewBag.Class = strClasses.Length > 0 ? strClasses.Substring(0, strClasses.Length - 1) : "";
            #endregion

            return View(model);
        }

        // POST: TeachingTask/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TeachingTask model,IFormCollection form)
        {
            try
            {
                var newItem = this._TeachingTaskService.Find(b => b.TeachingTaskId == model.TeachingTaskId);

                newItem.Term = model.Term;
                newItem.BegWeek = model.BegWeek;
                newItem.EndWeek = model.EndWeek;
                newItem.ClaRoomCode = model.ClaRoomCode;
                newItem.Week = model.Week;
                newItem.Section = model.Section;
                newItem.Memo = model.Memo;
                newItem.CourseId = model.CourseId; 
                newItem.UpdateTime = DateTime.Now;

                string classes = form["Classes"];
                string teacher = form["Teachers"];
                var _teacher = new List<TeachingTaskTeacher>();
                var _class = new List<TeachingTaskClass>();

                foreach (var item in classes.Split(','))
                {
                    _class.Add(new TeachingTaskClass() { ClassId = item.Trim() });
                }

                foreach (var item in teacher.Split(','))
                {
                    _teacher.Add(new TeachingTaskTeacher() { TeacherId = item.Trim() });
                }

                model.Classes = _class;
                model.Teachers = _teacher;

                await _TeachingTaskService.Update(newItem);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
         
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var model =  _TeachingTaskService.Find(b => b.TeachingTaskId == id);
            if (model != null)
            {
                await _TeachingTaskService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

      
    }
}