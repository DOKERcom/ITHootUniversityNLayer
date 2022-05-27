using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.ModelToDtoHandlers.Interfaces;
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
        private readonly ITransformatorModelToDto TransformatorModelToDto;
        public LessonsService(ILessonsRepository lessonsRepository, ITransformatorModelToDto TransformatorModelToDto)
        {
            this.lessonsRepository = lessonsRepository;
            this.TransformatorModelToDto = TransformatorModelToDto;
        }

        public async Task<List<DtoLessonModel>> GetAllLessons()
        {
            return TransformatorModelToDto.TransformLessonModelToDtoLessonModel(await lessonsRepository.GetAllLessons());
        }

        public async Task<DtoLessonModel> GetLessonByLessonName(string lessonName)
        {
            return TransformatorModelToDto.TransformLessonModelToDtoLessonModel(await lessonsRepository.GetLessonByLessonName(lessonName));
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
