namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ModuleController : Controller
    {
        private readonly ILogger _logger;
        private readonly IModuleService _ModuleService;
        private readonly IModuleTypeService _ModuleTypeService;


        public ModuleController(
            ILoggerFactory loggerFactory,
            IModuleService moduleService,
            IModuleTypeService moduleTypeService
            )
        {
            this._logger = loggerFactory.CreateLogger<ModuleController>();

            this._ModuleService = moduleService;
            this._ModuleTypeService = moduleTypeService;
        }

        public IActionResult Index()
        {
            var temp = new List<SelectListItem>();
            var list = _ModuleTypeService.GetAll();

            foreach (var item in list)
            {
                temp.Add(new SelectListItem() { Text = item.Name, Value = item.ModuleTypeId });
            }
            ViewBag.moduleType = temp;
            ViewData["moduleType"] = temp;

            return View(_ModuleService.GetAll().OrderByDescending(b=>b.CreateTime));
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

        public async Task<IActionResult> Edit(Module model)
        {
            var item = _ModuleService.Find(b => b.ModuleId == model.ModuleId);

            if (item != null)
            {
                item.Name = model.Name;
                item.Url = model.Url;
                item.ModuleTypeId = model.ModuleTypeId;
                item.UpdateTime = DateTime.Now;

                await _ModuleService.Update(item);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public async Task<IActionResult> AddModule(string name, string url, string moduleType)
        {
            await _ModuleService.Add(new Domain.Entities.School.Module() { Name = name, Url = url, ModuleTypeId = moduleType });

            return Json(new AjaxResult("操作成功") { result = 1 });
        }

        public async Task<IActionResult> AddModuleType(string name)
        {

            var model = _ModuleTypeService.Find(b => b.Name == name);
            if (model == null)
            {
                await _ModuleTypeService.Add(new Domain.Entities.School.ModuleType() { Name = name });
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败，数据已存在") { result = 0 });
            }
        }
    }
}