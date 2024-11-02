using RackManager.CustomControls;
using RackManager.Data;
using RackManager.Enums;
using RackManager.Models;
using RackManager.Services.SnakeProvide;
using RackManager.Utils;
using System.Collections.ObjectModel;

namespace RackManager.Services
{
    public class AnimalService
    {
        public ObservableCollection<BaseCardModel> Cards { get; private set; }
        public SnakeProvider snakeProvider;
        public AnimalService(ApplicationDbContext dbContext)
        {
            snakeProvider = new SnakeProvider(dbContext);
            Cards = new ObservableCollection<BaseCardModel>() {
                 new BaseCardModel(PathFinder.RelativePath(@"Assets\Images\", "AddAnimal.png"),true)
                 ,
                new SnakeModel(
                                PathFinder.RelativePath(@"Assets\Images\", "E:\\REPOS\\PLIKI_TESTOWE\\testImage.png"),
                                false,
                                "John",
                                DateTime.Now,
                                13,
                                SexEnum.Male,
                                "Corn Snake",
                                false,
                                DateTime.Now,
                                DateTime.Now,
                                13,
                                new TempModel(0,1),
                                new HumidityModel(0,1),
                                new EnclousureModel(1,1,1)),
                new SnakeModel(PathFinder.RelativePath(@"Assets\Images\", "E:\\REPOS\\PLIKI_TESTOWE\\testImage.png"),
                                false,
                                "Dave",
                                DateTime.Now,
                                13,SexEnum.Female,
                                "Corn Snake",
                                false,
                                DateTime.Now,
                                DateTime.Now,
                                13,
                                new TempModel(0,1),
                                new HumidityModel(0,1),
                                new EnclousureModel(1,1,1)),
                new SnakeModel(PathFinder.RelativePath(@"Assets\Images\", "E:\\REPOS\\PLIKI_TESTOWE\\testImage.png"),
                                false,
                                "George",
                                DateTime.Now,
                                13,SexEnum.Female,
                                "Corn Snake",
                                false,
                                DateTime.Now,
                                DateTime.Now,
                                13,
                                new TempModel(0,1),
                                new HumidityModel(0,1),
                                new EnclousureModel(1,1,1)),
            };
        }
        public async void AddAnimal(MainAnimalModel animal)
        {
            Cards.Add(animal);
        }
        public async void UpdateAnimals()
        {
            IEnumerable<BaseCardModel> snakes = await snakeProvider.RetrieveAllSnakes();

            Cards.ToCollection(snakes);
        }

    }
}
