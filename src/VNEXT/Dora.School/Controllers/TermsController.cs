namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Linq;
    using System.Threading.Tasks;

    public class TermsController : BaseUserController<TermsController>
    {
        private readonly ITermService _termService;

        public TermsController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
        , ITermService termService

        ) : base(roleManager, userManager, loggerFactory)
        {
            _termService = termService;
        }

        // GET: Terms
        public IActionResult Index()
        {
            return View(_termService.GetAll().OrderByDescending(b=>b.TermId));
        }

        // POST: Terms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Term term)
        {
            if (ModelState.IsValid)
            {
                await _termService.Add(term);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            return Json(new AjaxResult("操作失败，数据不符合规则") { result = 0 });
        }

        // POST: Terms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Term term)
        {
            if (ModelState.IsValid)
            {
                await _termService.Update(term);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            return Json(new AjaxResult("操作失败，数据不符合规则") { result = 0 });
        }

        // POST: Terms/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var model = _termService.Find(b => b.TermId == id);
            if (model != null)
            {
                await _termService.Remove(model);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetDefault(string id)
        {
            var list = _termService.Where(b => b.IsDefault);
            await list.ForEachAsync(b => b.IsDefault = false);

            var model = _termService.Find(b => b.TermId == id);
            if (model != null)
            {
                model.IsDefault = true;
                list.ToList().Add(model);

                await _termService.UpdateRange(list);
                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }

        public IActionResult Details(string id)
        {
            var model = _termService.Find(b => b.TermId == id);

            var week = (int)model.StartTime.DayOfWeek;

            //周末是一个星期的最后一天


            //TermWeek

            return View(model);
        }

    }
}
