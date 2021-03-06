using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessFactories.Interfaces
{
    public interface IModelToDtoFactory
    {
        public DtoUserModel TransformUserModelToDtoUserModel(UserModel user);

        public List<DtoUserModel> TransformUserModelToDtoUserModel(IEnumerable<UserModel> users);

        public List<DtoLessonModel> TransformLessonModelToDtoLessonModel(IEnumerable<LessonModel> lessons);

        public DtoLessonModel TransformLessonModelToDtoLessonModel(LessonModel lesson);
    }
}
