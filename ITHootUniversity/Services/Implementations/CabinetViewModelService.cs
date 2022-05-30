using BusinessLogicLayer.Services.Interfaces;
using ITHootUniversity.Services.Interfaces;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;

namespace ITHootUniversity.Services.Implementations
{
    public class CabinetViewModelService : ICabinetViewModelService
    {
        private readonly IUsersService usersService;

        private readonly ILessonsService lessonsService;

        private readonly IDtoToViewModelFactory dtoToViewModelFactory;

        public CabinetViewModelService(
            IUsersService usersService, 
            IDtoToViewModelFactory dtoToViewModelFactory, 
            ILessonsService lessonsService)
        {
            this.usersService = usersService;
            this.dtoToViewModelFactory = dtoToViewModelFactory;
            this.lessonsService = lessonsService;
        }

        public async Task<CabinetViewModel> CreateAndFillCabinetViewModel()
        {
            CabinetViewModel cabinetViewModel = new CabinetViewModel();

            cabinetViewModel.UserViewModels = await dtoToViewModelFactory.TransformDtoUserModelToUserViewModel(await usersService.GetAllDtoUsers());

            cabinetViewModel.LessonViewModels = dtoToViewModelFactory.TransformDtoLessonModelToLessonViewModel(await lessonsService.GetAllDtoLessons());

            return cabinetViewModel;
        }
    }
}
    

