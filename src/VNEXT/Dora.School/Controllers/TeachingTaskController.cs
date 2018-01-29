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
            return View();
        }

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

    }
}