using ArduinoCOMLibrary;
using RackManager.Commands;
using RackManager.Services;
using RackManager.Stores;
using System.Windows.Input;
namespace RackManager.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        public ICommand AnimalsCommand { get; set; }
        public ICommand EnclosureCommand { get; set; }
        public NavigationViewModel(NavigationStore store, AnimalService animalService, ArduinoConnectorFactory arduinoConnectorFactory, EnclosureService enclosureService)
        {
            AnimalsCommand = new NavigationCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService, arduinoConnectorFactory));
            EnclosureCommand = new NavigationCommand<EnclosuresViewModel>(store, () => new EnclosuresViewModel(store, enclosureService));
        }
    }
}
