using Microsoft.AspNetCore.Mvc;

namespace Dora.School.Controllers
{
    public class MsgController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}