using BusinessLogicLayer.DtoModels;
using ITHootUniversity.ViewModels;

namespace ITHootUniversity.WebAppFactories.Interfaces
{
    public interface IViewModelToDtoFactory
    {
        public DtoUserModel TransformCRUDUserViewModelToDtoUserModel(CRUDUserViewModel user);
    }
}
