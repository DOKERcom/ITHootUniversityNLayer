using BusinessLogicLayer.DtoModels;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;

namespace ITHootUniversity.WebAppFactories.Implementations
{
    public class DtoToViewModelFactory : IDtoToViewModelFactory
    {
        public LessonViewModel TransformDtoLessonModelToLessonViewModel(DtoLessonModel lesson)
        {
            LessonViewModel lessonViewModel = new LessonViewModel
            {
                    LessonName = lesson.LessonName,
            };

            return lessonViewModel;
        }

        public List<LessonViewModel> TransformDtoLessonModelToLessonViewModel(IEnumerable<DtoLessonModel> lessons)
        {
            List<LessonViewModel> lessonViewModels = new List<LessonViewModel>();

            foreach (DtoLessonModel user in lessons)
            {
                lessonViewModels.Add(new LessonViewModel { LessonName = user.LessonName });
            }

            return lessonViewModels;
        }

        public UserViewModel TransformDtoUserModelToUserViewModel(DtoUserModel user)
        {
            UserViewModel userViewModel = new UserViewModel
            {
                UserName = user.UserName,
            };

            return userViewModel;
        }

        public List<UserViewModel> TransformDtoUserModelToUserViewModel(IEnumerable<DtoUserModel> users)
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (DtoUserModel user in users)
            {
                userViewModels.Add(new UserViewModel { UserName = user.UserName });
            }

            return userViewModels;
        }
    }
}
