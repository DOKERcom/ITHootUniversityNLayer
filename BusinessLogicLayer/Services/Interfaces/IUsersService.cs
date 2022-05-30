using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<UserModel> GetUserById(string id);

        public Task<UserModel> GetUserByLogin(string userName);

        public Task<List<UserModel>> GetAllUsers();

        public Task<List<DtoUserModel>> GetAllDtoUsers();

        public Task<IdentityResult> UpdateUser(UserModel user);

        public Task<IdentityResult> CreateUser(UserModel user, string password);

        public Task<IdentityResult> DeleteUser(UserModel user);

    }
}
