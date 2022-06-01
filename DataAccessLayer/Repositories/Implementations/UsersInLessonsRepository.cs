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
        private IUsersRepository usersRepository;
        public UsersInLessonsRepository(UniversityDbContext context, IUsersRepository usersRepository)
        {
            db = context;
            this.usersRepository = usersRepository;
        }

        public async Task<UserModel> IsUserOnLesson(string lessonName, string userName)
        {
            var lessons = await db.Lessons.Include(u => u.Users).ToListAsync();
            foreach(var lesson in lessons)
            {
                if (lesson.LessonName == lessonName) 
                {
                    foreach (var user in lesson.Users)
                    {
                        if (user.UserName == userName)
                        {
                            return user;
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<UserModel>> GetAllUsersOnLesson(string lessonName)
        {
            return (await db.Lessons.Where(u => u.LessonName == lessonName).FirstOrDefaultAsync()).Users;
        }

        public async Task<int> AddUserOnLessonById(int lessonId, string userId)
        {
            LessonModel lesson = db.Lessons.First(p => p.Id == lessonId);
            lesson.Users.Add(await usersRepository.GetUserById(userId));
            return await db.SaveChangesAsync();
        }

        public async Task<int> DeleteUserFromLessonById(int lessonId, string userId)
        {
            UserModel user = db.Users.First(p => p.Id == userId);
            LessonModel lesson = user.Lessons.First(p => p.Id == lessonId);
            lesson.Users.Remove(user);
            return await db.SaveChangesAsync();
        }

        public async Task<int> ClearUsersInLessonsByLessonId(int lessonId)
        {
            LessonModel lesson = await db.Lessons.Include(p => p.Users).FirstAsync();
            lesson.Users.Clear();
            return await db.SaveChangesAsync();
        }
    }
}
