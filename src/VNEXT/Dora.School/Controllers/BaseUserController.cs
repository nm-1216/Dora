namespace Dora.School.Controllers
{
    using Dora.Domain.Entities.School;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public abstract class BaseUserController<T> : Controller
    {
        /// <summary>
        /// 日志
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// 用户
        /// </summary>
        protected readonly UserManager<SchoolUser> _userManager;

        /// <summary>
        /// 角色
        /// </summary>
        protected readonly RoleManager<SchoolRole> _roleManager;

        public BaseUserController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<T>();
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        protected async Task _user()
        {

            string value = string.Empty;
            if (HttpContext.Request.Cookies.ContainsKey("SchoolUser-Name"))
            {
                HttpContext.Request.Cookies.TryGetValue("", out value);
            }
            else
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                value = user.Student != null ? user.Student.Name : user.Teacher != null ? user.Teacher.Name : user.UserName;
                HttpContext.Response.Cookies.Append("SchoolUser-Name", value);
            }

            ViewBag.Name = value;
        }


        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        protected Task<SchoolUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        protected IActionResult RedirectToLocal(string returnUrl)
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

        protected void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}