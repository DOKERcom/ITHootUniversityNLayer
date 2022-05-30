using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Services.Interfaces;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;

namespace ITHootUniversity.WebAppFactories.Implementations
{
    public class DtoToViewModelFactory : IDtoToViewModelFactory
    {
        private readonly IRolesService rolesService;
        public DtoToViewModelFactory(IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

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

        public async Task<List<UserViewModel>> TransformDtoUserModelToUserViewModel(IEnumerable<DtoUserModel> users)
        {
            List<UserViewModel> userViewModels = new List<UserViewModel>();
            foreach (DtoUserModel user in users)
            {
                userViewModels.Add(new UserViewModel { 
                    UserName = user.UserName, 
                    Role = (await rolesService.GetUserRoles(user.UserName)).FirstOrDefault() });
            }

            return userViewModels;
        }
    }
}
