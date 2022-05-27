using BusinessLogicLayer.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface ICreateOrUpdateUserService
    {
        public Task CreateOrUpdateUser(DtoUserModel user);
    }
}
