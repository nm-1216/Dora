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
        /// <param name="detailId">要删除的明细id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeletePlanDetail(string id ,string detailId)
        {
            var rst = false;

             var model = _TeachingPlanDetailService.GetAll().First(b => b.TeachingPlanDetailId == detailId);

            if (model != null)
            {
                await _TeachingPlanDetailService.Remove(model);

                #region 删除后重新排序
                var modelList = _TeachingPlanDetailService.Where(b => b.TeachingPlanId == id).OrderBy(r => r.Order);
                int i = 1;
                foreach (var item in modelList)
                {
                    item.Order = i++;
                }

                rst = await _TeachingPlanDetailService.UpdateRange(modelList);
                #endregion

                return Json(new AjaxResult("操作成功") { result = 1 });
            }
            else
            {
                return Json(new AjaxResult("操作失败,未找到对象") { result = 0 });
            }
        }


        #region 修改明细
        /// <summary>
        /// 提供明细信息
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetTeachingPlanDetail(string detailId)
        {
            var model = _TeachingPlanDetailService.GetAll().First(b => b.TeachingPlanDetailId == detailId);
            return Json(model);
        }

        // POST: TeachingTask/Edit/5
        /// <summary>
        /// 修改和添加，model.TeachingPlanDetailId有值就是修改，否则添加
        /// </summary>
        /// <param name="model"></param>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditTeachingPlanDetail(TeachingPlanDetail model, IFormCollection form)
        {
            var rst = false;
            if (string.IsNullOrEmpty(model.TeachingPlanDetailId))
            {
                TeachingPlanDetail item = new TeachingPlanDetail();
                item.TeachingPlanId = model.TeachingPlanId;
                item.TeachingPlanDetailId = model.TeachingPlanDetailId;
                item.Mode = model.Mode;
                item.Period = model.Period;
                item.TeaCon = model.TeaCon;
                item.Assets = model.Assets;
                item.Test = form["Test"] == "on" ? YesOrNo.Yes : YesOrNo.No;
                item.Teacher = model.Teacher;
                item.Job = model.Job;
                item.Order = 1;//添加默认给1
                rst = await _TeachingPlanDetailService.Add(item);

                //重新排序
                var modelList = _TeachingPlanDetailService.Where(b => b.TeachingPlanId == model.TeachingPlanId).OrderBy(r=> r.Order);
                int i = 1;
                foreach (var item2 in modelList)
                {
                    item2.Order = i++;
                }
                rst = await _TeachingPlanDetailService.UpdateRange(modelList); 
            }
            else
            {
                var item = _TeachingPlanDetailService.GetAll().First(b => b.TeachingPlanDetailId == model.TeachingPlanDetailId);
                item.Mode = model.Mode;
                item.Period = model.Period;
                item.TeaCon = model.TeaCon;
                item.Assets = model.Assets;
                item.Test = form["Test"] == "on" ? YesOrNo.Yes : YesOrNo.No;
                item.Teacher = model.Teacher;
                item.Job = model.Job;
                rst = await _TeachingPlanDetailService.Update(item);
            }

            return Json(new AjaxResult(rst ? "操作成功" : "操作失败") { result = rst ? 1 : 0 });
        }

 
        #endregion



        /// <summary>
        /// 提交排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<IActionResult> ReOrder(string id, List<string> list)
        {
            var rst = false;

            var modelList = _TeachingPlanDetailService.Where(b => b.TeachingPlanId == id);

            for (int i = 0; i < list.Count; i++)
            {
                foreach (var item in modelList)
                {
                    if (item.TeachingPlanDetailId == list[i])
                    {
                        item.Order = i + 1;
                    }
                }
            }


            rst = await _TeachingPlanDetailService.UpdateRange(modelList);

            return Json(new AjaxResult(rst ? "成功" : "失败") { result = rst ?1 : 0});
        }
    }
}