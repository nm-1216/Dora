namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RolesController : Controller
    {
        protected readonly RoleManager<SchoolRole> _roleManager;
        private readonly ILogger _logger;
        private readonly IPermissionService _PermissionService;
        private readonly IModuleTypeService _ModuleTypeService;

        public RolesController(RoleManager<SchoolRole> roleManager, ILoggerFactory loggerFactory, IPermissionService permissionService, IModuleTypeService moduleTypeService)
        {
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<RolesController>();
            _PermissionService = permissionService;
            _ModuleTypeService = moduleTypeService;
        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            var list = _roleManager.Roles.Include(b => b.Permissions).ThenInclude(b => b.ModuleType).OrderBy(b => b.Index);
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
            var item = await _roleManager.FindByIdAsync(model.Id);

            if (item != null)
            {
                item.Name = model.Name;
                item.Index = model.Index;

                await _roleManager.UpdateAsync(item);
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

        public async Task<IActionResult> SetPermission(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var permissions = _PermissionService.Where(b => b.RoleId == id);
            var temp = new List<SelectListItem>();
            var list = _ModuleTypeService.GetAll().OrderBy(b => b.Discription);

            foreach (var item in list)
            {
                temp.Add(new SelectListItem() { Text = string.Format("{0}-{1}", item.Discription, item.Name), Value = item.ModuleTypeId, Selected = permissions.Where(b => b.ModuleTypeId == item.ModuleTypeId).Count() > 0 });
            }

            ViewBag.role = role;

            return View(temp);
        }

        [HttpPost]
        public async Task<IActionResult> SetPermission(string id, List<string> ModuleTypeIds)
        {

            var role = _roleManager.Roles.Include(b => b.Permissions).FirstOrDefault(b => b.Id == id);

            if (role.Permissions != null && role.Permissions.Count > 0)
            {
                await _PermissionService.RemoveRange(role.Permissions);
            }
            else
            {
                role.Permissions = new List<Permission>();
            }


            foreach (var item in ModuleTypeIds)
            {
                role.Permissions.Add(new Permission(item, id));
            }

            await _PermissionService.AddRange(role.Permissions);

            return Content("操作成功");
        }
    }
}
