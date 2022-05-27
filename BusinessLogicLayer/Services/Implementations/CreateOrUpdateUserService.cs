using BusinessLogicLayer.BusinessFactories.Interfaces;
using BusinessLogicLayer.DtoModels;
using BusinessLogicLayer.Services.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class CreateOrUpdateUserService : ICreateOrUpdateUserService
    {
        private readonly IUsersService usersService;
        private readonly IDtoToModelFactory dtoToModelFactory;
        public CreateOrUpdateUserService(IUsersService usersService, IDtoToModelFactory dtoToModelFactory)
        {
            this.usersService = usersService;
            this.dtoToModelFactory = dtoToModelFactory;
        }
        public async Task CreateOrUpdateUser(DtoUserModel user)
        {
            DtoUserModel userR = await usersService.GetUserByLogin(user.UserName);
            if (userR == null)
            {
               await usersService.CreateUser(dtoToModelFactory.TransformDtoUserModelToUserModel(user), user.Password);
            }
            else
            {

            }
        }
    }
}
