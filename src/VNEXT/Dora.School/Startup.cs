using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Dora.Domain.Entities.Application;
using Dora.Domain.Entities.School;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Infrastructure.Infrastructures;
using Dora.Repositorys.School.Interfaces;
using Dora.Repositorys.School;
using Dora.Services.School;
using Dora.Services.School.Interfaces;

namespace Dora.School
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(
            "AllowSameDomain",
            builder => builder.WithOrigins(
            "http://localhost:8080",
            "http://os.nieba.cn"
            ).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials()
            ));

            services.AddMvc();




            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<SchoolUser, IdentityRole>(
            options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }
            )
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<AppSettings>(options =>
            {
                options.SiteTitle = Configuration["AppSettings:SiteTitle"];
                options.FrameWorkName = Configuration["AppSettings:FrameWorkName"];
                options.FrameWorkVersion = Configuration["AppSettings:FrameWorkVersion"];
                options.AppName = Configuration["AppSettings:AppName"];
                options.AppVersion = Configuration["AppSettings:AppVersion"];
                options.FrameWorkWeb = Configuration["AppSettings:FrameWorkWeb"];
            });


            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddTransient<IProfessionalRepository, ProfessionalRepository>();
            services.AddTransient<IProfessionalService, ProfessionalService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("AllowSameDomain");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                //app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();

            app.UseIdentity();

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
    name: "default",
    template: "{controller=Home}/{action=Index}/{id?}",
    defaults: new { Controllers = "Home" });

                routes.MapRoute(
    name: "action",
    template: "{action=Index}/{id?}",
    defaults: new { controller = "Home" });


                routes.MapRoute(
    name: "areaRoute",
    template: "{area:exists}/{controller}/{action}/{page?}",
    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
