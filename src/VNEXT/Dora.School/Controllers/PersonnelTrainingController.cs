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
using Dora.ViewModels.Extensions;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

namespace Dora.School.Controllers
{
    [Authorize]
    public class PersonnelTrainingController : BaseUserController<PersonnelTrainingController>
    {
        private IPersonnelTrainingService _personnelTrainingService;
        private IOrganizationService _organizationService;
        private readonly IHostingEnvironment _hostingEnvironment;
        public PersonnelTrainingController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager
            , ILoggerFactory loggerFactory, IPersonnelTrainingService personnelTrainingService, IOrganizationService organizationService, IHostingEnvironment hostingEnvironment) : base(roleManager, userManager, loggerFactory)
        {
            _personnelTrainingService = personnelTrainingService;
            _organizationService = organizationService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var user = await GetCurrentUserAsync();
            int pageSize = user.PageSize;

            var list = new PageList<PersonnelTraining>(_personnelTrainingService.GetAll()
                .Include(m => m.Professional)
                .Where(m => string.IsNullOrEmpty(searchKey)
                || m.Professional.Name.Contains(searchKey)
                || m.Year.Contains(searchKey)).OrderBy(m => m.CreateTime).AsNoTracking(), page, pageSize);

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var professionals = await _organizationService.GetAll()
                .Select(b => new SelectListItem() { Value = b.OrganizationId, Text = b.Name })
                .ToListAsync();
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
                    string sCulProPath = "";
                    string sMeeSumPath = "";
                    if (model.CulProPath != null && model.CulProPath.Length > 0)
                    {
                        sCulProPath = BaseDataController.SaveFile(_hostingEnvironment, "PersonnelTrainning", model.CulProPath);

                    }
                    if (model.MeeSumPath != null && model.MeeSumPath.Length > 0)
                    {
                        sMeeSumPath = BaseDataController.SaveFile(_hostingEnvironment, "PersonnelTrainning", model.MeeSumPath);
                    }

                    PersonnelTraining personnelTraining = new PersonnelTraining
                    {
                        PersonnelTrainingId = Guid.NewGuid().ToString(),
                        OrganizationId = model.OrganizationId,
                        LenOfSch = model.LenOfSch,
                        Year = model.Year,
                        CulProPath = sCulProPath,
                        MeeSumPath = sMeeSumPath,
                        Status = (BaseStatus)model.Status
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

            var professionals = await _organizationService.GetAll()
                .Select(b => new SelectListItem()
                {
                    Value = b.OrganizationId,
                    Text = b.Name,
                    Selected = b.OrganizationId == model.OrganizationId
                })
                .ToListAsync();
            professionals.Insert(0, new SelectListItem() { Text = "==请选择专业==", Value = "" });
            ViewBag.Organizations = professionals;

            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            bool exists = await _personnelTrainingService.GetAll().AnyAsync(m => m.PersonnelTrainingId == id);
            if (!exists)
            {
                RedirectToAction(nameof(Index));
            }

            var model = await _personnelTrainingService.GetAll().Where(m => m.PersonnelTrainingId == id).FirstAsync();

            var professionals = _organizationService.GetAll()
                .Select(b => new SelectListItem()
                {
                    Value = b.OrganizationId,
                    Text = b.Name,
                    Selected = b.OrganizationId == model.PersonnelTrainingId
                })
                .ToList();
            professionals.Insert(0, new SelectListItem() { Text = "==请选择专业==", Value = "" });
            ViewBag.Organizations = professionals;

            var viewModel = new PersonnelTrainingViewModel
            {
                PersonnelTrainingId = model.PersonnelTrainingId,
                OrganizationId = model.OrganizationId,
                LenOfSch = model.LenOfSch,
                Year = model.Year,
                CulProPath = null,
                MeeSumPath = null,
                Status = model.Status

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonnelTrainingViewModel vmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string sCulProPath = "";
                    string sMeeSumPath = "";
                    if (vmodel.CulProPath != null && vmodel.CulProPath.Length > 0)
                    {
                        sCulProPath = BaseDataController.SaveFile(_hostingEnvironment, "PersonnelTrainning", vmodel.CulProPath);

                    }
                    if (vmodel.MeeSumPath != null && vmodel.MeeSumPath.Length > 0)
                    {
                        sMeeSumPath = BaseDataController.SaveFile(_hostingEnvironment, "PersonnelTrainning", vmodel.MeeSumPath);
                    }

                    var model = await _personnelTrainingService.GetAll().Where(m => m.PersonnelTrainingId == vmodel.PersonnelTrainingId).FirstAsync();

                    model.OrganizationId = vmodel.OrganizationId;
                    model.LenOfSch = vmodel.LenOfSch;
                    model.Year = vmodel.Year;
                    if (!string.IsNullOrEmpty(sCulProPath))
                    {
                        model.CulProPath = sCulProPath;
                    }
                    if (!string.IsNullOrEmpty(sMeeSumPath))
                    {
                        model.MeeSumPath = sMeeSumPath;
                    }
                    model.Status = (BaseStatus)vmodel.Status;

                    bool isSuccess = await _personnelTrainingService.Update(model);
                    if (isSuccess)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "专业人才培养方案修改失败", null);
                ModelState.AddModelError("", "专业人才培养方案修改失败");
            }

            var professionals = await _organizationService.GetAll().Select(b => new SelectListItem()
            {
                Value = b.OrganizationId,
                Text = b.Name,
                Selected = b.OrganizationId == vmodel.OrganizationId
            }).ToListAsync();
            professionals.Insert(0, new SelectListItem() { Text = "==请选择专业==", Value = "" });
            ViewBag.Organizations = professionals;

            return View(vmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            bool exists = await _personnelTrainingService.GetAll()
                .AnyAsync(m => m.PersonnelTrainingId == id);
            if (!exists)
            {
                RedirectToAction(nameof(Index));
            }
            var model = await _personnelTrainingService.GetAll()
                .Where(m => m.PersonnelTrainingId == id).FirstAsync();
            bool success = await _personnelTrainingService.Remove(model);
            if (success)
            {
                return Json(new { code="200",msg="OK"});
            }
            return Json(new { code = "-200", msg = "FAIL" });
        }
    

        public async Task<IActionResult> Details(string id)
        {
            bool exists = await _personnelTrainingService.GetAll()
                .AnyAsync(m => m.PersonnelTrainingId == id);
            if (!exists)
            {
                RedirectToAction(nameof(Index));
            }
            var model = await _personnelTrainingService.GetAll().Include(m=>m.Professional)
                .Where(m => m.PersonnelTrainingId == id).FirstAsync();

            PersonnelTrainingViewModel personnelTrainingViewModel = new PersonnelTrainingViewModel
            {
                OrganizationId = model.OrganizationId,
                Professional = model.Professional,
                LenOfSch = model.LenOfSch,
                Year = model.Year,
                SCulProPath = model.CulProPath,
                SMeeSumPath = model.MeeSumPath,
                Status = model.Status
            };

            return View(personnelTrainingViewModel);
        }

        public async Task<IActionResult> Download(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return Content("文件无效");
            }

            path = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", path.TrimStart('/'));

            if (!System.IO.File.Exists(path))
            {
                return Content("文件不存在");
            }

            var extension = Path.GetExtension(path).ToLower();
            var provider = new FileExtensionContentTypeProvider();
            var mime = provider.Mappings[extension];

            MemoryStream memory = new MemoryStream();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Seek(0, SeekOrigin.Begin);
            return File(memory, mime, Path.GetFileName(path));
        }


        //private string GetContentType(string path)
        //{
        //    var types = GetMimeTypes();
        //    var extension = Path.GetExtension(path).ToLower();
        //    return types[extension];
        //}

        //private Dictionary<string, string> GetMimeTypes()
        //{
        //    return new Dictionary<string, string>
        //    {
        //        {".txt", "text/plain"},
        //        {".pdf", "application/pdf"},
        //        {".doc", "application/vnd.ms-word"},
        //        {".docx", "application/vnd.ms-word"},
        //        {".xls", "application/vnd.ms-excel"},
        //        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},  
        //        {".png", "image/png"},
        //        {".jpg", "image/jpeg"},
        //        {".jpeg", "image/jpeg"},
        //        {".gif", "image/gif"},
        //        {".csv", "text/csv"}
        //    };
        //}
    }
}