using Dora.wx;
using Microsoft.AspNetCore.Http.Features;

namespace Dora.School
{
    using Dora.Domain.Entities.Application;
    using Dora.Domain.Entities.School;
    using Dora.Infrastructure.Infrastructures;
    using Dora.Infrastructure.Infrastructures.Interfaces;
    using Dora.Services.Application;
    using Dora.Services.Application.Interfaces;
    using Dora.Services.School;
    using Dora.Services.School.Interfaces;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
//            services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

//            services.Configure<FormOptions>(x =>
//            {
//                x.ValueLengthLimit = int.MaxValue;
//                x.MultipartBodyLengthLimit = int.MaxValue;
//            });

            services.AddCors(options => options.AddPolicy(
                "AllowSameDomain",
                builder => builder.WithOrigins(
                    "http://localhost:56417",
                    "http://wx.nieba.cn"
                ).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials()
            ));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<SchoolUser, SchoolRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //应用程序的cookie常用设置
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "AspNetCoreAuthCookies"; //cookied的名称. 默认为AspNetCore.Cookies.
                options.Cookie.HttpOnly = true; //是否拒绝cookie从客户端脚本访问.默认为true.
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //Cookie保持有效的时间60分。//TimeSpan.FromDays(150);
                options.LoginPath = "/Login"; //在进行登录时自动重定向。
                options.LogoutPath = "/Logout"; //在进行注销时自动重定向。
                // options.AccessDeniedPath = "/Account/AccessDenied"; //当用户没有授权检查时将被重定向。
                // options.SlidingExpiration = true;//当TRUE时，新cookie将在当前cookie超过到期窗口一半时发出新的到期时间。默认为true。
                // Requires `using Microsoft.AspNetCore.Authentication.Cookies;`
                // options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;//401状态改为302状态并重定向到登录路径。
            });


            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<WxConfig>(Configuration.GetSection("wx"));


            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProfessionalService, ProfessionalService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IModuleService, ModuleService>();
            services.AddTransient<IModuleTypeService, ModuleTypeService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<ISyllabusService, SyllabusService>();
            services.AddTransient<ISyllabusPeriodService, SyllabusPeriodService>();
            services.AddTransient<ISyllabusLogService, SyllabusLogService>();
            services.AddTransient<ISyllabusBookService, SyllabusBookService>();
            services.AddTransient<ISyllabusFirstCourseService, SyllabusFirstCourseService>();
            services.AddTransient<ISyllabusProfessionalService, SyllabusProfessionalService>();
            services.AddTransient<ISyllabusTeacherService, SyllabusTeacherService>();
            services.AddTransient<ISyllabusApprovalService, SyllabusApprovalService>();
            services.AddTransient<IInfomationService, InfomationService>();
            services.AddTransient<ICoachRecordService, CoachRecordService>();
            services.AddTransient<ITermService, TermService>();
            services.AddTransient<IPublicClassRoomService, PublicClassRoomService>();
            services.AddTransient<ITrainingLabService, TrainingLabService>();
            services.AddTransient<IPersonnelTrainingService, PersonnelTrainingService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<ITeachingTaskService, TeachingTaskService>();
            services.AddTransient<ITeachingTaskDetailService, TeachingTaskDetailService>();
            services.AddTransient<ITeachingPlanService, TeachingPlanService>();
            services.AddTransient<ITeachingPlanDetailService, TeachingPlanDetailService>();
            services.AddTransient<ITeachingPlanTeacherService, TeachingPlanTeacherService>();


            services.AddTransient<IPaperAnswerDetailsService, PaperAnswerDetailsService>();
            services.AddTransient<IPaperAnswersService, PaperAnswersService>();
            services.AddTransient<IPaperQuestionsService, PaperQuestionsService>();
            services.AddTransient<IPapersService, PapersService>();
            services.AddTransient<ILearnLogService, LearnLogService>();
            services.AddTransient<INoticeService, NoticeService>();
            services.AddTransient<ICoursewareService, CoursewareService>();
            services.AddTransient<ITimeCardService, TimeCardService>();

            services.AddTransient<IDictService, DictService>();
            services.AddTransient<IDictTypeService, DictTypeService>();


            #region AddObject
            services.AddTimedJob();
            services.AddSession();
            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            #endregion
            
            return services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("AllowSameDomain");

            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseTimedJob();
            app.UseSession();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}",
                    defaults: new {Controllers = "Home"});

                routes.MapRoute(
                    name: "action",
                    template: "{action=Index}/{id?}",
                    defaults: new {controller = "Home"});

                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller}/{action}/{page?}",
                    defaults: new {controller = "Home", action = "Index"});
            });
        }
    }
}