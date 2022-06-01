using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.DbContexts;
using DataAccessLayer.Models;
using ITHootUniversity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ITHootUniversity.Controllers
{
    public class HomeController : Controller
    {

        private readonly SignInManager<UserModel> signInManager;
        private readonly IResultBuilderService resultBuilderService;
        public HomeController(SignInManager<UserModel> signInManager, IResultBuilderService resultBuilderService)
        {
            this.signInManager = signInManager;
            this.resultBuilderService = resultBuilderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SignIn(SignInUserViewModel model)
        {
            if (ModelState.IsValid) 
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return new JsonResult(resultBuilderService.ToModelForJsonResult("ok", ""));
                }
                else
                {
                    return new JsonResult(resultBuilderService.ToModelForJsonResult("", $"Incorrect login and/or password"));
                } 
            }

            return Json(new { ResultAction = "", ResultMessage = $"The parameters obtained did not pass validation" });
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}