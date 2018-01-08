namespace Dora.School.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    public class RolesController : Controller
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger _logger;

        public RolesController(RoleManager<IdentityRole> roleManager, ILoggerFactory loggerFactory)
        {
            _roleManager = roleManager;
            _logger = loggerFactory.CreateLogger<RolesController>();
        }


        // GET: /<controller>/
        public IActionResult Index()
        {   
            return View(_roleManager.Roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                role.ConcurrencyStamp = Guid.NewGuid().ToString();
                await _roleManager.CreateAsync(role);
                return RedirectToAction("Index");
            }
            return View(role);
        }
    }
}
