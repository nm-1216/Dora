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
    }

}