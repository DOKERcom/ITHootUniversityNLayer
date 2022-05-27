using DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<UserModel> userManager;
        public UsersRepository(UserManager<UserModel> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<UserModel> GetUserById(string id)
        {
            return await userManager.FindByIdAsync(id);
        }

        public async Task<UserModel> GetUserByUserName(string userName)
        {
            return await userManager.FindByNameAsync(userName);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await userManager.Users.ToListAsync();
        }

        public async Task<IdentityResult> UpdateUser(UserModel user)
        {
            return await userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> CreateUser(UserModel user, string password)
        {
            var result = await userManager.CreateAsync(user, password); //TODO не даёт ответ когда все норм и не создает пользователя
            return result;
        }

        public async Task<IdentityResult> DeleteUser(UserModel user)
        {
            return await userManager.DeleteAsync(user);
        }
    }
}
