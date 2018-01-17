 
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
    using Dora.Domain.Entities.Application;
    using Newtonsoft.Json;

    [Authorize]
    public class GroupController : Controller
    {
        private readonly ILogger _logger;
        private IGroupService _GroupService;

        public GroupController(
           ILoggerFactory loggerFactory,
           IGroupService groupService
            )
        {
            this._logger = loggerFactory.CreateLogger<GroupController>();
            _GroupService = groupService;
        }

        public IActionResult Index()
        {
            var list = _GroupService.GetAll();
            return View(list);
        }

        public String GetGroup()
        {
           var group = _GroupService.GetAll().ToList().Where(r=> r.Parent == null).FirstOrDefault();
            //list.ForEachAsync(b => b.Parent = null);

            List<Tree> list = new List<Tree>();
            Tree tr = new Tree();
            tr.id = Convert.ToInt32(group.GroupId);
            tr.name = group.GroupName;
            tr.pId =0;
            tr.myAttr = "sd";
            list.Add(tr);

            AddChilds(group, list);
            string content =    JsonConvert.SerializeObject(list);

            return content;
        }

        private class Tree
        {
            public int id;
            public int pId;
            public string name;
            public string myAttr;
        }

        private void AddChilds(Group<string> group, List<Tree> list)
        {
            foreach (var item in group.Childs)
            {
                Tree tr = new Tree();
                tr.id = Convert.ToInt32(item.GroupId);
                tr.name = item.GroupName;
                tr.pId = Convert.ToInt32(group.GroupId);
                list.Add(tr);
                 
                if (item.Childs != null)
                {
                    AddChilds(item, list);
                }
            } 
        }
    }
}