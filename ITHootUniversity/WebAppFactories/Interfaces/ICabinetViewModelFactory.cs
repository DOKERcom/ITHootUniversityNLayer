using ITHootUniversity.ViewModels;

namespace ITHootUniversity.WebAppFactories.Interfaces
{
    public interface ICabinetViewModelFactory
    {
        public Task<CabinetViewModel> CreateAndFillCabinetViewModel();
    }
}
