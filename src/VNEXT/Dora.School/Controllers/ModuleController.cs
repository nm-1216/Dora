namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModuleController : Controller
    {
        private readonly UserManager<SchoolUser> _userManager;
        private readonly ILogger _logger;
        private readonly IModuleService _ModuleService;
        private readonly IModuleTypeService _ModuleTypeService;
        protected readonly RoleManager<SchoolRole> _roleManager;

        public ModuleController(
            ILoggerFactory loggerFactory,
            IModuleService moduleService,
            RoleManager<SchoolRole> roleManager,
            UserManager<SchoolUser> userManager,
            IModuleTypeService moduleTypeService
            )
        {
            this._logger = loggerFactory.CreateLogger<ModuleController>();
            this._userManager = userManager;
            this._roleManager = roleManager;

            this._ModuleService = moduleService;
            this._ModuleTypeService = moduleTypeService;
        }

        public IActionResult Index()
        {
            var temp = new List<SelectListItem>();
            var list = _ModuleTypeService.GetAll().OrderBy(b => b.Discription);

            foreach (var item in list)
            {
                temp.Add(new SelectListItem() { Text = string.Format("{0}-{1}", item.Discription, item.Name), Value = item.ModuleTypeId });
            }
            ViewBag.moduleType = temp;
            ViewData["moduleType"] = temp;

            return View(_ModuleService.GetAll().OrderBy(b => b.ModuleType.Discription).OrderByDescending(b => b.CreateTime));
        }

        public async Task<IActionResult> Delete(string id)
        {
            var model = _ModuleService.Find(b => b.ModuleId == id);
            if (model != null)
            {
                await _ModuleService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public async Task<IActionResult> Edit([FromServices]IHostingEnvironment env, Module model, IList<IFormFile> files)
        {
            string Ico = string.Empty;

            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".jpg") && !fileExtension.Equals(".png") && !fileExtension.Equals(".gif"))
                {
                    return Json(new AjaxResult("文件格式不正确") { result = 0 });
                }

                var dir = Path.Combine(env.WebRootPath, "upload", "module");

                var guid = Guid.NewGuid();

                var fileName = Path.Combine(env.WebRootPath, "upload", "module", guid + fileExtension).ToLower();

                Ico = string.Format("/upload/module/{0}{1}", guid, fileExtension);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            var item = _ModuleService.Find(b => b.ModuleId == model.ModuleId);

            if (item != null)
            {
                item.Name = model.Name;
                item.Url = model.Url;
                item.ModuleTypeId = model.ModuleTypeId;
                item.UpdateTime = DateTime.Now;

                if (!string.IsNullOrEmpty(Ico))
                    item.Ico = Ico;

                await _ModuleService.Update(item);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public async Task<IActionResult> AddModule([FromServices]IHostingEnvironment env, string name, string url, string moduleType, IList<IFormFile> files)
        {
            name = name ?? string.Empty;
            url = url ?? string.Empty;
            string Ico = string.Empty;

            foreach (var file in files)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLower();

                if (!fileExtension.Equals(".jpg") && !fileExtension.Equals(".png") && !fileExtension.Equals(".gif"))
                {
                    return Json(new AjaxResult("文件格式不正确") { result = 0 });
                }

                var dir = Path.Combine(env.WebRootPath, "upload", "module");
                var guid = Guid.NewGuid();
                var fileName = Path.Combine(env.WebRootPath, "upload", "module", guid + fileExtension).ToLower();

                Ico = string.Format("/upload/module/{0}{1}", guid, fileExtension);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
            }

            await _ModuleService.Add(new Domain.Entities.School.Module() { Name = name, Url = url, ModuleTypeId = moduleType, Ico = Ico });

            return Json(new AjaxResult("操作成功") { result = 1 });
        }

        public async Task<IActionResult> AddModuleType(string name, string discription)
        {

            var model = _ModuleTypeService.Find(b => b.Name == name);
            if (model == null)
            {
                await _ModuleTypeService.Add(new Domain.Entities.School.ModuleType() { Name = name, Discription = discription });
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败，数据已存在") { result = 0 });
            }
        }

        public async Task<IActionResult> GetMenu()
        {
            var user = await GetCurrentUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            var list = _roleManager.Roles.Include(b => b.Permissions).ThenInclude(c => c.ModuleType).ThenInclude(d => d.Modules).Where(b => roles.Contains(b.Name));

            return Json(list.Select(b => new { b.Name, Permissions = b.Permissions.Select(c => new { c.ModuleType.Name, c.ModuleType.Modules }) }));
        }

        private Task<SchoolUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}