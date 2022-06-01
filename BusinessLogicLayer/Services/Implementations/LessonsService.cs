using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.BusinessFactories.Interfaces;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITHootUniversity.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepository lessonsRepository;

        private readonly IModelToDtoFactory modelToDtoFactory;

        private readonly IResultBuilderService resultBuilderService;

        private readonly IUsersService usersService;

        private readonly IUsersInLessonsRepository usersInLessonsRepository;

        private readonly IRolesService rolesService;

        public LessonsService(ILessonsRepository lessonsRepository, IModelToDtoFactory modelToDtoFactory, IResultBuilderService resultBuilderService, IUsersService usersService, IRolesService rolesService, IUsersInLessonsRepository usersInLessonsRepository)
        {
            this.lessonsRepository = lessonsRepository;
            this.modelToDtoFactory = modelToDtoFactory;
            this.resultBuilderService = resultBuilderService;
            this.usersService = usersService;
            this.rolesService = rolesService;
            this.usersInLessonsRepository = usersInLessonsRepository;
        }


        public async Task<List<LessonModel>> GetAllLessons()
        {
            return await lessonsRepository.GetAllLessons();
        }

        public async Task<List<DtoLessonModel>> GetAllDtoLessons()
        {
            return modelToDtoFactory.TransformLessonModelToDtoLessonModel(await lessonsRepository.GetAllLessons());
        }

        public async Task<LessonModel> GetLessonByLessonName(string lessonName)
        {
            return await lessonsRepository.GetLessonByLessonName(lessonName);
        }

        public async Task<DtoLessonModel> GetDtoLessonByLessonName(string lessonName)
        {
            return modelToDtoFactory.TransformLessonModelToDtoLessonModel(await lessonsRepository.GetLessonByLessonName(lessonName));
        }

        public async Task<bool> CreateLesson(LessonModel lesson)
        {
            return await lessonsRepository.CreateLesson(lesson);
        }

        public async Task<bool> DeleteLesson(LessonModel lesson)
        {
            return await lessonsRepository.DeleteLesson(lesson);
        }

        private async Task<int> ClearUsersInLessonsByLessonId(int lessonId)
        {
            return await usersInLessonsRepository.ClearUsersInLessonsByLessonId(lessonId);
        }

        public async Task<ModelForJsonResult> CreateLesson(string lessonName, string userName)
        {
            if (await GetLessonByLessonName(lessonName) != null)
                return resultBuilderService.ToModelForJsonResult("", $"Lesson ({lessonName}) already created!");

            if (await usersService.GetUserByLogin(userName) == null)
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) not found!");

            if (!await rolesService.IsUserInRole(await usersService.GetUserByLogin(userName), "Teacher"))
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) is not a teacher!");

            await CreateLesson(new LessonModel { LessonName = lessonName });

            await usersInLessonsRepository.AddUserOnLessonById((await GetLessonByLessonName(lessonName)).Id, (await usersService.GetUserByLogin(userName)).Id);

            return resultBuilderService.ToModelForJsonResult("", $"You have successfully created a lesson ({lessonName}) and added a teacher ({userName})!");
        }

        public async Task<ModelForJsonResult> DeleteLesson(string lessonName)
        {
            if (await GetDtoLessonByLessonName(lessonName) == null)
                return resultBuilderService.ToModelForJsonResult("", $"Lesson ({lessonName}) not found!");

            await ClearUsersInLessonsByLessonId((await GetDtoLessonByLessonName(lessonName)).LessonId);

            await lessonsRepository.DeleteLesson(await GetLessonByLessonName(lessonName));

            return resultBuilderService.ToModelForJsonResult("", $"You have successfully deleted a lesson ({lessonName})!");
        }
    }
}
