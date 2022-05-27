using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUsersInLessonsService
    {
        public Task<bool> IsUserOnLesson(string lessonName, string userName);

        public Task<int> AddUserOnLessonById(int lessonId, string userId);

        public Task<int> DeleteUserFromLessonById(int lessonId, string userId);

        public Task<int> ClearCompareLessonById(int id);
    }
}
