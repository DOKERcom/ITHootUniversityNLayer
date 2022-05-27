using BusinessLogicLayer.DtoModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BusinessFactories.Interfaces
{
    public interface IDtoToModelFactory
    {
        public UserModel TransformDtoUserModelToUserModel(DtoUserModel user);
    }
}
