using ArduinoCOMLibrary;
using RackManager.Services;
using RackManager.Stores;

namespace RackManager.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private NavigationStore _store;
        public NavigationViewModel NavigationViewModel { get; private set; }
        public ViewModelBase CurrentView => _store.CurrentViewModel;
        public MainViewModel(NavigationStore store, AnimalService animalService, ArduinoConnectorFactory connectorFactory, EnclosureService enclosureService)
        {
            _store = store;
            NavigationViewModel = new NavigationViewModel(_store, animalService, connectorFactory, enclosureService);
            _store.CurrentViewChanged += OnCurrentViewChange;
        }
        public void OnCurrentViewChange()
        {
            OnPropertyChanged(nameof(CurrentView));
        }
    }
}
