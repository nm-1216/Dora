using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dora.School.Controllers
{
    public class SyllabusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}