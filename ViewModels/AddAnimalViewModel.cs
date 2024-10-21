using RackManager.Commands;
using RackManager.Enums;
using RackManager.Exceptions;
using RackManager.Models;
using RackManager.Services;
using RackManager.Stores;
using System.Collections.ObjectModel;

namespace RackManager.ViewModels
{
    partial class AddAnimalViewModel : ViewModelBase
    {
        private readonly ImageService imageService;

        private AnimalService animalService;
        public AddAnimalViewModel(NavigationStore store, AnimalService animalService)
        {
            this.animalService = animalService;
            this.imageService = new ImageService();

            SexComboBox = new ObservableCollection<SexEnum>(Enum.GetValues(typeof(SexEnum)) as SexEnum[]);

            CancelCommand = new NavigationCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService));

            CreateCommand = new CreateCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService), AddAnimal);

            GetImageCommand = new GetImageCommand(this.imageService, this);
        }

        private void AddAnimal()
        {
            tempModel = new TempModel(AnimalMinTemp, AnimalMaxTemp);

            humidityModel = new HumidityModel(AnimalMinHum, AnimalMaxHum);
            if (tempModel.Conflict())
            {
                throw new ValueConflictException();
            }
            else if (humidityModel.Conflict())
            {
                throw new ValueConflictException();
            }
            SnakeModel animal = new SnakeModel()
            {
                Image = this.Image,
                Name = AnimalName,
                DateOfBirth = AnimalBirthDate,
                Weight = AnimalWeight,
                Sex = SelectedSex,
                Subspecies = AnimalSubspecies,
                IsVenomous = AnimalVenomous,
                LastFeedingDate = AnimalFeedingDate,
                WaterReplacementDate = waterReplacementDate,
                Length = AnimalLength,
            };
            animalService.AddAnimal(animal);
        }
    }
}
