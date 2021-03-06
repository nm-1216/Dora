﻿namespace Dora.School.Controllers
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

    [Authorize]
    public class PublicClassRoomController : BaseUserController<PublicClassRoomController>
    {
        private readonly IPermissionService _PermissionService;
        private readonly IModuleTypeService _ModuleTypeService;
        private readonly IPublicClassRoomService _PublicClassRoomService;

        public PublicClassRoomController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory,
      IPermissionService permissionService,
      IModuleTypeService moduleTypeService,
      IPublicClassRoomService publicClassRoomService
      ) : base(roleManager, userManager, loggerFactory)
        {
            _PermissionService = permissionService;
            _ModuleTypeService = moduleTypeService;
            _PublicClassRoomService = publicClassRoomService;
        }
         
        public  IActionResult Index()
        {
            var list = _PublicClassRoomService.GetAll();
            return View(list);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PublicClassRoom model)
        {
            if (ModelState.IsValid)
            {
                model.PublicClassRoomId = Guid.NewGuid().ToString();
                await _PublicClassRoomService.Add(model);
            }

            return Json(new AjaxResult("操作成功") { result = 1 });
        }


        [HttpPost]
        public async Task<IActionResult> Edit(PublicClassRoom model)
        {
            var item =  _PublicClassRoomService.Find(r=> r.PublicClassRoomId == model.PublicClassRoomId);

             
            if (item != null)
            {
                item.Name = model.Name;
                item.School = model.School;
                item.BuildingNo = model.BuildingNo;
                item.RoomNo = model.RoomNo;
                item.Area = model.Area;
                item.SeatNum = model.SeatNum; 

                await _PublicClassRoomService.Update(item);
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
            var model =  _PublicClassRoomService.Find(r => r.PublicClassRoomId == id);
            if (model != null)
            {
                await _PublicClassRoomService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

    }

}