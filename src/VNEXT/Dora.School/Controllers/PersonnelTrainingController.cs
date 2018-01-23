using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Domain.Entities.School;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dora.Services.School.Interfaces;
using Dora.Domain.Entities;
using Dora.Core;

namespace Dora.School.Controllers
{
    public class PersonnelTrainingController : BaseUserController<PersonnelTrainingController>
    {
        private IPersonnelTrainingService _personnelTrainingService;
        public PersonnelTrainingController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager
            , ILoggerFactory loggerFactory, IPersonnelTrainingService personnelTrainingService) : base(roleManager, userManager, loggerFactory)
        {
            _personnelTrainingService = personnelTrainingService;
        }

        public IActionResult Index(string searchKey,int page=1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<PersonnelTraining>(_personnelTrainingService.GetAll().
                Where(m => string.IsNullOrEmpty(searchKey) 
                || m.Professional.Name.Contains(searchKey) 
                || m.Year.Contains(searchKey)).OrderBy(m => m.CreateTime),page,20);

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonnelTraining model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.PersonnelTrainingId = Guid.NewGuid().ToString();
                    bool isSuccess = await _personnelTrainingService.Add(model);
                    if (isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "专业人才培养方案保存失败",null);
                ModelState.AddModelError("", "专业人才培养方案保存失败");
            }
            
            return View(model);
        }
    }
}