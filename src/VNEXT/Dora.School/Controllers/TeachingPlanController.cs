namespace Dora.School.Controllers
{
    using Dora.Core;
    using Dora.Domain.Entities.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class TeachingPlanController : BaseUserController<TeachingPlanController>
    {
        private ITeachingPlanService _TeachingPlanService;
        private ITeachingPlanDetailService _TeachingPlanDetailService;

        public TeachingPlanController(RoleManager<SchoolRole> roleManager, UserManager<SchoolUser> userManager, ILoggerFactory loggerFactory
     , ITeachingPlanService TeachingPlanService
     , ITeachingPlanDetailService TeachingPlanDetailService
     ) : base(roleManager, userManager, loggerFactory)
        {
            _TeachingPlanService = TeachingPlanService;
            _TeachingPlanDetailService = TeachingPlanDetailService;
        }

        public IActionResult Index()
        {
            var list = _TeachingPlanService.GetAll().Include(b => b.Course).Include(b => b.Teacher);

            return View(list);
        }

        /// <summary>
        /// 教学任务明细
        /// </summary>
        /// <param name="id">TeachingPlanID</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var model = _TeachingPlanService.GetAll()
                .Include(b => b.Course)
                //.Include(b => b.Teacher)
                .FirstOrDefault(b => b.TeachingPlanId == id);

            ViewBag.Detail = _TeachingPlanDetailService.GetAll().Where(r => r.TeachingPlanId == id)
                .OrderBy(r=>r.Order)
                .ToList();

            return View(model);
        }

        //// POST: TeachingTask/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit(TeachingPlan model, IFormCollection form)
        //{
        //    var tp = _TeachingPlanService.GetAll().Include(b => b.Course).Include(b => b.Teacher).FirstOrDefault(b => b.TeachingPlanId == model.TeachingPlanId);

        //    IList<TeachingPlanDetail> list = new List<TeachingPlanDetail>();

        //     int Period = Convert.ToInt32(tp.Course.Period);
        //    //int Period = 64;
        //    for (int i = 0; i < Period / 2; i++)
        //    {
        //        TeachingPlanDetail item = new TeachingPlanDetail();
        //        item.TeachingPlanId = model.TeachingPlanId; 
        //        item.Order = i + 1; 
        //        list.Add(item);
        //    }
        //    await _TeachingPlanDetailService.AddRange(list);
        //    return RedirectToAction(nameof(Edit));
        //}

        [HttpPost] 
        public async Task<IActionResult> BatchGenerate(string TeachingPlanId)
        {
            var tp = _TeachingPlanService.GetAll().Include(b => b.Course).Include(b => b.Teacher).FirstOrDefault(b => b.TeachingPlanId == TeachingPlanId);

            IList<TeachingPlanDetail> list = new List<TeachingPlanDetail>();

            int Period = Convert.ToInt32(tp.Course.Period);
            //int Period = 64;
            for (int i = 0; i < Period / 2; i++)
            {
                TeachingPlanDetail item = new TeachingPlanDetail();
                item.TeachingPlanId = TeachingPlanId;
                item.Order = i + 1;
                list.Add(item);
            }
            await _TeachingPlanDetailService.AddRange(list);
            
            return Json(new AjaxResult("操作成功") { result = 1 });
            
        }

        /// <summary>
        /// 提供已有明细的授课计划列表，以供参照
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetTeachingPlansToImitate()
        {
            var TeachingPlans = _TeachingPlanService.GetAll().Include(r => r.Course).Where(r => r.TeachingPlanDetails.FirstOrDefault() != null)
                .Select(r => new { id= r.TeachingPlanId, name = r.Course.Name, term = r.Term });
            return Json(TeachingPlans);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="czid">要参照的授课计划id</param>
        /// <param name="id">要生成明细的授课计划id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> doImitate(string czid, string id)
        {
            //要参照的授课计划
            var tp = _TeachingPlanService.GetAll().Include(r => r.TeachingPlanDetails).First(b => b.TeachingPlanId == czid);

            //要生成的
            IList<TeachingPlanDetail> list = new List<TeachingPlanDetail>();

            foreach (var czitem in tp.TeachingPlanDetails)
            {
                TeachingPlanDetail item = new TeachingPlanDetail();
                item.TeachingPlanId = id;
                item.Order = czitem.Order;
                item.TeacherId = czitem.TeacherId;
                item.Order = czitem.Order;
                item.Mode = czitem.Mode;
                item.Period = czitem.Period;
                item.TeaCon = czitem.TeaCon;
                item.Assets = czitem.Assets;
                item.Test = czitem.Test;
                item.Job = czitem.Job;
                list.Add(item);
            }
            await _TeachingPlanDetailService.AddRange(list);

            return Json(new AjaxResult("操作成功") { result = 1 });

        }

        /// <summary>
        /// 删除
        /// </summary> 
        /// <param name="id">授课计划id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeletePlanDetail(string id)
        {  
            var model = _TeachingPlanDetailService.GetAll().First(b => b.TeachingPlanDetailId == id);
             
            if (model != null)
            {
                await _TeachingPlanDetailService.Remove(model);

                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }


        #region 修改明细
        ///// <summary>
        ///// 提供明细信息
        ///// </summary> 
        ///// <returns></returns>
        //[HttpPost]
        //public IActionResult GetTeachingPlanDetail(int did)
        //{
        //    var TeachingPlans = _TeachingPlanDetailService.GetAll().Where(r => r.TeachingPlanDetails.FirstOrDefault() != null)
        //        .Select(r => new { id = r.TeachingPlanId, name = r.Course.Name, term = r.Term });
        //    return Json(TeachingPlans);
        //}

        #endregion
    }
}