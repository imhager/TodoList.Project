using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Entity;

namespace TodoList.DbMapping
{
    /// <summary>
    /// DbContext with identity
    /// </summary>
    public class SqlitesWithIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SqlitesWithIdentityDbContext(DbContextOptions<SqlitesWithIdentityDbContext> options) : base(options) { }

        public DbSet<TodoUser> TodoUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TodoUser>().ToTable("TodoUser").HasKey("Id");
        }
    }
}
