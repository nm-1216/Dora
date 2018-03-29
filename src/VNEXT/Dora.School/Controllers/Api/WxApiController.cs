using System.Diagnostics;
using Dora.Domain.Entities.School;
using Dora.Services.School.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

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
        private readonly IPapersService _papersService;
        private readonly ICourseService _courseService;
        private readonly IPaperAnswersService _paperAnswersService;
        
        

        public WxApiController(
            UserManager<SchoolUser> userManager,
            ITeachingTaskService teachingTaskService,
            IClassService classService,
            ILearnLogService learnLogService,
            INoticeService noticeService,
            IPapersService papersService,
            ICoursewareService coursewareService,
            IPaperAnswersService paperAnswersService,
            ICourseService courseService,
        ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<WxApiController>();
            this._userManager = userManager;
            _teachingTaskService = teachingTaskService;
            _classService = classService;
            _learnLogService = learnLogService;
            _noticeService = noticeService;
            _coursewareService = coursewareService;
            _papersService = papersService;
            _courseService = courseService;
            _paperAnswersService = paperAnswersService;
            
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

                foreach (var item in list)
                {
                    foreach (var a in item.Classes)
                    {
                        a.TeachingTask = null;

                        foreach (var b in a.Class.Students)
                        {
                            b.Class = null;
                        }
                        
                    }
                }
                
                if(user.Student!=null)
                user.Student.SchoolUser = null;
                if(user.Teacher!=null)
                user.Teacher.SchoolUser = null;
                return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {list, user}});
            }
            else if (user.UserType== SchoolUserType.teacher)
            {
                
                var list = _teachingTaskService.GetAll()
                    .Include(b => b.Classes).ThenInclude(b => b.Class).ThenInclude(b => b.Students)
                    .Include(b => b.Course)
                    .Where(b => b.Teachers.Where(c => c.TeacherId == user.Teacher.TeacherId) != null).ToList();

                foreach (var item in list)
                {
                    foreach (var a in item.Classes)
                    {
                        a.TeachingTask = null;

                        foreach (var b in a.Class.Students)
                        {
                            b.Class = null;
                        }
                        
                    }
                }

                if(user.Student!=null)
                    user.Student.SchoolUser = null;
                if(user.Teacher!=null)
                    user.Teacher.SchoolUser = null;
                return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {list, user}});
                
                
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") { result = 99});
            }

            //return Json(new AjaxResult<SchoolUser>(rst ? "查询成功" : "查询失败") { result = rst ? 0 : 1, data = model });
        }

        [EnableCors("AllowSameDomain")]
        public IActionResult GetClassCourse(string openId, string courseId, string classId)
        {
            var user = this._userManager.Users.Include(b => b.Student).FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            if (user.UserType == SchoolUserType.student)
            {
                var model = _classService.GetAll().Include(b => b.Students)
                    .FirstOrDefault(b => b.ClassId == user.Student.ClassId);

                foreach (var modelStudent in model.Students)
                {
                    modelStudent.Class = null;
                }

                var list = _learnLogService.GetAll()
                    .Where(b => b.ClassId == user.Student.ClassId && b.CourseId == courseId)
                    .OrderByDescending(b => b.CreateTime);


                return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {model, list}});
            }
            else if (user.UserType == SchoolUserType.teacher)
            {
                var model = _classService.GetAll().Include(b => b.Students)
                    .FirstOrDefault(b => b.ClassId == classId);

                foreach (var modelStudent in model.Students)
                {
                    modelStudent.Class = null;
                }

                var list = _learnLogService.GetAll().Where(b => b.ClassId == classId && b.CourseId == courseId)
                    .OrderByDescending(b => b.CreateTime);


                return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {model, list}});
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") {result = 99});
            }
        }

        [EnableCors("AllowSameDomain")]
        public IActionResult GetNotice(string id)
        {

            var learnLog = _learnLogService.Find(b => b.LearnLogId == id);
            var classes = _classService.Find(b => b.ClassId == learnLog.ClassId);
            var course = _courseService.Find(b => b.CourseId == learnLog.CourseId);

            object model = null;

            if (learnLog.Types == 0)
                model = _noticeService.GetAll().Include(b=>b.Teacher).FirstOrDefault(b => b.NoticeId == learnLog.ObjectId);
            else if (learnLog.Types == 1)
                model = _coursewareService.GetAll().Include(b=>b.Teacher).FirstOrDefault(b => b.CoursewareId == learnLog.ObjectId);
            else
                model = _papersService.GetAll().Include(b=>b.Teacher).FirstOrDefault(b => b.PaperId == learnLog.ObjectId);


            return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {model, learnLog, classes, course}});
        }

        [EnableCors("AllowSameDomain")]
        public IActionResult GetPapers(string id, string openId)
        {

            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var learnLog = _learnLogService.Find(b => b.LearnLogId == id);
            var classes = _classService.Find(b => b.ClassId == learnLog.ClassId);
            var course = _courseService.Find(b => b.CourseId == learnLog.CourseId);

            var model = _papersService.GetAll().Include(b => b.Teacher).Include(b => b.PaperQuestions)
                .FirstOrDefault(b => b.PaperId == learnLog.ObjectId);

            var answers = _paperAnswersService.GetAll().Include(b=>b.PaperAnswerDetails).FirstOrDefault(
                b => b.PaperId == model.PaperId && b.StudentId == user.Student.StudentId);


            return Json(new AjaxResult<object>("查询成功")
            {
                result = 0,
                data = new {model, learnLog, classes, course, answers}
            });
        }

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> PushAnswer(Papers model,string openId)
        {
            var user = this._userManager.Users.Include(b=>b.Teacher).Include(b=>b.Student).FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") { result = 99});
            }

            var tmp = _paperAnswersService.Find(
                b => b.PaperId == model.PaperId && b.StudentId == user.Student.StudentId);

            if (tmp != null)
            {
                return Json(new AjaxResult("您已经做过试题，请不要再次提交") { result = 99});
            }

            if (user.UserType == SchoolUserType.student)
            {
                var list = new List<PaperAnswerDetails>();

                foreach (var q in model.PaperQuestions)
                {
                    Array.Sort(q.UserAnswer.ToArray());

                    var temp = string.Join(",", q.UserAnswer).ToUpper();
                    list.Add(new PaperAnswerDetails()
                    {
                        PaperQuestionId = q.PaperQuestionId,
                        Value = temp,
                        IsRight = q.Answer.ToUpper()==temp
                    });
                }

                var item=new PaperAnswers()
                {
                    PaperId = model.PaperId,
                    StudentId = user.Student.StudentId,
                    PaperAnswerDetails = list
                };
                await _paperAnswersService.Add(item);
                
                
                return Json(new AjaxResult<object>("查询成功") {result = 0, data = null});
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

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> DelLearnLog(string openId, string learnLogId)
        {
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            if (user.UserType == SchoolUserType.student)
            {
                return Json(new AjaxResult("用户角色不对") {result = 99});

            }
            else if (user.UserType == SchoolUserType.teacher)
            {
                var model = _learnLogService.Find(b => b.LearnLogId == learnLogId);
                
                await _learnLogService.Remove(model);

                return Json(new AjaxResult("删除成功") {result = 0});
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") {result = 99});
            }
        }

        [EnableCors("AllowSameDomain")]
        public IActionResult GetPaperTongJi(string id)
        {
            var learnLog = _learnLogService.Find(b => b.LearnLogId == id);
            var classes = _classService.Find(b => b.ClassId == learnLog.ClassId);
            var course = _courseService.Find(b => b.CourseId == learnLog.CourseId);

            var model = _papersService.GetAll().Include(b => b.Teacher)
                .Include(b => b.PaperQuestions)
                .Include(b => b.PaperAnswers).ThenInclude(b => b.PaperAnswerDetails)
                .FirstOrDefault(b => b.PaperId == learnLog.ObjectId);


            var abc = model.PaperQuestions.Select(b =>
                new
                {
                    item = b,
                    Count = b.PaperAnswerDetails.Count,
                    right = b.PaperAnswerDetails.Where(d => d.IsRight).Count()
                }

            );

            return Json(new AjaxResult<object>("查询成功")
            {
                result = 0,
                data = new {learnLog, classes, course, model = abc}
            });
        }

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> SendNotice(string courseId, string classId, string title, string des,
            string openId)
        {
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var model = new Notice()
            {
                TeacherId = user.Teacher.TeacherId,
                Title = title,
                Content = des
            };

            await _noticeService.Add(model);

            await _learnLogService.Add(new LearnLog()
            {
                ClassId = classId,
                CourseId = courseId,
                ObjectId = model.NoticeId,
                Name = title,
                Types = 0
            });

            return Json(new AjaxResult("发布成功") {result = 0});
        }
        
        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> SendCoursewaree(string courseId, string classId, string id, string openId)
        {
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var model= _coursewareService.Find(b => b.CoursewareId == id);

            await _learnLogService.Add(new LearnLog()
            {
                ClassId = classId,
                CourseId = courseId,
                ObjectId = id,
                Name = model.Title,
                Types = 1
            });

            return Json(new AjaxResult("发布成功") {result = 0});
        }
        
        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> SendPapers(string courseId, string classId, string id, string openId)
        {
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var model= _papersService.Find(b => b.PaperId == id);

            await _learnLogService.Add(new LearnLog()
            {
                ClassId = classId,
                CourseId = courseId,
                ObjectId = id,
                Name = model.Title,
                Types = 2
            });

            return Json(new AjaxResult("发布成功") {result = 0});
        }
        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetCoursewareList(string openId)
        {
            //
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var list = _coursewareService.Where(b => b.TeacherId == user.Teacher.TeacherId).OrderByDescending(b=>b.CreateTime);;
            return Json(new AjaxResult<object>("查询成功")
            {
                result = 0,
                data = list
            });
        }
        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetPapersList(string openId)
        {
            //
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var list = _papersService.Where(b => b.TeacherId == user.Teacher.TeacherId).OrderByDescending(b=>b.CreateTime);;
            return Json(new AjaxResult<object>("查询成功")
            {
                result = 0,
                data = list
            });
        }  


    }
}