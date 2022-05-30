using BusinessLogicLayer.DtoModels;
using ITHootUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICRUDUserService
    {
        public Task<ModelForJsonResult> CreateOrUpdateUser(DtoUserModel user);

        public Task<ModelForJsonResult> DeleteUser(string userName);
    }
}
