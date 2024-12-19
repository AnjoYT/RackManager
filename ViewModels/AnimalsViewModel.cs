using ArduinoCOMLibrary;
using RackManager.Commands;
using RackManager.Models;
using RackManager.Services;
using RackManager.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RackManager.ViewModels
{
    public class AnimalsViewModel : ViewModelBase
    {
        private readonly AnimalService _animalService;
        private readonly ArduinoConnectorFactory _connectorFactory;
        private NavigationStore _store;
        public ICommand AddAnimalCommand { get; set; }
        public ICommand ViewAnimalCommand { get; set; }
        public ObservableCollection<BaseCardModel> Cards => _animalService.Cards;
        public AnimalsViewModel(NavigationStore store, AnimalService animalService, ArduinoConnectorFactory connectorFactory)
        {
            _animalService = animalService;
            _connectorFactory = connectorFactory;
            animalService.UpdateListAnimals();
            AddAnimalCommand = new NavigationCommand<AddAnimalViewModel>(store, () => new AddAnimalViewModel(store, this._animalService, connectorFactory));
            SetNavigationStore(store);
        }
        public void SetNavigationStore(NavigationStore store)
        {
            _store = store;

            ViewAnimalCommand = new RelayCommand<SnakeModel>((animal) => NavigateToViewAnimal(animal));
        }
        public void NavigateToViewAnimal(SnakeModel snake)
        {
            _store.CurrentViewModel = new ViewAnimalViewModel(_store, _animalService, snake, _connectorFactory);
        }
    }
}
