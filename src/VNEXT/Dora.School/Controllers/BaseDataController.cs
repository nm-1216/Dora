﻿
using Dora.Services.School;

namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Dora.Helpers;


    [EnableCors("AllowSameDomain")]
    [Authorize]
    public class BaseDataController : BaseUserController<BaseDataController>
    {
        private ICourseService _CourseService;
        private IClassService _ClassService;
        private IHostingEnvironment _hostingEnvironment;

        public BaseDataController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory,
        ICourseService courseService,
        IClassService classService,
        IHostingEnvironment hostingEnvironment
        ) : base(roleManager, userManager, loggerFactory)
        {
            this._CourseService = courseService;
            this._ClassService = classService;
            this._hostingEnvironment = hostingEnvironment;
        }

        #region 班级
        public IActionResult ClassList(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<Class>(_ClassService.GetAll().Include(b=>b.Students)
                .Where(
                b => string.IsNullOrEmpty(searchKey) ||
                b.ClassId.Contains(searchKey) ||
                b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

        public async Task<IActionResult> EditClass(string id, string name)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name))
            {
                return new JsonResult(new AjaxResult("参数不能是空") {result = 0});
            }

            var model = _ClassService.Find(b => b.ClassId == id);

            if (model == null)
            {
                return new JsonResult(new AjaxResult("查询失败，班级是空") {result = 0});
            }
            else
            {
                model.Name = name;

                var rst = await _ClassService.Update(model);

                return new JsonResult(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 1 : 0});
            }
        }

        public async Task<IActionResult> DeleteClass(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new JsonResult(new AjaxResult("参数不能是空") {result = 0});
            }

            var model = _ClassService.Find(b => b.ClassId == id);

            if (model == null)
            {
                return new JsonResult(new AjaxResult("查询失败，班级是空") {result = 0});
            }
            else
            {
                var rst = await _ClassService.Remove(model);
                return new JsonResult(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 1 : 0});
            }
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
                    var code = NpoiHelper.GetValue(row.GetCell(0));
                    var name = NpoiHelper.GetValue(row.GetCell(1));
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

                        code = NpoiHelper.GetValue(row.GetCell(0));
                        name = NpoiHelper.GetValue(row.GetCell(1));

                        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name))
                        {
                            var model = _ClassService.Find(b => b.ClassId == code);

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

            var list = new PageList<Course1>(_CourseService.GetAll()
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
            var url = string.Empty;

            var CKEditorFuncNum = Request.Query["CKEditorFuncNum"];

            var filename = ContentDispositionHeaderValue.Parse(upload.ContentDisposition).FileName.Trim('"');
            var extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
            var NewFile = System.Guid.NewGuid().ToString() + extname;


            filename = _hostingEnvironment.WebRootPath + $@"/upload/{NewFile}";
            using (FileStream fs = System.IO.File.Create(filename))
            {
                upload.CopyTo(fs);
                fs.Flush();
            }

            url = "/upload/" + NewFile;
            return Json(new { uploaded = uploaded, fileName = NewFile, url = url });

           
        }

        public static string SaveFile(IHostingEnvironment hostingEnvironment, string dir, IFormFile upload)
        {

            var filename = ContentDispositionHeaderValue.Parse(upload.ContentDisposition).FileName.Trim('"');
            var extname = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
            var NewFile = System.Guid.NewGuid().ToString() + extname;
            filename = hostingEnvironment.WebRootPath + $@"/upload/{dir}/{NewFile}";


            var path = Path.Combine(hostingEnvironment.WebRootPath, "upload", dir);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            using (FileStream fs = System.IO.File.Create(filename))
            {
                upload.CopyTo(fs);
                fs.Flush();
            }

            return $@"/upload/{dir}/{NewFile}";
        }

        #region 组织架构

        #endregion

        #region 模块管理


        #endregion



    }
}