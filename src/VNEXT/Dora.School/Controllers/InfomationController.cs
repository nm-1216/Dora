namespace Dora.School.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Dora.Domain.Entities.School;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class InfomationController : BaseUserController<InfomationController>
    {

        public InfomationController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory) : base(roleManager, userManager, loggerFactory)
        {
        }

        // GET: Infomation
        public ActionResult Index()
        {

            return View();
        }

        // GET: Infomation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Infomation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Infomation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Infomation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Infomation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Infomation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Infomation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}