using BusinessLogicLayer.DtoModels;
using ITHootUniversity.ViewModels;
using ITHootUniversity.WebAppFactories.Interfaces;

namespace ITHootUniversity.WebAppFactories.Implementations
{
    public class ViewModelToDtoFactory : IViewModelToDtoFactory
    {
        public DtoUserModel TransformUserViewModelToDtoUserModel(UserViewModel user)
        {
            DtoUserModel dtoUser = new DtoUserModel
            {
                UserName = user.UserName,
                Password = user.Password,
                Role = user.Role,
            };

            return dtoUser;
        }
    }
}
