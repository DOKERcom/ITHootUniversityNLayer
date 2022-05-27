using ITHootUniversity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITHootUniversity.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateOrUpdateUser(CreateUserViewModel user)
        {
            return null;
           // return new JsonResult(await cabinetService.CreateOrUpdateUser(identificationService, usersService, HttpContext.Session.Id, HttpContext.Session.GetInt32("UserId"), user));
        }
    }
}
