using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRolesService
    {
        public IList<string> GetAllRoles();

        public Task<IList<string>> GetUserRoles(UserModel user);

        public Task<IList<string>> GetUserRoles(string userName);

        public Task<IdentityResult> AddUserToRole(UserModel user, string role);

        public Task<IdentityResult> RemoveUserFromRole(UserModel user, string role);

        public Task<bool> IsUserInRole(UserModel user, string role);
    }
}
