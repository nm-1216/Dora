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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Dora.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Dora.School.Controllers
{
    [Authorize]
    public class PersonnelTrainingController : BaseUserController<PersonnelTrainingController>
    {
        private IPersonnelTrainingService _personnelTrainingService;
        private IOrganizationService _organizationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PersonnelTrainingController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager
            , ILoggerFactory loggerFactory, IPersonnelTrainingService personnelTrainingService, IOrganizationService organizationService,IHostingEnvironment hostingEnvironment) : base(roleManager, userManager, loggerFactory)
        {
            _personnelTrainingService = personnelTrainingService;
            _organizationService = organizationService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<PersonnelTraining>(_personnelTrainingService.GetAll()
                .Include(m=>m.Professional)
                .Where(m => string.IsNullOrEmpty(searchKey)
                || m.Professional.Name.Contains(searchKey)
                || m.Year.Contains(searchKey)).OrderBy(m => m.CreateTime), page, 20);

            return View(list);
        }

        public IActionResult Create()
        {
            var professionals = _organizationService.GetAll().Select(b => new SelectListItem() { Value = b.OrganizationId, Text = b.Name }).ToList();
            professionals.Insert(0, new SelectListItem() { Text = "==请选择专业==", Value = "" });
            ViewBag.Organizations = professionals;
            return View(new PersonnelTrainingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonnelTrainingViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sCulProPath = BaseDataController.SaveFile(_hostingEnvironment, "PersonnelTrainning", model.CulProPath);
                    string sMeeSumPath = BaseDataController.SaveFile(_hostingEnvironment, "PersonnelTrainning", model.MeeSumPath);

                    PersonnelTraining personnelTraining = new PersonnelTraining
                    {
                        PersonnelTrainingId = Guid.NewGuid().ToString(),
                        OrganizationId = model.OrganizationId,
                        LenOfSch = model.LenOfSch,
                        Year = model.Year,
                        CulProPath = sCulProPath,
                        MeeSumPath = sMeeSumPath
                    };

     

                    model.PersonnelTrainingId = Guid.NewGuid().ToString();
                    bool isSuccess = await _personnelTrainingService.Add(personnelTraining);
                    if (isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "专业人才培养方案保存失败", null);
                ModelState.AddModelError("", "专业人才培养方案保存失败");
            }

            var professionals = _organizationService.GetAll().Select(b => new SelectListItem() { Value = b.OrganizationId, Text = b.Name }).ToList();
            professionals.Insert(0, new SelectListItem() { Text = "==请选择专业==", Value = "" });
            ViewBag.Organizations = professionals;

            return View(model);
        }
    }
}