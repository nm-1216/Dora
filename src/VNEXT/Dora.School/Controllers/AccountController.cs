namespace Dora.School.Controllers
{
    using Dora.Domain.Entities.School;
    using Dora.ViewModels.ManageViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Text;

    [Authorize]
    public class AccountController : BaseUserController<AccountController>
    {
        private readonly SignInManager<SchoolUser> _signInManager;

        public AccountController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory, SignInManager<SchoolUser> signInManager) : base(roleManager, userManager, loggerFactory)
        {
            _signInManager = signInManager;
        }

        #region Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var roles = await _userManager.GetRolesAsync(user);

            var list = _roleManager.Roles
                .Include(b => b.Permissions)
                .ThenInclude(c => c.ModuleType)
                .ThenInclude(d => d.Modules)
                .Where(b => roles.Contains(b.Name))
                .OrderBy(b => b.Index);

            return View(list);
        }
        #endregion

        #region Info
        [HttpGet]
        public async Task<IActionResult> SetInfo()
        {
            return View(await GetCurrentUserAsync());
        }

        public async Task<IActionResult> SetInfo(int pageSize = 10)
        {
            var user = await GetCurrentUserAsync();
            if (pageSize > 0)
            {
                user.PageSize = pageSize;
            }

            await _userManager.UpdateAsync(user);

            ModelState.AddModelError(string.Empty, "修改成功");

            return View(user);
        }
        #endregion

        #region ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(ManageMessage), new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                AddErrors(result);
                return View(model);
            }

            return RedirectToAction(nameof(ManageMessage), new { Message = ManageMessageId.Error });
        }
        #endregion

        #region GetMenu
        public async Task<IActionResult> GetMenu()
        {
            var user = await GetCurrentUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            var list = _roleManager.Roles
                .Include(b => b.Permissions)
                .ThenInclude(c => c.ModuleType)
                .ThenInclude(d => d.Modules)
                .Where(b => roles.Contains(b.Name))
                .OrderBy(b => b.Index);

            string nav = @"<li><a class=""has-arrow"" href=""#""><span class=""fa fa-fw fa-github fa-lg""></span>{0}</a>";
            string href = @"<li><a href=""{1}""><span class=""fa fa-fw fa-code-fork""></span>{0}</a></li>";
            string ul = @"<ul aria-expanded=""true"">";
            string ulend = @"</ul>";
            string li = @"<li>";
            string liend = @"</li>";

            StringBuilder sb = new StringBuilder();
            if (list.Count() > 1)
            {
                foreach (var item in list)
                {
                    sb.Append(li);
                    sb.AppendFormat(nav, item.Name);
                    sb.Append(ul);
                    foreach (var Permission in item.Permissions.OrderBy(b => b.ModuleType.Index))
                    {
                        sb.Append(li);
                        sb.AppendFormat(nav, Permission.ModuleType.Name);
                        sb.Append(ul);

                        foreach (var m in Permission.ModuleType.Modules.OrderBy(b => b.Index))
                        {
                            sb.AppendFormat(href, m.Name, m.Url);
                        }

                        sb.Append(ulend);
                        sb.Append(liend);
                    }
                    sb.Append(ulend);
                    sb.Append(liend);
                }
            }
            else
            {
                foreach (var Permission in list.First().Permissions.OrderBy(b => b.ModuleType.Index))
                {
                    sb.Append(li);
                    sb.AppendFormat(nav, Permission.ModuleType.Name);
                    sb.Append(ul);

                    foreach (var m in Permission.ModuleType.Modules.OrderBy(b => b.Index))
                    {
                        sb.AppendFormat(href, m.Name, m.Url);
                    }

                    sb.Append(ulend);
                    sb.Append(liend);
                }
            }




            return Json(sb.ToString());


        }
        #endregion

        #region LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Response.Cookies.Delete("SchoolUser-Name");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #endregion

        public async Task<IActionResult> LoginUser()
        {

            string value = string.Empty;
            if (HttpContext.Request.Cookies.ContainsKey("SchoolUser-Name"))
            {
                HttpContext.Request.Cookies.TryGetValue("SchoolUser-Name", out value);
            }
            else
            {
                var user = await GetCurrentUserAsync();
                user = _userManager.Users.Include(b => b.Student).Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);
                value = user.Teacher != null ? user.Teacher.Name : user.Student != null ? user.Student.Name : user.UserName;
                HttpContext.Response.Cookies.Append("SchoolUser-Name", value);
            }

            return Json(value);
        }

        #region helper
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