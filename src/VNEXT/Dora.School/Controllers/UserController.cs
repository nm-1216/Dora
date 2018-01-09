namespace Dora.School.Controllers
{
    using Core;
    using Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
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

    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private IStudentService _StudentService;
        private ITeacherService _TeacherService;

        private readonly UserManager<SchoolUser> _userManager;
        private readonly SignInManager<SchoolUser> _signInManager;


        public UserController(
            ILoggerFactory loggerFactory,
            IStudentService studentService,
            ITeacherService teacherService,
            UserManager<SchoolUser> userManager,
            SignInManager<SchoolUser> signInManager
            )
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._StudentService = studentService;
            this._TeacherService = teacherService;
            this._logger = loggerFactory.CreateLogger<UserController>();
        }


        public IActionResult Index()
        {
            return View(_userManager.Users.Where(b=>b.Student==null && b.Teacher==null));
        }

        public IActionResult Student(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;
            
            var list = new PageList<Student>(_StudentService.GetAll().Include(b=>b.Class)
                .Include(b=>b.SchoolUser)
                .Where(
                b => string.IsNullOrEmpty(searchKey) || 
                b.StudentId.Contains(searchKey) || 
                b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

        public IActionResult Teacher(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<Teacher>(_TeacherService.GetAll().Include(b => b.Department)
                .Where(b => string.IsNullOrEmpty(searchKey) || b.TeacherId.Contains(searchKey) || b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

       


        public async Task<IActionResult> ImportStudent([FromServices]IHostingEnvironment env, IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".xls") && !fileExtension.Equals(".xlsx"))
                {
                    return new JsonResult(new AjaxResult("�ļ���ʽ����ȷ") { result = 0 });
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

                    if (fileExtension.Equals(".xlsx")) // 2007�汾
                        workbook = new XSSFWorkbook(Read);
                    else
                        workbook = new HSSFWorkbook(Read);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheet("ѧ��");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var code = GetValue(row.GetCell(0));
                    var name = GetValue(row.GetCell(1));
                    var idCard = GetValue(row.GetCell(2));

                    if (!code.Equals("ѧ��") || !name.Equals("����") || !idCard.Equals("���֤"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL�ļ���ʽ����ȷ") { result = 0 });
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null) continue;

                        code = GetValue(row.GetCell(0));
                        name = GetValue(row.GetCell(1));
                        idCard = GetValue(row.GetCell(2));

                        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(idCard))
                        {
                            var model= await _userManager.FindByIdAsync(code);
                            if (model != null)
                                continue;

                            var user = new SchoolUser
                            {
                                Id = code,
                                UserName = code,
                                Email = code + "@School.com",
                                UserType = SchoolUserType.student,
                                Student = new Domain.Entities.School.Student()
                                {
                                    Name = name,
                                    IdCard = idCard,
                                    Status=1
                                }
                            };
                            var result = await _userManager.CreateAsync(user, code);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            return new JsonResult(new AjaxResult("����ɹ�"));
        }

        public async Task<IActionResult> ImportTeacher([FromServices]IHostingEnvironment env, IList<IFormFile> files)
        {
            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".xls") && !fileExtension.Equals(".xlsx"))
                {
                    return new JsonResult(new AjaxResult("�ļ���ʽ����ȷ") { result = 0 });
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

                    if (fileExtension.Equals(".xlsx")) // 2007�汾
                        workbook = new XSSFWorkbook(Read);
                    else
                        workbook = new HSSFWorkbook(Read);

                    if (workbook != null)
                    {
                        sheet = workbook.GetSheet("��ʦ");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var code = GetValue(row.GetCell(0));
                    var name = GetValue(row.GetCell(1));
                    var idCard = GetValue(row.GetCell(2));

                    if (!code.Equals("����") || !name.Equals("����") || !idCard.Equals("���֤"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL�ļ���ʽ����ȷ") { result = 0 });
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int i = 1; i <= rowCount; i++)
                    {
                        row = sheet.GetRow(i);
                        if (row == null) continue;

                        code = GetValue(row.GetCell(0));
                        name = GetValue(row.GetCell(1));
                        idCard = GetValue(row.GetCell(2));

                        if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(idCard))
                        {
                            var model = await _userManager.FindByIdAsync(code);
                            if (model != null)
                                continue;

                            var user = new SchoolUser
                            {
                                Id = code,
                                UserName = code,
                                Email = code + "@School.com",
                                UserType = SchoolUserType.teacher,
                                Teacher = new Domain.Entities.School.Teacher()
                                {
                                    Name = name,
                                    IdCard = idCard,
                                    Status = 1,
                                }
                            };
                            var result = await _userManager.CreateAsync(user, code);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            return new JsonResult(new AjaxResult("����ɹ�"));
        }


        

        #region Helpers



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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
        #region
        public string ManageMessage(ManageMessageId? message = null)
        {
            var StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";
            return StatusMessage;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            AddLoginSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }
        #endregion

    }
}