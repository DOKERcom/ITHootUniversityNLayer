using BusinessLogicLayer.DtoModels;
using ITHootUniversity.ViewModels;

namespace ITHootUniversity.WebAppFactories.Interfaces
{
    public interface IDtoToViewModelFactory
    {
        public UserViewModel TransformDtoUserModelToUserViewModel(DtoUserModel user);

        public List<UserViewModel> TransformDtoUserModelToUserViewModel(IEnumerable<DtoUserModel> users);

        public List<LessonViewModel> TransformDtoLessonModelToLessonViewModel(IEnumerable<DtoLessonModel> lessons);

        public LessonViewModel TransformDtoLessonModelToLessonViewModel(DtoLessonModel lesson);
    }
}
