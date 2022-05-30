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

namespace BusinessLogicLayer.Services.Implementations
{
    public class LessonsService : ILessonsService
    {
        private readonly ILessonsRepository lessonsRepository;
        private readonly IModelToDtoFactory modelToDtoFactory;
        public LessonsService(ILessonsRepository lessonsRepository, IModelToDtoFactory modelToDtoFactory)
        {
            this.lessonsRepository = lessonsRepository;
            this.modelToDtoFactory = modelToDtoFactory;
        }


        public async Task<List<LessonModel>> GetAllLessons()
        {
            return await lessonsRepository.GetAllLessons();
        }

        public async Task<List<DtoLessonModel>> GetAllDtoLessons()
        {
            return modelToDtoFactory.TransformLessonModelToDtoLessonModel(await lessonsRepository.GetAllLessons());
        }

        public async Task<DtoLessonModel> GetLessonByLessonName(string lessonName)
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
    }
}
