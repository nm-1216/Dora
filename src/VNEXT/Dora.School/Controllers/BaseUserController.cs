namespace Dora.School.Controllers
{
    using Dora.Domain.Entities.School;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Linq;
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

        protected async Task<string> ReadCookies(string key)
        {
            string value = string.Empty;
            if (HttpContext.Request.Cookies.ContainsKey(key))
            {
                HttpContext.Request.Cookies.TryGetValue(key, out value);
                return value;
            }
            else
            {
                await WriteCookies();
                return await ReadCookies(key);
            }
        }

        protected async Task WriteCookies()
        {
            var user = await GetCurrentUserAsync();
            user = _userManager.Users.Include(b => b.Student).Include(b => b.Teacher).FirstOrDefault(b => b.Id == user.Id);
            string value = user.Teacher != null ? user.Teacher.Name : user.Student != null ? user.Student.Name : user.UserName;
            HttpContext.Response.Cookies.Append("SchoolUser-Name", value);
            HttpContext.Response.Cookies.Append("SchoolUser-PageSize", user.PageSize.ToString());
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
                return RedirectToAction(nameof(AccountController.Index), "Account");
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