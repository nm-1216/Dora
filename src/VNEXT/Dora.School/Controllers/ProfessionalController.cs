namespace Dora.School.Controllers
{
    using Core;
    using Domain.Entities.School;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Services.School.Interfaces;
    using System.Linq;

    [Authorize]
    public class ProfessionalController : BaseUserController<ProfessionalController>
    {
        private IProfessionalService _ProfessionalService;

        public ProfessionalController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
            , IProfessionalService professionalService
            ) : base(roleManager, userManager, loggerFactory)
        {
            this._ProfessionalService = professionalService;
        }

        public IActionResult Index(string searchKey, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            var list = new PageList<Professional>(_ProfessionalService.GetAll().Include(b => b.Department)
                .Where(b => string.IsNullOrEmpty(searchKey) || b.ProfessionalId.Contains(searchKey) || b.Name.Contains(searchKey))
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }
    }
}