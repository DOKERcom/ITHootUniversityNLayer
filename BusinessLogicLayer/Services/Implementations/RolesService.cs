using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implementations
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository rolesRepository;
        public RolesService(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public async Task<IList<string>> GetUserRoles(UserModel user)
        {
            return await rolesRepository.GetUserRoles(user);
        }

        public async Task<IdentityResult> AddUserToRole(UserModel user, string role)
        {
            return await rolesRepository.AddUserToRole(user, role);
        }

        public async Task<IdentityResult> RemoveUserFromRole(UserModel user, string role)
        {
            return await rolesRepository.RemoveUserFromRole(user, role);
        }

        public async Task<bool> IsUserInRole(UserModel user, string role)
        {
            return await rolesRepository.IsUserInRole(user, role);
        }
    }
}
