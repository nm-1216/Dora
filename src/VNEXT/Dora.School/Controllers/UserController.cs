namespace Dora.School.Controllers
{
    using Core;
    using Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Dora.ViewModels.AccountViewModels;
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

    [Authorize]
    public class UserController : Controller
    {
        private readonly ILogger _logger;
        private IStudentService _StudentService;
        private ITeacherService _TeacherService;

        private readonly UserManager<SchoolUser> _userManager;
        private readonly SignInManager<SchoolUser> _signInManager;
        protected readonly RoleManager<SchoolRole> _roleManager;

        public UserController(
            RoleManager<SchoolRole> roleManager,
            ILoggerFactory loggerFactory,
            IStudentService studentService,
            ITeacherService teacherService,
            UserManager<SchoolUser> userManager,
            SignInManager<SchoolUser> signInManager
            )
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._StudentService = studentService;
            this._TeacherService = teacherService;
            this._logger = loggerFactory.CreateLogger<UserController>();
        }


        public IActionResult Index(string searchKey, int page=1)
        {
            ViewData["searchKey"] = searchKey;

            var roles = _roleManager.Roles;
            var list = new PageList<SchoolUser>(_userManager.Users.Include(b => b.Roles).Include(b => b.Teacher).Include(b => b.Student)
                .Where(b => string.IsNullOrEmpty(searchKey)
                || b.Teacher.Name.Contains(searchKey)
                || b.Student.Name.Contains(searchKey)
                || b.UserName.Contains(searchKey)

                )
                , page, 10);
            ViewBag.roles = roles;
            return View(list);
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
                        sheet = workbook.GetSheet("学生");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var code = GetValue(row.GetCell(0));
                    var name = GetValue(row.GetCell(1));
                    var idCard = GetValue(row.GetCell(2));

                    if (!code.Equals("学号") || !name.Equals("姓名") || !idCard.Equals("身份证"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") { result = 0 });
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

            return new JsonResult(new AjaxResult("导入成功"));
        }

        public async Task<IActionResult> ImportTeacher([FromServices]IHostingEnvironment env, IList<IFormFile> files)
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
                        sheet = workbook.GetSheet("教师");
                        if (sheet == null)
                            sheet = workbook.GetSheetAt(0);
                    }

                    IRow row = sheet.GetRow(0);
                    var code = GetValue(row.GetCell(0));
                    var name = GetValue(row.GetCell(1));
                    var idCard = GetValue(row.GetCell(2));

                    if (!code.Equals("工号") || !name.Equals("姓名") || !idCard.Equals("身份证"))
                    {
                        return new JsonResult(new AjaxResult("EXCEL文件格式不正确") { result = 0 });
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

            return new JsonResult(new AjaxResult("导入成功"));
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ResetPassword(string id, string pwd,string okPwd)
        {
            if (string.IsNullOrEmpty(pwd) || pwd != okPwd)
            {
                return Json(new AjaxResult("操作失败,两次密码不一致") { result = 0 });
            }

            var model = await _userManager.FindByIdAsync(id);
            if (model != null)
            {
                await _userManager.AddPasswordAsync(model, pwd);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var model = await _userManager.FindByIdAsync(id);
            if (model != null)
            {
                await _userManager.DeleteAsync(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public IActionResult SetRole(string id)
        {
            var user = _userManager.Users.Include(b=>b.Roles).FirstOrDefault(b=>b.Id==id);

            var temp = new List<SelectListItem>();
            var list = _roleManager.Roles.OrderBy(b => b.Index);

            foreach (var item in list)
            {
                temp.Add(new SelectListItem() { Text = item.Name, Value = item.NormalizedName, Selected = user.Roles.Where(b=>b.RoleId==item.Id).Count()>0 });
            }

            ViewBag.user = user;

            return View(temp);
        }

        [HttpPost]
        public async Task<IActionResult> SetRole(string id, List<string> roleIds)
        {

            var user = _userManager.Users.Include(b => b.Roles).FirstOrDefault(b => b.Id == id);

            if (user.Roles != null && user.Roles.Count > 0)
            {
                var roles = _roleManager.Roles;
                await _userManager.RemoveFromRolesAsync(user, roles.Where(c => user.Roles.Select(b => b.RoleId).Contains(c.Id)).Select(b => b.NormalizedName));
            }
            
            await _userManager.AddToRolesAsync(user, roleIds);

            //await _PermissionService.AddRange(role.Permissions);

            return Content("操作成功");
        }

        #region Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new SchoolUser { Id = model.Uname, UserName = model.Uname, Email = model.Uname + "@School.com", UserType = SchoolUserType.other };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");

                    return Content("操作成功");
                    //return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion


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