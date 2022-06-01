using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUsersInLessonsRepository
    {
        public Task<UserModel?> IsUserOnLesson(string lessonName, string userName);

        public Task<int> AddUserOnLessonById(int lessonId, string userId);

        public Task<int> DeleteUserFromLessonById(int lessonId, string userId);

        public Task<List<UserModel>> GetAllUsersOnLesson(string lessonName);

        public Task<int> ClearUsersInLessonsByLessonId(int lessonId);
    }
}
