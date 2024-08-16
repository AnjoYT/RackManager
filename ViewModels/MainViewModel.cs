using RackManager.Stores;

namespace RackManager.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private NavigationStore navigationStore;
        public ViewModelBase CurrentView => navigationStore.CurrentViewModel;
        public MainViewModel(NavigationStore navigationStore)
        {
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewChanged += OnCurrentViewChange;
        }
        public void OnCurrentViewChange()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
