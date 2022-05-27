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


        public async Task<DtoUserModel> GetUserById(string id)
        {
            return modelToDtoFactory.TransformUserModelToDtoUserModel(await usersRepository.GetUserById(id));
        }

        public async Task<DtoUserModel> GetUserByLogin(string userName)
        {
            return modelToDtoFactory.TransformUserModelToDtoUserModel(await usersRepository.GetUserByUserName(userName));
        }

        public async Task<List<DtoUserModel>> GetAllUsers()
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
