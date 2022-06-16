using BusinessLogicLayer.Services.Interfaces;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;

namespace ITHootUniversity.WebAppFactories.Implementations
{
    public class CabinetViewModelFactory : ICabinetViewModelFactory
    {
        private readonly IUsersService usersService;

        private readonly ILessonsService lessonsService;

        private readonly IRolesService rolesService;

        private readonly IDtoToViewModelFactory dtoToViewModelFactory;

        public CabinetViewModelFactory(
            IUsersService usersService,
            IDtoToViewModelFactory dtoToViewModelFactory,
            ILessonsService lessonsService,
            IRolesService rolesService)
        {
            this.usersService = usersService;
            this.dtoToViewModelFactory = dtoToViewModelFactory;
            this.lessonsService = lessonsService;
            this.rolesService = rolesService;
        }

        public async Task<CabinetViewModel> CreateAndFillCabinetViewModel()
        {
            CabinetViewModel cabinetViewModel = new CabinetViewModel();

            cabinetViewModel.UserViewModels = await dtoToViewModelFactory.TransformDtoUserModelToUserViewModel(await usersService.GetAllDtoUsers());

            cabinetViewModel.LessonViewModels = dtoToViewModelFactory.TransformDtoLessonModelToLessonViewModel(await lessonsService.GetAllDtoLessons());

            cabinetViewModel.Roles = rolesService.GetAllRoles().ToList();

            return cabinetViewModel;
        }
    }
}


