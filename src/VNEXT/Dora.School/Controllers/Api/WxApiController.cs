using System.Diagnostics;
using Dora.Domain.Entities.School;
using Dora.Services.School.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Dora.School.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Cors;
    using Dora.Core;
    using Microsoft.EntityFrameworkCore;

    [EnableCors("AllowSameDomain")]
    public class WxApiController : Controller
    {
        private readonly ILogger _logger;
        private readonly UserManager<SchoolUser> _userManager;
        private readonly ITeachingTaskService _teachingTaskService;
        private readonly IClassService _classService;
        private readonly ILearnLogService _learnLogService;
        private readonly INoticeService _noticeService;
        private readonly ICoursewareService _coursewareService;
        

        public WxApiController(
            UserManager<SchoolUser> userManager,
            ITeachingTaskService teachingTaskService,
            IClassService classService,
            ILearnLogService learnLogService,
            INoticeService noticeService,
            ICoursewareService coursewareService,
        ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<WxApiController>();
            this._userManager = userManager;
            _teachingTaskService = teachingTaskService;
            _classService = classService;
            _learnLogService = learnLogService;
            _noticeService = noticeService;
            _coursewareService = coursewareService;
        }

        #region user

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> Register(string userId, string pwd, string openId)
        {
            var model = await this._userManager.FindByIdAsync(userId);
            var rst = false;
            if (null != model)
            {
                rst = await this._userManager.CheckPasswordAsync(model, pwd);
            }

            if (rst)
            {
                model.WxOpenId = openId;

                var temp = await this._userManager.UpdateAsync(model);
                rst = temp.Succeeded;
            }

            return Json(new AjaxResult(rst ? "绑定成功" : "绑定失败") {result = rst ? 0 : 1});
        }
        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetUserInfo(string openId)
        {
            var model = this._userManager.Users.FirstOrDefault(o => o.WxOpenId == openId);
            var rst = model != null;
            
            return Json(new AjaxResult<SchoolUser>(rst ? "查询成功" : "查询失败") { result = rst ? 0 : 1, data = model });
        }

        #endregion

        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetCourseList(string openId)
        {
            var user = this._userManager.Users.Include(b=>b.Teacher).Include(b=>b.Student).FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") { result = 99});
            }

            if (user.UserType == SchoolUserType.student)
            {
                var list = _teachingTaskService.GetAll()
                    .Include(b => b.Classes).ThenInclude(b => b.Class).ThenInclude(b => b.Students)
                    .Include(b => b.Course)
                    .Where(b => b.Classes.Where(c => c.ClassId == user.Student.ClassId) != null).ToList();
                if(user.Student!=null)
                user.Student.SchoolUser = null;
                if(user.Teacher!=null)
                user.Teacher.SchoolUser = null;
                return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {list, user}});
            }
            else if (user.UserType== SchoolUserType.teacher)
            {
                return Json(new AjaxResult("用户角色不对") { result = 99});
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") { result = 99});
            }

            //return Json(new AjaxResult<SchoolUser>(rst ? "查询成功" : "查询失败") { result = rst ? 0 : 1, data = model });
        }
        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetClassCourse(string openId,string courseId)
        {
            var user = this._userManager.Users.Include(b=>b.Student).FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") { result = 99});
            }

            if (user.UserType == SchoolUserType.student)
            {
                var model = _classService.GetAll().Include(b => b.Students)
                    .FirstOrDefault(b => b.ClassId == user.Student.ClassId);
                
                foreach (var modelStudent in model.Students)
                {
                    modelStudent.Class = null;
                }

                var list = _learnLogService.GetAll().Where(b => b.ClassId == user.Student.ClassId && b.CourseId == courseId).OrderByDescending(b=>b.CreateTime);


                return Json(new AjaxResult<object>("查询成功") {result = 0, data =new { model, list } });
            }
            else if (user.UserType== SchoolUserType.teacher)
            {
                return Json(new AjaxResult("用户角色不对") { result = 99});
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") { result = 99});
            }
        }
    }
}