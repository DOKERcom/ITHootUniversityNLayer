using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<UserModel> GetUserById(string id);

        public Task<UserModel> GetUserByUserName(string userName);

        public Task<List<UserModel>> GetAllUsers();

        public Task<IdentityResult> UpdateUser(UserModel user);

        public Task<IdentityResult> CreateUser(UserModel user, string password);

        public Task<IdentityResult> DeleteUser(UserModel user);
    }
}
