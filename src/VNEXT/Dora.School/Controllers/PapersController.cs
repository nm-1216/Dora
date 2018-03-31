using System.IO;
using System.Net.Mime;
using Dora.ViewModels.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class PapersController : BaseUserController<PapersController>
    {
        private readonly IPapersService _papersService;
        private readonly IPaperQuestionsService _paperQuestionsService;
        private readonly ICoursewareService _coursewareService;

        public PapersController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory,
            IPapersService papersService,
            IPaperQuestionsService paperQuestionsService,
            ICoursewareService coursewareService
        ) : base(roleManager, userManager, loggerFactory)
        {
            _papersService = papersService;
            _paperQuestionsService = paperQuestionsService;
            _coursewareService = coursewareService;
        }


        #region  Papers

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            user = _userManager.Users.Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);

            var list = _papersService.GetAll().Where(b=>b.TeacherId==user.Teacher.TeacherId).OrderByDescending(b=>b.CreateTime);;
            
            return View(list);
        }


        [HttpPost]
        public async Task<IActionResult> Create(string Title, string Description)
        {
            var user = await GetCurrentUserAsync();
            user = _userManager.Users.Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);

            await _papersService.Add(new Papers()
            {
                Title = Title,
                Description = Description,
                TeacherId = user.Teacher.TeacherId
            });

            return Json(new  AjaxResult("成功"){result = 0});
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Papers model)
        {
            var rst = false;
            var item = _papersService.Find(b => b.PaperId == model.PaperId);

            if (item != null)
            {
                item.Title = model.Title;
                item.Description = model.Description;
                item.UpdateTime = DateTime.Now;
                rst = await _papersService.Update(item);

                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }
            else
            {
                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var rst = false;

            if (string.IsNullOrEmpty(id))
            {
                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }

            var model = _papersService.Find(b => b.PaperId == id);

            rst = await _papersService.Remove(model);

            return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
        }

        #endregion


        #region Courseware

        public async Task<IActionResult> Courseware()
        {
            var user = await GetCurrentUserAsync();
            user = _userManager.Users.Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);

            var list = _coursewareService.GetAll().Where(b => b.TeacherId == user.Teacher.TeacherId).OrderByDescending(b=>b.CreateTime);

            return View(list);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> CoursewareCreate([FromServices]IHostingEnvironment env,string title,IList<IFormFile> files)
        {
            var user = await GetCurrentUserAsync();
            user = _userManager.Users.Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);

            var temp = string.Empty;
            if (files != null && files.Count > 0)
            {
                temp = BaseDataController.SaveFile(env, "Courseware", files[0]);
            }

            await _coursewareService.Add(new Courseware()
            {
                Title = title,
                TeacherId = user.Teacher.TeacherId,
                Url= temp
            });


            return Json(new  AjaxResult("成功"){result = 0});
        }

        [HttpPost]
        public async Task<IActionResult> CoursewareEdit([FromServices] IHostingEnvironment env, string id, string title,
            IList<IFormFile> files)
        {
            var user = await GetCurrentUserAsync();
            user = _userManager.Users.Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);

            var temp = string.Empty;
            if (files != null && files.Count > 0)
            {
                temp = BaseDataController.SaveFile(env, "Courseware", files[0]);
            }

            var model = _coursewareService.Find(b => b.CoursewareId == id);

            model.Title = title;
            if (!string.IsNullOrEmpty(temp))
                model.Url = temp;

            await _coursewareService.Update(model);


            return Json(new AjaxResult("成功") {result = 0});
        }

        [HttpPost]
        public async Task<IActionResult> CoursewareDelete(string id)
        {
            var rst = false;

            if (string.IsNullOrEmpty(id))
            {
                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }

            var model = _coursewareService.Find(b => b.CoursewareId == id);

            rst = await _coursewareService.Remove(model);

            return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
        }

        #endregion

        #region Questions

        public async Task<IActionResult> Questions(string id)
        {
            
            var QType = ((Enum) PaperQuestionType.单选).ToSelectListItem(PaperQuestionType.单选.ToString());

            var model = _papersService.Find(b => b.PaperId == id);

            //var user = await GetCurrentUserAsync();

            var list = _paperQuestionsService.Where(b => b.PaperId == id).OrderBy(b => b.Code).ThenByDescending(b => b.CreateTime);
                

            ViewBag.model = model;
            ViewBag.QType = QType;

            
            return View(list);
        }

        public async Task<IActionResult> ImportQuestions([FromServices] IHostingEnvironment env, IList<IFormFile> files,string id)
        {
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
                        sheet = workbook.GetSheet("Papers");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    //题号	题型	题目	分值	正确答案	选项一	选项二	选项三	选项四	选项五	选项六
                    
                    //题号
                    var Code = GetValue(row.GetCell(0));
                    //题型
                    var QType = GetValue(row.GetCell(1));
                    //题目
                    var Text = GetValue(row.GetCell(2));
                    //下一题
                    var Value = GetValue(row.GetCell(3));
                    //正确答案
                    var Answer = GetValue(row.GetCell(4));
                    //选项一
                    var Option1 = GetValue(row.GetCell(5));
                    //选项二
                    var Option2 = GetValue(row.GetCell(6));
                    //选项三
                    var Option3 = GetValue(row.GetCell(7));
                    //选项四
                    var Option4 = GetValue(row.GetCell(8));
                    //选项五
                    var Option5 = GetValue(row.GetCell(9));
                    //选项六
                    var Option6 = GetValue(row.GetCell(10));




                    //老系统ID 姓名  昵称 性别  地区 电话  邮箱 微博  单位 科室  职务 简介

                    if (!Code.Equals("题号")
                        || !QType.Equals("题型")
                        || !Text.Equals("题目")
                        || !Value.Equals("分值")
                        || !Answer.Equals("正确答案")
                        || !Option1.Equals("选项一")
                        || !Option2.Equals("选项二")
                        || !Option3.Equals("选项三")
                        || !Option4.Equals("选项四")
                        || !Option5.Equals("选项五")
                        || !Option6.Equals("选项六")
                    )
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") {result = 0});
                    }

                    int rowCount = sheet.LastRowNum;

                    IList<PaperQuestions> subjectList = new List<PaperQuestions>();

                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null) continue;

                        Code = GetValue(row.GetCell(0));
                        //题型
                        QType = GetValue(row.GetCell(1));
                        //题目
                        Text = GetValue(row.GetCell(2));
                        //下一题
                        Value = GetValue(row.GetCell(3));
                        //正确答案
                        Answer = GetValue(row.GetCell(4));
                        //选项一
                        Option1 = GetValue(row.GetCell(5));
                        //选项二
                        Option2 = GetValue(row.GetCell(6));
                        //选项三
                        Option3 = GetValue(row.GetCell(7));
                        //选项四
                        Option4 = GetValue(row.GetCell(8));
                        //选项五
                        Option5 = GetValue(row.GetCell(9));
                        //选项六
                        Option6 = GetValue(row.GetCell(10));


                        if (!string.IsNullOrEmpty(Text))
                        {
                            {
                                var user = new PaperQuestions()
                                {
                                    Code = int.Parse(Code),
                                    QType = (PaperQuestionType)Enum.Parse(typeof(PaperQuestionType), QType),
                                    Text = Text,
                                    Value = int.Parse(Value),
                                    Answer = Answer,
                                    Option1 = Option1,
                                    Option2 = Option2,
                                    Option3 = Option3,
                                    Option4 = Option4,
                                    Option5 = Option5,
                                    Option6 = Option6,
                                    PaperId = id
                                };
                                subjectList.Add(user);
                            }
                        }
                        
                        else
                        {
                            continue;
                        }
                    }

                    if (subjectList.Count > 0)
                        await _paperQuestionsService.AddRange(subjectList);
                }
            }

            var rst = true;
            return Json(new AjaxResult(rst ? "导入成功" : "导入失败") {result = rst ? 0 : 1});

        }

        public async Task<IActionResult> AddQuestions(string paperId, string text, string answer,
            PaperQuestionType qType, List<string> options, int value = 5)
        {
            var rst = false;

            if (string.IsNullOrEmpty(text))
            {
                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }

            var model = new PaperQuestions()
            {
                Text = text,
                PaperId = paperId,
                QType = qType,
                Value = value,
                Answer = answer.ToUpper()
            };

            model.Option1 = options[0];
            model.Option2 = options[1];
            model.Option3 = options[2];
            model.Option4 = options[3];
            model.Option5 = options[4];
            model.Option6 = options[5];

            rst = await _paperQuestionsService.Add(model);


            return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});

        }

        public async Task<IActionResult> EditQuestions(string id,string text, string answer,PaperQuestionType qType,  List<string> options,int value)
        {
            var rst = false;
            var model = _paperQuestionsService.Find(b => b.PaperQuestionId == id);

            if (model != null)
            {

                model.Text = text;
                model.QType = qType;
                model.Answer = answer.ToUpper();
                model.Value = value;
                
                model.Option1 = options[0];
                model.Option2 = options[1];
                model.Option3 = options[2];
                model.Option4 = options[3];            
                model.Option5 = options[4];
                model.Option6 = options[5];
                
                model.UpdateTime = DateTime.Now;
                rst = await _paperQuestionsService.Update(model);

                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }
            else
            {
                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }


        }
        
        public async Task<IActionResult> CreateCode(string id)
        {
            var rst = false;

            var list = _paperQuestionsService.Where(b => b.PaperId == id).OrderBy(b => b.Code)
                .ThenByDescending(b => b.CreateTime);

            int i = 1;
            foreach (var item in list)
            {
                item.Code = i;
                i++;
            }

            rst = await _paperQuestionsService.UpdateRange(list);
            
            return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
        }
        
        public async Task<IActionResult> NewCode(string id,List<string> list)
        {
            var rst = false;

            var modelList = _paperQuestionsService.Where(b => b.PaperId == id);

            for (int i = 0; i < list.Count; i++)
            {
                foreach (var item in modelList)
                {
                    if (item.PaperQuestionId == list[i])
                    {
                        item.Code = i + 1;
                    }
                }
            }


            rst = await _paperQuestionsService.UpdateRange(modelList);
            
            return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
        }
        
        public async Task<IActionResult> DeleteQuestions(string id)
        {
            var rst = false;

            if (string.IsNullOrEmpty(id))
            {
                return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});
            }

            var model = _paperQuestionsService.Find(b => b.PaperQuestionId == id);

            rst = await _paperQuestionsService.Remove(model);

            return Json(new AjaxResult(rst ? "成功" : "失败") {result = rst ? 0 : 1});

        }
        
        #endregion

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


                return doubleVal.ToString("0.####");
            }
            else
            {
                return cell.StringCellValue.Trim();
            }
        }
    }
}
