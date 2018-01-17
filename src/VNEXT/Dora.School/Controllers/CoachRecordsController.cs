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

    public class CoachRecordsController : BaseUserController<CoachRecordsController>
    {
        private readonly ICoachRecordService _coachRecordService;


        public CoachRecordsController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
            , ICoachRecordService coachRecordService
            ) : base(roleManager, userManager, loggerFactory)
        {
            _coachRecordService = coachRecordService;
        }



        // GET: CoachRecords
        public async Task<IActionResult> Index(string searchKey, int page = 1)
        {
            var user = await GetCurrentUserAsync();
            ViewData["searchKey"] = searchKey;
            var list = new PageList<CoachRecord>(_coachRecordService.GetAll().OrderBy(o => o.CreateTime), page, 10);
            return View(list);
        }

        // GET: CoachRecords/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coachRecord = await _coachRecordService.GetAll()
                .Include(c => c.Teacher)
                .SingleOrDefaultAsync(m => m.CoachRecordId == id);
            if (coachRecord == null)
            {
                return NotFound();
            }

            return View(coachRecord);
        }

        // GET: CoachRecords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoachRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoachRecord coachRecord)
        {
            if (ModelState.IsValid)
            {
                await _coachRecordService.Add(coachRecord);
                return RedirectToAction(nameof(Index));
            }
            return View(coachRecord);
        }

        // GET: CoachRecords/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coachRecord = _coachRecordService.Find(m => m.CoachRecordId == id);
            if (coachRecord == null)
            {
                return NotFound();
            }
            return View(coachRecord);
        }

        // POST: CoachRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CoachRecord coachRecord)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _coachRecordService.Update(coachRecord);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachRecordExists(coachRecord.CoachRecordId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(coachRecord);
        }

        // GET: CoachRecords/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coachRecord = _coachRecordService.Find(m => m.CoachRecordId == id);
            if (coachRecord == null)
            {
                return NotFound();
            }

            return View(coachRecord);
        }

        // POST: CoachRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var coachRecord = _coachRecordService.Find(m => m.CoachRecordId == id);
            await _coachRecordService.Remove(coachRecord);
            return RedirectToAction(nameof(Index));
        }

        private bool CoachRecordExists(string id)
        {
            return _coachRecordService.Find(e => e.CoachRecordId == id) != null;
        }
    }
}
