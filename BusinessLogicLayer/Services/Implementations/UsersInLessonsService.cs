using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implementations
{
    public class UsersInLessonsService : IUsersInLessonsService
    {
        private readonly IUsersInLessonsRepository usersInLessonsRepository;
        public UsersInLessonsService(IUsersInLessonsRepository usersInLessonsRepository)
        {
            this.usersInLessonsRepository = usersInLessonsRepository;
        }

        public async Task<bool> IsUserOnLesson(string lessonName, string userName)
        {
            UserModel? user = await usersInLessonsRepository.IsUserOnLesson(lessonName, userName);

            return user == null ? true : false;
        }

        //public async Task<int> CountTeachersOnLesson(string lessonName)
        //{
        //    return await usersInLessonsRepository.CountTeachersOnLesson(lessonName);
        //}

        public async Task<int> AddUserOnLessonById(int lessonId, string userId)
        {
            UserInLessonModel UserInLesson = new UserInLessonModel 
            { 
                LessonId = lessonId, 
                UserId = userId 
            };

            return await usersInLessonsRepository.AddUserOnLessonById(UserInLesson);
        }

        public async Task<int> DeleteUserFromLessonById(int lessonId, string userId)
        {
            return await usersInLessonsRepository.DeleteUserFromLessonById(lessonId, userId);
        }

        public async Task<int> ClearCompareLessonById(int id)
        {
            return await usersInLessonsRepository.ClearCompareLessonById(id);
        }
    }
}
