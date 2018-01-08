
/// <summary>
/// 基数数据 班级，课程，组织架构
/// </summary>
namespace Dora.School.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Dora.Repositorys.School.Interfaces;
    using Microsoft.Extensions.Logging;
    using Dora.Domain.Entities.School;
    using Dora.Core;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using System.IO;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using NPOI.HSSF.UserModel;
    using Dora.Services.School.Interfaces;
    using System.Net.Http.Headers;
    using Microsoft.AspNetCore.Cors;

    [EnableCors("AllowSameDomain")]
    public class BaseDataController : Controller
    {
        private readonly ILogger _logger;
        private ICourseRepository _CourseRepository;
        private IClassRepository _ClassRepository;
        private IClassService _ClassService;
        private IHostingEnvironment _hostingEnvironment;



        public BaseDataController(
            ILoggerFactory loggerFactory,
            ICourseRepository courseRepository,
            IClassRepository classRepository,
            IClassService classService,
            IHostingEnvironment hostingEnvironment
            )
        {
            this._ClassService = classService;
            this._ClassRepository = classRepository;
            this._CourseRepository = courseRepository;
            this._logger = loggerFactory.CreateLogger<UserController>();
            this._hostingEnvironment = hostingEnvironment;
        }

        #region 班级
        public IActionResult ClassList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<Class>(_ClassRepository.GetAll()
                .Where(
                b => string.IsNullOrEmpty(searchKey) ||
                b.ClassId.Contains(searchKey) ||
                b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

        public async Task<IActionResult> ImportClass([FromServices]IHostingEnvironment env, IList<IFormFile> files)
        {
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
                        sheet = workbook.GetSheet("班级");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var code = getValue(row.GetCell(0));
                    var name = getValue(row.GetCell(1));
                    //var idCard = getValue(row.GetCell(2));

                    if (!code.Equals("编码") || !name.Equals("名称"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") { result = 0 });
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null) continue;

                        code = getValue(row.GetCell(0));
                        name = getValue(row.GetCell(1));

                        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name))
                        {
                            var model = _ClassRepository.Find(b => b.ClassId == code);

                            if (model != null)
                                continue;

                            model = new Class
                            {
                                ClassId = code,
                                Name = name,
                                InviteCode = string.Empty,
                                Status = BaseStatus.有效
                            };
                            var result = await _ClassService.Add(model);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            return new JsonResult(new AjaxResult("导入成功"));
        }

        #endregion

        #region 课程
        public IActionResult CourseList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<Course>(_CourseRepository.GetAll()
                .Where(
                b => string.IsNullOrEmpty(searchKey) ||
                b.CourseId.Contains(searchKey) ||
                b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

        #endregion


        [HttpPost]
        [EnableCors("AllowSameDomain")]
        public JsonResult Ckeditor(IFormFile upload)
        {

            var uploaded = 1;
            //var fileName = string.Empty;
            var url = string.Empty;

            //HashTable<String, Object> map = new HashTable<String, Object>();

            //string Callback = @"{"uploaded": 1,"fileName": "","url": ""}";

            var CKEditorFuncNum = Request.Query["CKEditorFuncNum"];

            var filename = ContentDispositionHeaderValue.Parse(upload.ContentDisposition).FileName.Trim('"');
            var extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
            var NewFile = System.Guid.NewGuid().ToString() + extname;

            filename = _hostingEnvironment.WebRootPath + $@"\upload\{NewFile}";
            using (FileStream fs = System.IO.File.Create(filename))
            {
                upload.CopyTo(fs);
                fs.Flush();
            }

            url = "http://localhost:56417/upload/" + NewFile;
            //return Content(string.Format(Callback, CKEditorFuncNum, url), ContentType);
            return Json(new { uploaded= uploaded, fileName= NewFile, url= url });
        }

        #region 组织架构

        #endregion

        #region 模块管理


        #endregion

        private string getValue(ICell cell)
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