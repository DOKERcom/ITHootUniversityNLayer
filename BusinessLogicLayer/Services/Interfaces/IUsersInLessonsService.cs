using ITHootUniversity.Models;
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

        public Task<int> ClearUsersInLessonsByLessonId(int lessonId);

        public Task<ModelForJsonResult> AddUserToLesson(string lessonName, string userName);

        public Task<ModelForJsonResult> DelUserFromLesson(string lessonName, string userName);
    }
}
