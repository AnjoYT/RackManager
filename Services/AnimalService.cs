using RackManager.CustomControls;
using RackManager.Models;
using RackManager.Services.Modifiers;
using RackManager.Services.SnakeCreators;
using RackManager.Services.SnakeDeletes;
using RackManager.Services.SnakeProviders;
using RackManager.Utils;
using System.Collections.ObjectModel;

namespace RackManager.Services
{
    public class AnimalService
    {
        public ObservableCollection<BaseCardModel> Cards { get; private set; }
        private readonly ISnakeProvider _snakeProvider;
        private readonly ISnakeCreator _snakeCreator;
        private readonly ISnakeModifier _snakeModifier;
        private readonly ISnakeDelete _snakeDelete;
        public AnimalService(ISnakeCreator snakeCreator, ISnakeProvider snakeProvider, ISnakeDelete snakeDelete, ISnakeModifier snakeModifier)
        {
            _snakeDelete = snakeDelete;
            _snakeProvider = snakeProvider;
            _snakeCreator = snakeCreator;
            _snakeModifier = snakeModifier;
            Cards = new ObservableCollection<BaseCardModel>();
        }
        public void AddAnimal(BaseCardModel animal)
        {
            _snakeCreator.CreateSnake((SnakeModel)animal);
            UpdateListAnimals();
        }
        public async Task UpdateListAnimals()
        {
            IEnumerable<BaseCardModel> snakes = await _snakeProvider.RetrieveAllSnakes();
            Cards.Clear();
            Cards.ToCollection(snakes);
            Cards.Add(new BaseCardModel()
            {
                Image = PathFinder.RelativePath(@"Assets\Images\", "AddAnimal.png"),
                IsAddCard = true
            });
        }
        public void DeleteAnimal(SnakeModel snake)
        {
            _snakeDelete.DeleteSnake(snake);
            UpdateListAnimals();
        }
        public void ModifyAnimal(SnakeModel snake)
        {
            _snakeModifier.ModifySnake(snake);
            UpdateListAnimals();
        }


    }
}
