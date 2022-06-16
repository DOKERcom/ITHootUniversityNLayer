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
        private readonly IUsersService usersService;
        private readonly ILessonsService lessonsService;
        private readonly IUsersInLessonsService usersInLessonsService;
        private readonly IViewModelToDtoFactory viewModelToDtoFactory;
        private readonly ICabinetViewModelFactory cabinetViewModelService;
        public CabinetController(IUsersService usersService, IViewModelToDtoFactory viewModelToDtoFactory, ICabinetViewModelFactory cabinetViewModelService, ILessonsService lessonsService, IUsersInLessonsService usersInLessonsService)
        {
            this.usersService = usersService;
            this.viewModelToDtoFactory = viewModelToDtoFactory;
            this.cabinetViewModelService = cabinetViewModelService;
            this.lessonsService = lessonsService;
            this.usersInLessonsService = usersInLessonsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await cabinetViewModelService.CreateAndFillCabinetViewModel());
        }

        [HttpPost]
        public async Task<JsonResult> GetJsonCabinetViewModel()
        {
            return new JsonResult(await cabinetViewModelService.CreateAndFillCabinetViewModel());
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrUpdateUser(CRUDUserViewModel user)
        {
           return new JsonResult(await usersService.CreateOrUpdateUser(viewModelToDtoFactory.TransformCRUDUserViewModelToDtoUserModel(user)));
        }

        [HttpPost]
        public async Task<JsonResult> DeleteUser(string userName)
        {
            return new JsonResult(await usersService.DeleteUser(userName));
        }

        [HttpPost]
        public async Task<JsonResult> CreateLesson(string lessonName, string userName)
        {
            return new JsonResult(await lessonsService.CreateLesson(lessonName, userName));
        }

        [HttpPost]
        public async Task<JsonResult> DeleteLesson(string lessonName)
        {
            return new JsonResult(await lessonsService.DeleteLesson(lessonName));
        }

        [HttpPost]
        public async Task<JsonResult> AddUserToLesson(string lessonName, string userName)
        {
            return new JsonResult(await usersInLessonsService.AddUserToLesson(lessonName, userName));
        }

        [HttpPost]
        public async Task<JsonResult> DelUserFromLesson(string lessonName, string userName)
        {
            return new JsonResult(await usersInLessonsService.DelUserFromLesson(lessonName, userName));
        }

        [HttpPost]
        public async Task<JsonResult> JoinToLesson(string lessonName)
        {
            return new JsonResult(await usersInLessonsService.JoinToLesson(lessonName, User.Identity.Name));
        }

        [HttpPost]
        public async Task<JsonResult> LeftFromLesson(string lessonName)
        {
            return new JsonResult(await usersInLessonsService.LeftFromLesson(lessonName, User.Identity.Name));
        }
    }
}
