using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dora.Core;
using Dora.Domain.Entities.School;
using Dora.Repositorys.School.Interfaces;
using Dora.Services.School.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dora.Test.Controllers
{
    [EnableCors("AllowSameDomain")]
    public class wxApiController : Controller
    {
        IClassRepository classRepository;
        IClassService classService;

        ICourseRepository courseRepository;
        ICourseService courseService;

        ISchoolUserRepository schoolUserRepository;
        ISchoolUserService schoolUserService;


        public wxApiController
        (
            IClassRepository _classRepository,
            IClassService _classService,

            ICourseRepository _courseRepository,
            ICourseService _courseService,

            ISchoolUserRepository _schoolUserRepository,
            ISchoolUserService _schoolUserService
        )
        {
            this.classRepository = _classRepository;
            this.classService = _classService;
            this.courseRepository = _courseRepository;
            this.courseService = _courseService;
            this.schoolUserRepository = _schoolUserRepository;
            this.schoolUserService = _schoolUserService;

        }

        [AllowAnonymous]
        [EnableCors("AllowSameDomain")]
        [HttpGet]
        public AjaxResult<IQueryable<Course>> GetCourseList()
        {
            var rst = new AjaxResult<IQueryable<Course>>("读取数据成功")
            {
                data = this.courseRepository.GetAll().Include(b => b.Classes).ThenInclude(b => b.User).OrderByDescending(b=>b.CreateTime),
                method = "GetCourseList",
                result = 1
            };

            return rst;
        }

        [HttpPost]
        public async Task<AjaxResult<IQueryable<Course>>> CreateCourse(string courseName, string[] classList)
        {

            List<Class> list = new List<Class>();
            foreach (var item in classList)
            {
                list.Add(new Class() { Name = item, InviteCode = item });
            }


            var model = new Course()
            {
                Name = courseName,
                Classes = list,
            };

            var temp = await this.courseService.Add(model);

            if (temp)
            {
                return new AjaxResult<IQueryable<Course>>("添加成功")
                {
                    data = this.courseRepository.GetAll().Include(b => b.Classes),
                    method = "GetCourseList",
                    result = 1
                };
            }
            else
            {
                return new AjaxResult<IQueryable<Course>>("添加失败")
                {
                    data = this.courseRepository.GetAll().Include(b => b.Classes),
                    method = "GetCourseList",
                    result = 0
                };
            }
        }

        [HttpPost]
        public async Task<AjaxResult> CreateSchoolUser(string openid, string name, string wxAvatar, SchoolUserType userType)
        {
            SchoolUser model = new SchoolUser() { WxOpenId = openid, WxName = name, WxAvatar = wxAvatar, UserType = userType };

            var temp = await schoolUserService.Add(model);
            if (temp)
            {
                return new AjaxResult("添加成功")
                {
                    method = "CreateSchoolUser",
                    result = 1
                };
            }
            else
            {
                return new AjaxResult("添加失败")
                {
                    method = "CreateSchoolUser",
                    result = 0
                };
            }
        }

    }



}
