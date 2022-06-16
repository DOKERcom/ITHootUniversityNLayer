using BusinessLogicLayer.DtoModels;
using ITHootUniversity.ViewModels;

namespace ITHootUniversity.WebAppFactories.Interfaces
{
    public interface IDtoToViewModelFactory
    {
        public Task<UserViewModel> TransformDtoUserModelToUserViewModel(DtoUserModel user);

        public Task<List<UserViewModel>> TransformDtoUserModelToUserViewModel(IEnumerable<DtoUserModel> users);

        public List<LessonViewModel> TransformDtoLessonModelToLessonViewModel(IEnumerable<DtoLessonModel> lessons);

        public Task<LessonViewModel> TransformDtoLessonModelToLessonViewModel(DtoLessonModel lesson);
    }
}
