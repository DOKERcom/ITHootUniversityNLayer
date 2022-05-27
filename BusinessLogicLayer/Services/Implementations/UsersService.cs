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
using BusinessLogicLayer.ModelToDtoHandlers.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly ITransformatorModelToDto TransformatorModelToDto;
        public UsersService(IUsersRepository usersRepository, ITransformatorModelToDto TransformatorModelToDto)
        {
            this.usersRepository = usersRepository;
            this.TransformatorModelToDto = TransformatorModelToDto;
        }


        public async Task<DtoUserModel> GetUserById(string id)
        {
            return TransformatorModelToDto.TransformUserModelToDtoUserModel(await usersRepository.GetUserById(id));
        }

        public async Task<DtoUserModel> GetUserByLogin(string userName)
        {
            return TransformatorModelToDto.TransformUserModelToDtoUserModel(await usersRepository.GetUserByUserName(userName));
        }

        public async Task<List<DtoUserModel>> GetAllUsers()
        {
            return TransformatorModelToDto.TransformUserModelToDtoUserModel(await usersRepository.GetAllUsers());
        }

        public async Task<IdentityResult> UpdateUser(UserModel user)
        {
            return await usersRepository.UpdateUser(user);
        }

        public async Task<IdentityResult> CreateUser(UserModel user)
        {
            return await usersRepository.CreateUser(user);
        }

        public async Task<IdentityResult> DeleteUser(UserModel user)
        {
            return await usersRepository.DeleteUser(user);
        }
    }
}
