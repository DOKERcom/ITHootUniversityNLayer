using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ILessonsService
    {
        public Task<List<DtoLessonModel>> GetAllLessons();

        public Task<DtoLessonModel> GetLessonByLessonName(string lessonName);

        public Task<bool> CreateLesson(LessonModel lesson);

        public Task<bool> DeleteLesson(LessonModel lesson);

    }
}
