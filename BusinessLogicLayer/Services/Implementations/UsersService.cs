using DataAccessLayer.Models;
using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BusinessLogicLayer.Services.Interfaces;
using BusinessLogicLayer.BusinessFactories.Interfaces;
using ITHootUniversity.Models;

namespace BusinessLogicLayer.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;

        private readonly IModelToDtoFactory modelToDtoFactory;

        private readonly IDtoToModelFactory dtoToModelFactory;

        private readonly IResultBuilderService resultBuilderService;

        private readonly IRolesService rolesService;

        private readonly UserManager<UserModel> userManager;
        public UsersService(IUsersRepository usersRepository, IModelToDtoFactory modelToDtoFactory, IDtoToModelFactory dtoToModelFactory, IResultBuilderService resultBuilderService, UserManager<UserModel> userManager, IRolesService rolesService)
        {
            this.usersRepository = usersRepository;
            this.modelToDtoFactory = modelToDtoFactory;
            this.dtoToModelFactory = dtoToModelFactory;
            this.resultBuilderService = resultBuilderService;
            this.userManager = userManager;
            this.rolesService = rolesService;
        }


        public async Task<UserModel> GetUserById(string id)
        {
            return await usersRepository.GetUserById(id);
        }

        public async Task<UserModel> GetUserByLogin(string userName)
        {
            return await usersRepository.GetUserByUserName(userName);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await usersRepository.GetAllUsers();
        }

        public async Task<List<DtoUserModel>> GetAllDtoUsers()
        {
            return modelToDtoFactory.TransformUserModelToDtoUserModel(await usersRepository.GetAllUsers());
        }

        public async Task<IdentityResult> UpdateUser(UserModel user)
        {
            return await usersRepository.UpdateUser(user);
        }

        public async Task<IdentityResult> CreateUser(UserModel user, string password)
        {
            return await usersRepository.CreateUser(user, password);
        }

        public async Task<IdentityResult> DeleteUser(UserModel user)
        {
            return await usersRepository.DeleteUser(user);
        }

        public async Task<ModelForJsonResult> CreateOrUpdateUser(DtoUserModel user)
        {
            UserModel userR = await GetUserByLogin(user.UserName);
            if (userR == null)
            {
                if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Role))
                    return resultBuilderService.ToModelForJsonResult("400", $"All fields must be filled!");

                if ((await CreateUser(dtoToModelFactory.TransformDtoUserModelToUserModel(user), user.Password)).Succeeded)
                {
                    await rolesService.AddUserToRole(await GetUserByLogin(user.UserName), user.Role);
                    return resultBuilderService.ToModelForJsonResult("200", $"You have successfully created a user ({user.UserName})!");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(user.Password) && string.IsNullOrEmpty(user.Role))
                    return resultBuilderService.ToModelForJsonResult("400", $"Any fields must be filled!");

                if (!string.IsNullOrEmpty(user.Password))
                    userR.PasswordHash = userManager.PasswordHasher.HashPassword(userR, user.Password);

                if (!string.IsNullOrEmpty(user.Role) && !await rolesService.IsUserInRole(userR, user.Role))
                {
                    foreach (var role in await rolesService.GetUserRoles(userR))
                    {
                        await rolesService.RemoveUserFromRole(userR, role);
                    }
                    await rolesService.AddUserToRole(userR, user.Role);
                }

                if ((await UpdateUser(userR)).Succeeded)

                    return resultBuilderService.ToModelForJsonResult("200", $"You have successfully updated a user ({user.UserName})!");
            }
            return resultBuilderService.ToModelForJsonResult("500", "An unexpected error occurred");
        }

        public async Task<ModelForJsonResult> DeleteUser(string userName)
        {
            if ((await GetUserByLogin(userName)) != null)
            {
                await DeleteUser(await GetUserByLogin(userName));
                return resultBuilderService.ToModelForJsonResult("200", $"You have successfully deleted a user ({userName})!");
            }
            else
            {
                return resultBuilderService.ToModelForJsonResult("400", $"User ({userName}) not found!");
            }
        }
    }
}
