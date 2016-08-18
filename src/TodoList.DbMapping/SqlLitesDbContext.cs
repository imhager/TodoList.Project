using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TodoList.DbMapping
{
    public class SqlLitesDbContext : DbContext//IdentityDbContext<ApplicationUser >//, IDbContextSelector
    {
        public SqlLitesDbContext(DbContextOptions<SqlLitesDbContext> options)
            : base(options)
        {
        }


        //public void ConfigureDbContext(IServiceCollection services, IConfigurationRoot configuration)
        //{
        // IdentityDbContext<ApplicationUser >
        //    services.AddDbContext<SqlLitesDbContext>(options => options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
        //    services.AddIdentity<TodoUser, IdentityRole>(options =>
        //    {
        //        options.Password = new PasswordOptions()
        //        {
        //            RequireNonAlphanumeric = false,
        //            RequireUppercase = false
        //        };
        //    }).AddEntityFrameworkStores<SqlLitesDbContext>().AddDefaultTokenProviders();
        //}

        // DbContext
        //services.AddEntityFramework()
        //            .AddEntityFrameworkSqlite()
        //            .AddDbContext<WebsiteDbContext>(
        //                options => options.UseSqlite("Data Source=./mvcefsample.sqlite"));

        public DbSet<TodoUser> TodoUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TodoUser>().ToTable("TodoUser").HasKey("Id");
        }

    }
}
