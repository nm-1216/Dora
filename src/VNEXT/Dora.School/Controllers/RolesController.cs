namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class RolesController : Controller
    {
        protected readonly RoleManager<SchoolRole> _roleManager;
        private readonly ILogger _logger;

        public RolesController(RoleManager<SchoolRole> roleManager, ILoggerFactory loggerFactory)
        {
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<RolesController>();
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _roleManager.Roles.OrderBy(b=>b.index);
            return View(list);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SchoolRole role)
        {
            if (ModelState.IsValid)
            {
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                await _roleManager.CreateAsync(role);
            }

            return Json(new AjaxResult("操作成功") { result = 1 });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SchoolRole model)
        {
            var item =await _roleManager.FindByIdAsync(model.Id);

            if (item != null)
            {
                item.Name = model.Name;
                item.index = model.index;

                await _roleManager.UpdateAsync(item);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var model = await _roleManager.FindByIdAsync(id);
            if (model != null)
            {
                await _roleManager.DeleteAsync(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

    }
}
