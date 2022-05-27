using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.BusinessFactories.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.BusinessFactories.Implementations
{
    public class DtoToModelFactory : IDtoToModelFactory
    {
        //----------------DtoUserModel -> UserModel-----------------------
        public UserModel TransformDtoUserModelToUserModel(DtoUserModel user)
        {
            if(user == null)
                return null;

            UserModel User = new UserModel
            {
                UserName = user.UserName,
            };

            return User;
        }
    }
}
