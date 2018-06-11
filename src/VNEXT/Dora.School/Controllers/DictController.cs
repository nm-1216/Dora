using System.Collections.Generic;
using System.Linq;
using Dora.Core;
using Dora.Domain.Entities.Application;
using Dora.Domain.Entities.School;
using Dora.Services.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Dora.School.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DictController : BaseUserController<AccountController>
    {
        private readonly IDictService _dictService;
        private readonly IDictTypeService _dictTypeService;
        
        // GET
        public DictController(
            IDictService dictService,
            IDictTypeService dictTypeService,
            RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory) : base(roleManager, userManager, loggerFactory)
        {
            this._dictService = dictService;
            this._dictTypeService = dictTypeService;
        }


        public IActionResult Create()
        {
            return null;
        }
        
        public IActionResult CreateType()
        {
            return null;
        }
        
        public IActionResult Index()
        {
            var temp = new List<SelectListItem>();
            var type = _dictTypeService.GetAll();
            
            foreach (var item in type)
            {
                temp.Add(new SelectListItem() { Text =item.name , Value = item.Id });
            }
            ViewBag.type = temp;
            var list = new PageList<Dict>(_dictService.GetAll().OrderBy(o => o.CreateTime), 10, 10);
            return View(list);
        }

        public IActionResult dictType()
        {
            var list = _dictTypeService.GetAll();
            return View(list);
        }

    }
}