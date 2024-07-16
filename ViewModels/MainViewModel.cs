using RackManager.Stores;

namespace RackManager.ViewModels
{
    class MainViewModel
    {
        private NavigationStore navigationStore;
        public ViewModelBase CurrentView => navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
        }
    }
}
