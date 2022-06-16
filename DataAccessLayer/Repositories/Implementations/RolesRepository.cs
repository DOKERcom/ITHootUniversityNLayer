using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Implementations
{
    public class RolesRepository : IRolesRepository
    {
        private readonly UserManager<UserModel> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public RolesRepository(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IList<string> GetAllRoles()
        {
            return roleManager.Roles.Select(r => r.Name).ToList();
        }

        public async Task<IList<string>> GetUserRoles(UserModel user)
        {
            return await userManager.GetRolesAsync(user);
        }

        public async Task<IdentityResult> AddUserToRole(UserModel user, string role)
        {
            return await userManager.AddToRoleAsync(user, role);
        }

        public async Task<IdentityResult> RemoveUserFromRole(UserModel user, string role)
        {
            return await userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<bool> IsUserInRole(UserModel user, string role)
        {
            return await userManager.IsInRoleAsync(user, role);
        }
    }
}
