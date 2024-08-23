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
        private AnimalService animalService;
        public AddAnimalViewModel(NavigationStore store, AnimalService animalService)
        {
            this.animalService = animalService;

            SexComboBox = new ObservableCollection<SexEnum>(Enum.GetValues(typeof(SexEnum)) as SexEnum[]);

            SelectedSex = SexEnum.Female;



            CancelCommand = new NavigationCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService));

            CreateCommand = new CreateCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService), AddAnimal);
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
                Image = "E:\\REPOS\\PLIKI_TESTOWE\\testImage.png",
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
