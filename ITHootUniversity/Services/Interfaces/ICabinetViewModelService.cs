using ITHootUniversity.ViewModels;

namespace ITHootUniversity.Services.Interfaces
{
    public interface ICabinetViewModelService
    {
        public Task<CabinetViewModel> CreateAndFillCabinetViewModel();
    }
}
