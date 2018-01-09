 
namespace Dora.School.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Core;
    using Domain.Entities.School;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging; 
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using NPOI.HSSF.UserModel;
    using System.Threading.Tasks; 

    [Authorize]
    public class GroupController : Controller
    {
        private readonly ILogger _logger; 

        public GroupController(
           ILoggerFactory loggerFactory 
            )
        { 
            this._logger = loggerFactory.CreateLogger<GroupController>();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}