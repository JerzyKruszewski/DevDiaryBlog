using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevDiaryBlog.Web.Model;
using Microsoft.EntityFrameworkCore;

namespace DevDiaryBlog.Web.Data
{
    public class DevDiaryDatabaseContext : DbContext
    {
        public DevDiaryDatabaseContext(DbContextOptions<DevDiaryDatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS02;Database=DevDiaryBlogDatabase;Trusted_Connection=True;");
            }
        }
    }
}
