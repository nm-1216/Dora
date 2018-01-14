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
    using Dora.Services.School.Interfaces;
    using Dora.Core;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Dora.ViewModels.Extensions;

    public class InfomationController : BaseUserController<InfomationController>
    {
        private readonly IInfomationService _infomationService;

        public InfomationController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , IInfomationService infomationService
        ) : base(roleManager, userManager, loggerFactory)
        {
            this._infomationService = infomationService;
        }

        // GET: Infomation
        public IActionResult Index(string searchKey, InfomationType id, InfomationType infomationType, int page = 1)
        {
            ViewData["searchKey"] = searchKey;

            if (infomationType == 0 && id != 0)
            {
                infomationType = id;
            }

            List<SelectListItem> type;
            type = ((Enum)InfomationType.校级教学管理制度上传).ToSelectListItem(infomationType.ToString());

            type.Insert(0, new SelectListItem() { Text = "==请选择分类==", Value = "-1" });

            ViewBag.infomationType = type;

            var list = new PageList<Infomation>(_infomationService.GetAll()
                .Where(b =>
                (string.IsNullOrEmpty(searchKey) || b.Title.Contains(searchKey))
                && (infomationType <= 0 || b.InfomationType == infomationType)
                )
                .OrderBy(o => o.CreateTime), page, 10);

            return View(list);
        }

        // GET: Infomation/Details/5
        public ActionResult Details(string id)
        {
            var model = this._infomationService.Find(b => b.InfomationId == id);

            return View(model);
        }

        // GET: Infomation/Create
        public ActionResult Create()
        {
            List<SelectListItem> type;
            type = ((Enum)InfomationType.校级教学管理制度上传).ToSelectListItem();

            ViewBag.infomationType = type;

            return View();
        }

        // POST: Infomation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Infomation model)
        {
            try
            {
                await this._infomationService.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Infomation/Edit/5
        public ActionResult Edit(string id)
        {
            var model = this._infomationService.Find(b => b.InfomationId == id);

            List<SelectListItem> type;
            type = ((Enum)InfomationType.校级教学管理制度上传).ToSelectListItem(model.InfomationType.ToString());

            ViewBag.infomationType = type;


            return View(model);
        }

        // POST: Infomation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Infomation model)
        {
            try
            {
                var newItem = this._infomationService.Find(b => b.InfomationId == model.InfomationId);

                newItem.Summary = model.Summary;
                newItem.Content = model.Content;
                newItem.InfomationType = model.InfomationType;
                newItem.UpdateTime = DateTime.Now;
                newItem.Title = model.Title;

                await _infomationService.Update(newItem);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Infomation/Delete/5
        public ActionResult Delete(string id)
        {
            var model = this._infomationService.Find(b => b.InfomationId == id);

            return View(model);
        }

        // POST: Infomation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Infomation model)
        {
            try
            {
                //var model = this._infomationService.Find(b => b.InfomationId == id);

                await this._infomationService.Remove(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}