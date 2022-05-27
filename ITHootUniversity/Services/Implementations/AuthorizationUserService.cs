using DataAccessLayer.Models;
using ITHootUniversity.Models;
using ITHootUniversity.Services.Interfaces;
using ITHootUniversity.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ITHootUniversity.Services.Implementations
{
    public class AuthorizationUserService : IAuthorizationUserService
    {
        private readonly SignInManager<UserModel> signInManager;
        private readonly IResultBuilderService resultBuilderService;
        public AuthorizationUserService(SignInManager<UserModel> signInManager, IResultBuilderService resultBuilderService)
        {
            this.signInManager = signInManager;
            this.resultBuilderService = resultBuilderService;
        }

        public async Task<ModelForJsonResult> SignIn(SignInUserViewModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                return resultBuilderService.ToModelForJsonResult("ok", "");
            }
            else
            {
                return resultBuilderService.ToModelForJsonResult("", $"Incorrect login and/or password");
            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
