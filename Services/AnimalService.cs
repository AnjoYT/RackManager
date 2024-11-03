using RackManager.CustomControls;
using RackManager.Data;
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
            Cards = new ObservableCollection<BaseCardModel>();
        }
        public async void AddAnimal(MainAnimalModel animal)
        {
            Cards.Add(animal);
        }
        public async void UpdateAnimals()
        {
            IEnumerable<BaseCardModel> snakes = await snakeProvider.RetrieveAllSnakes();
            Cards.Clear();
            Cards.ToCollection(snakes);
            Cards.Add(new BaseCardModel(PathFinder.RelativePath(@"Assets\Images\", "AddAnimal.png"), true));
        }

    }
}
