using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface ILessonsRepository
    {
        public Task<IEnumerable<LessonModel>> GetAllLessons();

        public Task<LessonModel> GetLessonByLessonName(string lessonName);

        public Task<bool> CreateLesson(LessonModel lesson);

        public Task<bool> DeleteLesson(LessonModel lesson);
    }
}
