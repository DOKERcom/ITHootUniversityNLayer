using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.BusinessFactories.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessFactories.Implementations
{
    public class ModelToDtoFactory : IModelToDtoFactory
    {
        //----------------LessonModel -> DtoLessonModel-----------------------
        public List<DtoLessonModel> TransformLessonModelToDtoLessonModel(IEnumerable<LessonModel> lessons)
        {
            List<DtoLessonModel> dtoLessons = new List<DtoLessonModel>();

            foreach (LessonModel lesson in lessons)
            {
                dtoLessons.Add(new DtoLessonModel {
                    LessonId = lesson.Id,
                    LessonName = lesson.LessonName
                });
            }

            return dtoLessons;
        }

        public DtoLessonModel TransformLessonModelToDtoLessonModel(LessonModel lesson)
        {
            if (lesson == null)
                return null;
            DtoLessonModel dtoLesson = new DtoLessonModel
            {
                LessonId = lesson.Id,
                LessonName = lesson.LessonName
            };

            return dtoLesson;
        }


        //----------------UserModel -> DtoUserModel-----------------------
        public DtoUserModel TransformUserModelToDtoUserModel(UserModel user)
        {
            if(user == null)
                return null;

            DtoUserModel dtoUser = new DtoUserModel
            {
                UserName = user.UserName
            };

            return dtoUser;
        }

        public List<DtoUserModel> TransformUserModelToDtoUserModel(IEnumerable<UserModel> users)
        {
            List<DtoUserModel> dtoUsers = new List<DtoUserModel>();

            foreach (UserModel user in users)
            {
                dtoUsers.Add(new DtoUserModel { UserName = user.UserName });
            }

            return dtoUsers;
        }
    }
}
