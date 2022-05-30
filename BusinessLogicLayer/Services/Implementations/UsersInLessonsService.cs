using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using ITHootUniversity.Models;
using ITHootUniversity.Services.Interfaces;
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
        private readonly IUsersService usersService;
        private readonly ILessonsService lessonsService;
        private readonly IResultBuilderService resultBuilderService;
        private readonly IRolesService rolesService;
        public UsersInLessonsService(IUsersInLessonsRepository usersInLessonsRepository, IUsersService usersService, IResultBuilderService resultBuilderService, ILessonsService lessonsService, IRolesService rolesService)
        {
            this.usersInLessonsRepository = usersInLessonsRepository;
            this.usersService = usersService;
            this.resultBuilderService = resultBuilderService;
            this.lessonsService = lessonsService;
            this.rolesService = rolesService;
        }

        public async Task<bool> IsUserOnLesson(string lessonName, string userName)
        {
            UserModel? user = await usersInLessonsRepository.IsUserOnLesson(lessonName, userName);

            return user == null ? false : true;
        }

        public async Task<int> CountTeachersOnLesson(string lessonName)
        {
            int i = 0;
            foreach (var user in await usersInLessonsRepository.GetAllUsersOnLesson(lessonName))
            {
                if (await rolesService.IsUserInRole(await usersService.GetUserByLogin(user.UserName), "Teacher"))
                    i++;
            }
            return i;
        }

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

        public async Task<int> ClearUsersInLessonsByLessonId(int lessonId)
        {
            return await usersInLessonsRepository.ClearUsersInLessonsByLessonId(lessonId);
        }

        public async Task<ModelForJsonResult> AddUserToLesson(string lessonName, string userName)
        {
            if (await usersService.GetUserByLogin(userName) == null)
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) not found!");

            if (await lessonsService.GetLessonByLessonName(lessonName) == null)
                return resultBuilderService.ToModelForJsonResult("", $"Lesson ({lessonName}) not found!");

            if (await IsUserOnLesson(lessonName, userName))
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) already joined to the lesson ({lessonName})");


            if (await rolesService.IsUserInRole(await usersService.GetUserByLogin(userName), "Teacher"))
            {
                if (await CountTeachersOnLesson(lessonName) < 2)
                {
                    await AddUserOnLessonById((await lessonsService.GetDtoLessonByLessonName(lessonName)).LessonId, (await usersService.GetUserByLogin(userName)).Id);
                        return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) added to the lesson ({lessonName})");
                }
                else
                {
                    return resultBuilderService.ToModelForJsonResult("", $"There are a lot of Teacher on lesson ({lessonName})");
                }
            }
            else
            {
                await AddUserOnLessonById((await lessonsService.GetDtoLessonByLessonName(lessonName)).LessonId, (await usersService.GetUserByLogin(userName)).Id);
                    return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) added to the lesson ({lessonName})");
            }
        }

        public async Task<ModelForJsonResult> DelUserFromLesson(string lessonName, string userName)
        {
            if (await usersService.GetUserByLogin(userName) == null)
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) not found!");

            if (await lessonsService.GetLessonByLessonName(lessonName) == null)
                return resultBuilderService.ToModelForJsonResult("", $"Lesson ({lessonName}) not found!");

            if (!await IsUserOnLesson(lessonName, userName))
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) didn't find on lesson ({lessonName})");

            await DeleteUserFromLessonById((await lessonsService.GetDtoLessonByLessonName(lessonName)).LessonId, (await usersService.GetUserByLogin(userName)).Id);

            if (await rolesService.IsUserInRole(await usersService.GetUserByLogin(userName), "Teacher"))
            {
                if (await CountTeachersOnLesson(lessonName) < 1)
                {
                    await ClearUsersInLessonsByLessonId((await lessonsService.GetDtoLessonByLessonName(lessonName)).LessonId);
                    await lessonsService.DeleteLesson(lessonName);
                }
            }

            return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) was remove from the lesson ({lessonName})");
        }

        public async Task<ModelForJsonResult> JoinToLesson(string lessonName, string userName)
        {
            var user = await usersService.GetUserByLogin(userName);
            if (user == null)
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) not found! (Try reload page)");

            var lesson = await lessonsService.GetLessonByLessonName(lessonName);
            if (lesson == null)
                return resultBuilderService.ToModelForJsonResult("", $"Lesson ({lessonName}) not found!");

            if (await IsUserOnLesson(lessonName, userName))
                return resultBuilderService.ToModelForJsonResult("", $"You ({userName}) already joined to the lesson ({lessonName})");

            if (await rolesService.IsUserInRole((await usersService.GetUserByLogin(userName)), "Teacher"))
            {
                if (await CountTeachersOnLesson(lessonName) < 2)
                {
                    await AddUserOnLessonById(lesson.Id, user.Id);
                    return resultBuilderService.ToModelForJsonResult("", $"You ({userName}) added to the lesson ({lessonName})");
                }
                else
                {
                    return resultBuilderService.ToModelForJsonResult("", $"There are a lot of Teacher on lesson ({lessonName})");
                }
            }
            else
            {
                await AddUserOnLessonById(lesson.Id, user.Id);
                return resultBuilderService.ToModelForJsonResult("", $"You ({userName}) added to the lesson ({lessonName})");
            }

        }

        public async Task<ModelForJsonResult> LeftFromLesson(string lessonName, string userName)
        {
            var user = await usersService.GetUserByLogin(userName);
            if (user == null)
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) not found! (Try reload page)");

            var lesson = await lessonsService.GetLessonByLessonName(lessonName);
            if (lesson == null)
                return resultBuilderService.ToModelForJsonResult("", $"Lesson ({lessonName}) not found!");

            if (!await IsUserOnLesson(lessonName, userName))
                return resultBuilderService.ToModelForJsonResult("", $"You ({userName}) didn't find on lesson ({lessonName})");

            await DeleteUserFromLessonById(lesson.Id, user.Id);
            if (await rolesService.IsUserInRole((await usersService.GetUserByLogin(userName)), "Teacher"))
            {
                if (await CountTeachersOnLesson(lesson.LessonName) < 1)
                {
                    await ClearUsersInLessonsByLessonId(lesson.Id);
                    await lessonsService.DeleteLesson(lesson);
                }
            }
            return resultBuilderService.ToModelForJsonResult("", $"You ({userName}) was remove from the lesson ({lessonName})");
        }
    }
}
