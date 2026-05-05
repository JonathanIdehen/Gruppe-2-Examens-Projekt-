using MaxiZoo.Stores;
using MaxiZoo.ViewModels;

namespace MaxiZoo.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;

        public NavigationStore NavigationStore => _navigationStore;

        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void NavigateTo(BaseViewModel viewModel)
        {
            _navigationStore.CurrentViewModel = viewModel;
        }
    }
}
