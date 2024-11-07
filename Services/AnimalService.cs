using RackManager.CustomControls;
using RackManager.Models;
using RackManager.Services.SnakeCreators;
using RackManager.Services.SnakeProviders;
using RackManager.Utils;
using System.Collections.ObjectModel;

namespace RackManager.Services
{
    public class AnimalService
    {
        public ObservableCollection<BaseCardModel> Cards { get; private set; }
        private ISnakeProvider _snakeProvider;
        private ISnakeCreator _snakeCreator;
        public AnimalService(ISnakeCreator snakeCreator, ISnakeProvider snakeProvider)
        {
            _snakeProvider = snakeProvider;
            _snakeCreator = snakeCreator;
            Cards = new ObservableCollection<BaseCardModel>();
        }
        public void AddAnimal(BaseCardModel animal)
        {
            _snakeCreator.CreateSnake((SnakeModel)animal);
            UpdateAnimals();
        }
        public async void UpdateAnimals()
        {
            IEnumerable<BaseCardModel> snakes = await _snakeProvider.RetrieveAllSnakes();
            Cards.Clear();
            Cards.ToCollection(snakes);
            Cards.Add(new BaseCardModel(PathFinder.RelativePath(@"Assets\Images\", "AddAnimal.png"), true));
        }

    }
}
