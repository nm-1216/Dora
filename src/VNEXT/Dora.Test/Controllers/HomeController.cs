using System;
using Dora.Domain.Entities.System;
using Dora.Repositorys.Systems.Interfaces;
using Dora.Services.Systems.Interfaces;
using Dora.Services.Wx.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dora.Test.Controllers
{
    public class HomeController : Controller
    {

        IDictRepository dictRepository;
        IDictService dictService;
        IQyhApiService qyhApiService;

        public HomeController(
             IDictRepository _dictRepository, 
             IDictService _dictService,
             IQyhApiService _qyhApiService
            )
        {
            this.dictRepository = _dictRepository;
            this.dictService = _dictService;
            this.qyhApiService = _qyhApiService;
        }

        //public IActionResult Index()
        //{
        //    var model= this.dictRepository.Find(b => b.Key == "1" && b.Type == "2");

        //    model.Type = "5";

        //    this.dictService.Update(model);

        //    //this.dictService.Add(new Dict() { Key="1", Value="1" , Type="1" , CreateTime=DateTime.Now,UpdateTime=DateTime.Now, CreateUser="", LastAction="", UpdateUser=""});

        //    return View();
        //}

        public string Index()
        {
            //var temp = qyhApiService.getToken(string.Empty, string.Empty);





            //var json = JObject.Parse(temp);
            //var ACCESS_TOKEN = json.GetValue("access_token").ToString();

            return "";
            //return qyhApiService.agentGet(ACCESS_TOKEN, "0");
        }

        public IActionResult About()
        {
            this.dictService.Add(new Dict() { Key = "1", Value = "1", Type = "1", CreateTime = DateTime.Now, UpdateTime = DateTime.Now, CreateUser = "", LastAction = "", UpdateUser = "" });


            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            this.dictService.Add(new Dict() { Key = "1", Value = "1", Type = "3", CreateTime = DateTime.Now, UpdateTime = DateTime.Now, CreateUser = "", LastAction = "", UpdateUser = "" });


            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
