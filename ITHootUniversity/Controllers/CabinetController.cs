using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Services.Implementations;
using BusinessLogicLayer.Services.Interfaces;
using ITHootUniversity.Services.Interfaces;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITHootUniversity.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        private readonly ICRUDUserService CRUDUserService;
        private readonly IViewModelToDtoFactory viewModelToDtoFactory;
        private readonly ICabinetViewModelService cabinetViewModelService;
        public CabinetController(ICRUDUserService CRUDUserService, IViewModelToDtoFactory viewModelToDtoFactory, ICabinetViewModelService cabinetViewModelService)
        {
            this.CRUDUserService = CRUDUserService;
            this.viewModelToDtoFactory = viewModelToDtoFactory;
            this.cabinetViewModelService = cabinetViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await cabinetViewModelService.CreateAndFillCabinetViewModel());
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrUpdateUser(CRUDUserViewModel user)
        {
           return new JsonResult(await CRUDUserService.CreateOrUpdateUser(viewModelToDtoFactory.TransformCRUDUserViewModelToDtoUserModel(user)));
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUser(string userName)
        {
            return new JsonResult(await CRUDUserService.DeleteUser(userName));
        }
    }
}
