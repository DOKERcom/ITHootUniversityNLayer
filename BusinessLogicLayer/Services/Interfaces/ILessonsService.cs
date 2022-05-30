using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Models;
using ITHootUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ILessonsService
    {
        public Task<List<DtoLessonModel>> GetAllDtoLessons();

        public Task<List<LessonModel>> GetAllLessons();

        public Task<LessonModel> GetLessonByLessonName(string lessonName);

        public Task<bool> CreateLesson(LessonModel lesson);

        public Task<bool> DeleteLesson(LessonModel lesson);

        public Task<ModelForJsonResult> CreateLesson(string lessonName, string userName);

        public Task<ModelForJsonResult> DeleteLesson(string lessonName);

        public Task<DtoLessonModel> GetDtoLessonByLessonName(string lessonName);

    }
}
