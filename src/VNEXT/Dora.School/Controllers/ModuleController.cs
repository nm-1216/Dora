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
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModuleController : BaseUserController<ModuleController>
    {
        private readonly IModuleService _ModuleService;
        private readonly IModuleTypeService _ModuleTypeService;

        public ModuleController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , IModuleService moduleService, IModuleTypeService moduleTypeService) : base(roleManager, userManager, loggerFactory)
        {
            this._ModuleService = moduleService;
            this._ModuleTypeService = moduleTypeService;
        }

        public IActionResult Index(string moduleTypeId, string searchKey)
        {
            ViewData["searchKey"] = searchKey;

            var temp = new List<SelectListItem>();
            var list = _ModuleTypeService.GetAll().OrderBy(b => b.Discription).ThenBy(b => b.Index);

            foreach (var item in list)
            {
                temp.Add(new SelectListItem() { Text = string.Format("{0}-{1}", item.Discription, item.Name), Value = item.ModuleTypeId, Selected = item.ModuleTypeId == moduleTypeId });
            }

            List<SelectListItem> temp1 = new List<SelectListItem>(temp);
            temp1.Insert(0, new SelectListItem() { Text = "==请选择分类==", Value = string.Empty });
            temp1.ForEach(i => i.Selected = i.Value == moduleTypeId);

            ViewBag.moduleType = temp;
            ViewBag.moduleTypeForSearch = temp1;


            return View(_ModuleService.GetAll()
                .Where(b => (string.IsNullOrEmpty(moduleTypeId) || b.ModuleTypeId == moduleTypeId) && (string.IsNullOrEmpty(searchKey) || b.Name.Contains(searchKey)))
                .OrderBy(b => b.ModuleType.Discription).ThenBy(b => b.ModuleType.Index).ThenBy(b => b.Index));
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
                if (!string.IsNullOrEmpty(model.Name))
                    item.Name = model.Name;

                if (!string.IsNullOrEmpty(model.ModuleTypeId))
                    item.ModuleTypeId = model.ModuleTypeId;

                item.Url = model.Url ?? string.Empty;
                item.UpdateTime = DateTime.Now;

                if (!string.IsNullOrEmpty(Ico))
                    item.Ico = Ico;

                if (model.Index > 0)
                    item.Index = model.Index;

                await _ModuleService.Update(item);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public async Task<IActionResult> AddModule([FromServices]IHostingEnvironment env, string name, string url, string moduleType, IList<IFormFile> files, int index = 1)
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

            await _ModuleService.Add(new Domain.Entities.School.Module() { Name = name, Url = url, ModuleTypeId = moduleType, Ico = Ico, Index = index > 0 ? index : 1 });

            return Json(new AjaxResult("操作成功") { result = 1 });
        }

        public async Task<IActionResult> AddModuleType(string name, string discription, int index = 1)
        {

            var model = _ModuleTypeService.Find(b => b.Name == name);
            if (model == null)
            {
                await _ModuleTypeService.Add(new Domain.Entities.School.ModuleType() { Name = name, Discription = discription, Index = index > 0 ? index : 1 });
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败，数据已存在") { result = 0 });
            }
        }
    }
}