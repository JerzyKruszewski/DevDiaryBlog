using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevDiaryBlog.Web.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevDiaryBlog.Web.Data
{
    public class DevDiaryDatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DevDiaryDatabaseContext(DbContextOptions<DevDiaryDatabaseContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionString"]);
            }
        }
    }
}
