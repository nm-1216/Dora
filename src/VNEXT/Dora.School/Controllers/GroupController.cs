 
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
    using Dora.Services.Application.Interfaces;

    [Authorize]
    public class GroupController : Controller
    {
        private readonly ILogger _logger;
        private IGroupService _GroupService;

        public GroupController(
           ILoggerFactory loggerFactory ,
           IGroupService groupService
            )
        { 
            this._logger = loggerFactory.CreateLogger<GroupController>();
            _GroupService = groupService;
        }

        public IActionResult Index()
        {
           var list =  _GroupService.GetAll();
            return View(list);
        }

        public JsonResult GetGroup()
        {
            var list = _GroupService.GetAll();
            list.ForEachAsync(b => b.Parent = null);
            return Json(list); 
        }
    }
}