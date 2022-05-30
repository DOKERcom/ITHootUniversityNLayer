using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class UsersInLessonsRepository : IUsersInLessonsRepository
    {
        private UniversityDbContext db;
        public UsersInLessonsRepository(UniversityDbContext context)
        {
            db = context;
        }

        public async Task<UserModel?> IsUserOnLesson(string lessonName, string userName)
        {
            return await    (from UsersInLessons in db.UsersInLessons
                            join Users in db.Users on UsersInLessons.UserId equals Users.Id
                            where Users.UserName == userName
                            join Lessons in db.Lessons on UsersInLessons.LessonId equals Lessons.Id
                            where Lessons.LessonName == lessonName
                            select Users).FirstOrDefaultAsync();
        }

        public async Task<List<UserModel>> GetAllUsersOnLesson(string lessonName)
        {
            var users = await (from UsersInLessons in db.UsersInLessons
                                   join Users in db.Users on UsersInLessons.UserId equals Users.Id
                                   join Lessons in db.Lessons on UsersInLessons.LessonId equals Lessons.Id
                               where Lessons.LessonName == lessonName
                               select Users).ToListAsync();
            return users;
        }

        public async Task<int> AddUserOnLessonById(UserInLessonModel userInLesson)
        {
            db.UsersInLessons.Add(userInLesson);
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteUserFromLessonById(int lessonId, string userId)
        {
            db.UsersInLessons.Remove(db.UsersInLessons.FirstOrDefault(b => b.LessonId == lessonId && b.UserId == userId));
            return await db.SaveChangesAsync();
        }

        public async Task<int> ClearUsersInLessonsByLessonId(int lessonId)
        {
            db.UsersInLessons.RemoveRange(db.UsersInLessons.Where(b => b.LessonId == lessonId).ToList());
            return await db.SaveChangesAsync();
        }
    }
}
