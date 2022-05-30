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

namespace BusinessLogicLayer.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IModelToDtoFactory modelToDtoFactory;
        public UsersService(IUsersRepository usersRepository, IModelToDtoFactory modelToDtoFactory)
        {
            this.usersRepository = usersRepository;
            this.modelToDtoFactory = modelToDtoFactory;
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
    }
}
