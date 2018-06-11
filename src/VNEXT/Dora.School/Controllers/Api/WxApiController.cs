using System.Diagnostics;
using Dora.Domain.Entities.School;
using Dora.Services.School.Interfaces;
using Dora.wx;
using Dora.Weixin.MP;
using Dora.Weixin.MP.AdvancedAPIs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;

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
        private readonly WxConfig _wxConfig;
        private readonly ITeacherService _teacherService;
        

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
            IOptions<WxConfig> wxConfig,
            ITeacherService teacherService,
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
            _wxConfig = wxConfig.Value;
            _teacherService = teacherService;

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
        public IActionResult GetWxJsConfig()
        {
            
            var model = new
            {
                appId=_wxConfig.AppID,
                timeStamp=timestamp,
                nonceStr=nonceStr,
                signature=signature,
                paySign=paySign
            };
            return null;

        }

        
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
            else if (user.UserType == SchoolUserType.teacher)
            {
                var list = _teachingTaskService.GetAll()
                    .Include(b => b.Classes)
                    .ThenInclude(b => b.Class)
                    .ThenInclude(b => b.Students)
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

                if (user.Student != null)
                    user.Student.SchoolUser = null;
                if (user.Teacher != null)
                    user.Teacher.SchoolUser = null;
                
                var course = list.Select(b => b.Course).Distinct();

                return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {list, user, course}});
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") { result = 99});
            }

            //return Json(new AjaxResult<SchoolUser>(rst ? "查询成功" : "查询失败") { result = rst ? 0 : 1, data = model });
        }

        [EnableCors("AllowSameDomain")]
        public IActionResult GetTeachingTask(string openId, string id)
        {
            var user = this._userManager.Users
                .Include(b => b.Student)
                .Include(b=>b.Teacher)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var teachingTask = _teachingTaskService.GetAll().Include(b=>b.Course).Include(b => b.Classes).Include(b => b.Teachers)
                .FirstOrDefault(b => b.TeachingTaskId == id);

            if (teachingTask == null)
            {
                return Json(new AjaxResult("该教学任务不存在") {result = 99});
            }
            
            foreach (var item in teachingTask.Classes)
            {
                item.TeachingTask = null;
            }
            
            foreach (var item in teachingTask.Teachers)
            {
                item.TeachingTask = null;
            }
            
            return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {teachingTask}});
        }

        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetClassCourse(string openId, string id)
        {
            var user = this._userManager.Users
                .Include(b => b.Student)
                .Include(b=>b.Teacher)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var teachingTask = _teachingTaskService.GetAll().Include(b=>b.Course).Include(b => b.Classes).Include(b => b.Teachers)
                .FirstOrDefault(b => b.TeachingTaskId == id);

            if (teachingTask == null)
            {
                return Json(new AjaxResult("该教学任务不存在") {result = 99});
            }

            var list = _learnLogService.GetAll().Where(b => b.TeachingTaskId == id)
                .OrderByDescending(b => b.CreateTime);

            var students = _classService.GetAll().Include(b => b.Students)
                .Where(b => teachingTask.Classes.Select(c => c.ClassId).Contains(b.ClassId)).SelectMany(b => b.Students).ToArray();

            if (user.UserType == SchoolUserType.student)
            {
                if (!teachingTask.Classes.Select(b => b.ClassId).Contains(user.Student.ClassId))
                {
                    return Json(new AjaxResult("该学生不属于班级，不能查看信息") {result = 99});
                }
            }
            else if (user.UserType == SchoolUserType.teacher)
            {
                if (!teachingTask.Teachers.Select(b => b.TeacherId).Contains(user.Teacher.TeacherId))
                {
                    return Json(new AjaxResult("该教师不属于班级，不能查看信息") {result = 99});
                }
            }
            else
            {
                return Json(new AjaxResult("用户角色不对") {result = 99});
            }

            foreach (var xx in students)
            {
                xx.Class = null;
            }
            
            foreach (var item in teachingTask.Classes)
            {
                item.TeachingTask = null;
            }
            
            foreach (var item in teachingTask.Teachers)
            {
                item.TeachingTask = null;
            }
            
            
            return Json(new AjaxResult<object>("查询成功") {result = 0, data = new {students, list, teachingTask}});
        }

        [EnableCors("AllowSameDomain")]
        public IActionResult GetNotice(string id)
        {
            var learnLog = _learnLogService.Find(b => b.LearnLogId == id);

            var teachingTask = _teachingTaskService.GetAll().Include(b => b.Course).Include(b => b.Classes)
                .FirstOrDefault(b => b.TeachingTaskId == learnLog.TeachingTaskId);
            var teacher = _teacherService.Find(b => b.TeacherId == learnLog.TeacherId);

            object model = null;

            if (learnLog.Types == 0)
                model = _noticeService.Find(b => b.NoticeId == learnLog.ObjectId);
            else if (learnLog.Types == 1)
                model = _coursewareService.Find(b => b.CoursewareId == learnLog.ObjectId);
            else
                model = _papersService.GetAll().Include(b => b.PaperQuestions)
                    .FirstOrDefault(b => b.PaperId == learnLog.ObjectId);


            foreach (var item in teachingTask.Classes)
            {
                item.TeachingTask = null;
            }
            
            
            return Json(
                new AjaxResult<object>("查询成功") {result = 0, data = new {model, learnLog, teachingTask, teacher}});
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

            var teachingTask = _teachingTaskService.GetAll().Include(b => b.Course).Include(b => b.Classes)
                .FirstOrDefault(b => b.TeachingTaskId == learnLog.TeachingTaskId);
            var teacher = _teacherService.Find(b => b.TeacherId == learnLog.TeacherId);

            var model = _papersService.GetAll().Include(b => b.Teacher).Include(b => b.PaperQuestions)
                .FirstOrDefault(b => b.PaperId == learnLog.ObjectId);

            var answers = _paperAnswersService.GetAll().Include(b => b.PaperAnswerDetails).FirstOrDefault(
                b => b.PaperId == model.PaperId && b.StudentId == user.Student.StudentId && b.TeachingTaskId==learnLog.TeachingTaskId);
            
          

            foreach (var item in teachingTask.Classes)
            {
                item.TeachingTask = null;
            }

            return Json(new AjaxResult<object>("查询成功")
            {
                result = 0,
                data = new {model, learnLog, answers, teachingTask, teacher}
            });
        }

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> PushAnswer(Papers model,string id,string openId)
        {
            var user = this._userManager.Users.Include(b=>b.Teacher).Include(b=>b.Student).FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") { result = 99});
            }
            
            var learnLog = _learnLogService.Find(b => b.LearnLogId == id);
       

            var tmp = _paperAnswersService.Find(
                b => b.PaperId == model.PaperId && b.StudentId == user.Student.StudentId && b.TeachingTaskId==learnLog.TeachingTaskId);

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
                        IsRight = q.Answer.ToUpper()==temp,
                    });
                }

                var item=new PaperAnswers()
                {
                    PaperId = model.PaperId,
                    StudentId = user.Student.StudentId,
                    PaperAnswerDetails = list,
                    TeachingTaskId = learnLog.TeachingTaskId
                };
                await _paperAnswersService.Add(item);
                
                
                return Json(new AjaxResult<object>("提交成功") {result = 0, data = null});
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

            var model = _papersService.GetAll()
                .Include(b => b.PaperQuestions)
                .Include(b => b.PaperAnswers)
                .ThenInclude(b => b.PaperAnswerDetails)
                .FirstOrDefault(b=>b.PaperId==learnLog.ObjectId);

            var tmp = model.PaperAnswers.Where(b => b.TeachingTaskId == learnLog.TeachingTaskId).ToList();

            var abc = model.PaperQuestions.Select(b =>
                new
                {
                    item = b,
                    Count = (b.PaperAnswerDetails == null?0: b.PaperAnswerDetails.Where(c=>tmp.Any(d=>d.PaperAnswerId== c.PaperAnswerId)).ToArray().Count()),
                    right = (b.PaperAnswerDetails == null?0: b.PaperAnswerDetails.Where(c=>tmp.Any(d=>d.PaperAnswerId== c.PaperAnswerId)&&c.IsRight).ToArray().Count()),
                    //right = b.PaperAnswerDetails.Where(d => d.IsRight).ToArray().Length
                }
            );

            return Json(new AjaxResult<object>("查询成功")
            {
                result = 0,
                data = new {learnLog, model = abc}
            });
        }

        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> SendNotice(string id, string title, string des, string openId)
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
                TeachingTaskId = id,
                ObjectId = model.NoticeId,
                Name = title,
                Types = 0,
                TeacherId = user.Teacher.TeacherId
            });

            return Json(new AjaxResult("发布成功") {result = 0});
        }
        
        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> SendCoursewaree(string objectId, string id, string openId)
        {
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var model= _coursewareService.Find(b => b.CoursewareId == objectId);

            await _learnLogService.Add(new LearnLog()
            {
                TeachingTaskId = id,
                ObjectId = objectId,
                Name = model.Title,
                Types = 1,
                TeacherId = user.Teacher.TeacherId

            });

            return Json(new AjaxResult("发布成功") {result = 0});
        }
        
        [EnableCors("AllowSameDomain")]
        public async Task<IActionResult> SendPapers(string objectId, string id, string openId)
        {
            var user = this._userManager.Users.Include(b => b.Teacher).Include(b => b.Student)
                .FirstOrDefault(o => o.WxOpenId == openId);
            if (user == null)
            {
                return Json(new AjaxResult("用户查询失败") {result = 99});
            }

            var model= _papersService.Find(b => b.PaperId == objectId);

            await _learnLogService.Add(new LearnLog()
            {
                TeachingTaskId = id,
                ObjectId = objectId,
                Name = model.Title,
                Types = 2,
                TeacherId = user.Teacher.TeacherId

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
        
        [EnableCors("AllowSameDomain")]
        public IActionResult GetQrCode(string id)
        {
            Dora.Weixin.MP.Containers.AccessTokenContainer.Register(_wxConfig.AppID, _wxConfig.Appsecret);

            var a = Guid.NewGuid().ToString();
            var b = id;
            var c = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;

            var code = $@"QD,{a},{b},{c}";

            var temp = QrCodeApi.Create(_wxConfig.AppID, 1800, 1, QrCode_ActionName.QR_STR_SCENE, code);
            return
                Json(new AjaxResult(QrCodeApi.GetShowQrCodeUrl(temp.ticket)) { });
        }
        
        
    }
}