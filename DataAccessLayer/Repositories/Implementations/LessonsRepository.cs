using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class LessonsRepository : ILessonsRepository
    {
        private UniversityDbContext db;
        public LessonsRepository(UniversityDbContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<LessonModel>> GetAllLessons()
        {
            return await db.Lessons.ToListAsync();
        }

        public async Task<LessonModel> GetLessonByLessonName(string lessonName)
        {
            return await db.Lessons.FirstOrDefaultAsync(b => b.LessonName == lessonName);
        }

        public async Task<bool> CreateLesson(LessonModel lesson)
        {
            db.Lessons.Add(lesson);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLesson(LessonModel lesson)
        {
            db.Lessons.Remove(lesson);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
