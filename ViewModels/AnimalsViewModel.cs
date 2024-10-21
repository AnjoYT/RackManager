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
        private readonly AnimalService animalService;
        public ICommand AddAnimalCommand { get; set; }
        public ObservableCollection<BaseCardModel> Cards => animalService.Cards;
        public AnimalsViewModel(NavigationStore store, AnimalService animalService)
        {
            this.animalService = animalService;
            AddAnimalCommand = new NavigationCommand<AddAnimalViewModel>(store, () => new AddAnimalViewModel(store, this.animalService));
        }
    }
}
