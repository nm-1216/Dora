 namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class TrainingLabController : BaseUserController<TrainingLabController>
    {
        private readonly IPermissionService _PermissionService;
        private readonly IModuleTypeService _ModuleTypeService;
        private readonly ITrainingLabService _TrainingLabService;

        public TrainingLabController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory,
      IPermissionService permissionService,
      IModuleTypeService moduleTypeService,
      ITrainingLabService trainingLabService
      ) : base(roleManager, userManager, loggerFactory)
        {
            _PermissionService = permissionService;
            _ModuleTypeService = moduleTypeService;
            _TrainingLabService = trainingLabService;
        }


        public IActionResult Index()
        {
            var list = _TrainingLabService.GetAll();
            return View(list);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrainingLab model)
        {
            if (ModelState.IsValid)
            {
                model.TrainingLabId = Guid.NewGuid().ToString();
                await _TrainingLabService.Add(model);
            }

            return Json(new AjaxResult("操作成功") { result = 1 });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(TrainingLab model)
        {
            var item = _TrainingLabService.Find(r => r.TrainingLabId == model.TrainingLabId);


            if (item != null)
            {
                item.Name = model.Name;
                item.School = model.School;
                item.BuildingNo = model.BuildingNo;
                item.RoomNo = model.RoomNo;
                item.Area = model.Area;
                item.Management = model.Management;
                item.Type = model.Type;
                item.Base = model.Base;
                item.Center = model.Center; 

                await _TrainingLabService.Update(item);
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
            var model = _TrainingLabService.Find(r => r.TrainingLabId == id);
            if (model != null)
            {
                await _TrainingLabService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }
    }
}