using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITHootUniversity.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        private readonly ICreateOrUpdateUserService createOrUpdateUserService;
        private readonly IViewModelToDtoFactory viewModelToDtoFactory;
        public CabinetController(ICreateOrUpdateUserService createOrUpdateUserService, IViewModelToDtoFactory viewModelToDtoFactory)
        {
            this.createOrUpdateUserService = createOrUpdateUserService;
            this.viewModelToDtoFactory = viewModelToDtoFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task CreateOrUpdateUser(UserViewModel user)
        {
            await createOrUpdateUserService.CreateOrUpdateUser(viewModelToDtoFactory.TransformUserViewModelToDtoUserModel(user));
        }
    }
}
