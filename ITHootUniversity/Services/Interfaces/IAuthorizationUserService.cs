using ITHootUniversity.Models;
using ITHootUniversity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITHootUniversity.Services.Interfaces
{
    public interface IAuthorizationUserService
    {
        public Task<ModelForJsonResult> SignIn(SignInUserViewModel model);
        public Task Logout();
    }
}
