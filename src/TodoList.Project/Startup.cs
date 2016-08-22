using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoList.Services;
using NLog.Extensions.Logging;
using TodoList.DbMapping;
using Microsoft.EntityFrameworkCore;
using TodoList.Entity;
using TodoList.Framework;

namespace TodoList.Project
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"Config/appsettings.{env.EnvironmentName}.json", optional: true)
                //.AddJsonFile($"Config/hostsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 基于Identity认证，使用EF+Sqlite，需要在configure中增加app.UseIdentity()的组件；
            services.AddDbContext<SqlitesWithIdentityDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
           {
               options.Password = new PasswordOptions()
               {
                   RequireNonAlphanumeric = false,
                   RequireUppercase = false
               };
           }).AddEntityFrameworkStores<SqlitesWithIdentityDbContext>().AddDefaultTokenProviders();

            #endregion

            #region 不使用Identity，使用EF+Sqlite
            //services.AddEntityFrameworkSqlite().AddDbContext<SqlLitesDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            #endregion

            // Add framework services.
            services.AddMvc();

            // ioc 

            //services.AddTransient<IDbContextSelector, SqlLitesDbContext>();
            // todo 后需更改为json、xml配置文件读取方式
            services.RegisterServices();// 抽取到另外一个扩展类中，精简startup中的注入

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            /*
             *所有注入的组件是有一定的先后顺序的；比如异常在前；
             * Identity在Mvc前； 
             * 
             * 
             */

            loggerFactory.AddNLog();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            InitializeDatabase(app.ApplicationServices);

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

            app.UseIdentity(); // the authentication must be configured before mvc

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="serviceProvider"></param>
        private void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<SqlitesWithIdentityDbContext>();
                db.Database.EnsureCreated();
            }
        }
    }
}
