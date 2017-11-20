using Dora.Infrastructure.Infrastructures;
using Dora.Infrastructure.Infrastructures.Interfaces;
using Dora.Repositorys.School;
using Dora.Repositorys.School.Interfaces;
using Dora.Repositorys.Systems;
using Dora.Repositorys.Systems.Interfaces;
using Dora.Services.School;
using Dora.Services.School.Interfaces;
using Dora.Services.Systems;
using Dora.Services.Systems.Interfaces;
using Dora.Services.Wx;
using Dora.Services.Wx.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dora.Test
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


            services.AddTransient<IDictRepository, DictRepository>();
            services.AddTransient<IDictService, DictService>();

            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IClassService, ClassService>();

            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();

            services.AddTransient<ISchoolUserRepository, SchoolUserRepository>();
            services.AddTransient<ISchoolUserService, SchoolUserService>();


            services.AddScoped<IQyhApiService, QyhApiService>();

            services.AddScoped<IDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("AllowSameDomain");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
