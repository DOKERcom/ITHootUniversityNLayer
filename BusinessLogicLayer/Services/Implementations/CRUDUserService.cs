using BusinessLogicLayer.BusinessFactories.Interfaces;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using ITHootUniversity.Models;
using ITHootUniversity.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Services.Implementations
{
    public class CRUDUserService : ICRUDUserService
    {
        private readonly IUsersService usersService;
        private readonly IDtoToModelFactory dtoToModelFactory;
        private readonly IResultBuilderService resultBuilderService;
        private readonly IRolesService rolesService;
        private readonly UserManager<UserModel> userManager;
        public CRUDUserService(IUsersService usersService, IDtoToModelFactory dtoToModelFactory, IResultBuilderService resultBuilderService, UserManager<UserModel> userManager, IRolesService rolesService)
        {
            this.usersService = usersService;
            this.dtoToModelFactory = dtoToModelFactory;
            this.resultBuilderService = resultBuilderService;
            this.userManager = userManager;
            this.rolesService = rolesService;
        }
        public async Task<ModelForJsonResult> CreateOrUpdateUser(DtoUserModel user)
        {
            UserModel userR = await usersService.GetUserByLogin(user.UserName);
            if (userR == null)
            {
                if((await usersService.CreateUser(dtoToModelFactory.TransformDtoUserModelToUserModel(user), user.Password)).Succeeded)

                    return resultBuilderService.ToModelForJsonResult("", $"You have successfully created a user ({user.UserName})!");
            }
            else
            {
                if (!string.IsNullOrEmpty(user.Password))
                    userR.PasswordHash = userManager.PasswordHasher.HashPassword(userR, user.Password);

                if (!await rolesService.IsUserInRole(userR, user.Role))
                {
                    foreach (var role in await rolesService.GetUserRoles(userR))
                    {
                        await rolesService.RemoveUserFromRole(userR, role);
                    }
                    await rolesService.AddUserToRole(userR, user.Role);
                }

                if ((await usersService.UpdateUser(userR)).Succeeded)

                    return resultBuilderService.ToModelForJsonResult("", $"You have successfully updated a user ({user.UserName})!");
            }
            return resultBuilderService.ToModelForJsonResult("", "An unexpected error occurred");
        }

        public async Task<ModelForJsonResult> DeleteUser(string userName)
        {
            if ((await usersService.GetUserByLogin(userName)) != null)
            {
                await usersService.DeleteUser(await usersService.GetUserByLogin(userName));
                return resultBuilderService.ToModelForJsonResult("", $"You have successfully deleted a user ({userName})!");
            }
            else
            {
                return resultBuilderService.ToModelForJsonResult("", $"User ({userName}) not found!");
            }
        }
    }
}
