using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbContexts
{
    public class UniversityDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<LessonModel> Lessons { get; set; }
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
