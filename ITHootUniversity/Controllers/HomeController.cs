using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using ITHootUniversity.Services.Interfaces;
using ITHootUniversity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ITHootUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthorizationUserService authorizationUserService;
        public HomeController(IAuthorizationUserService authorizationUserService)
        {
            this.authorizationUserService = authorizationUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SignIn(SignInUserViewModel model)
        {
            if (ModelState.IsValid)
                return new JsonResult(await authorizationUserService.SignIn(model));

            return Json(new { ResultAction = "", ResultMessage = $"The parameters obtained did not pass validation" });
        }

        public async Task<IActionResult> Logout()
        {
            await authorizationUserService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}