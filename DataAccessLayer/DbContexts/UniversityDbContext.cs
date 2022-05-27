using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DbContexts
{
    public class UniversityDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<LessonModel> Lessons { get; set; }
        public DbSet<UserInLessonModel> UsersInLessons { get; set; }
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
