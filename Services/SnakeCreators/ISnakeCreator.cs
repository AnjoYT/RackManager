using RackManager.Models;

namespace RackManager.Services.SnakeCreators
{
    interface ISnakeCreator
    {
        public Task CreateSnake(SnakeModel snake);
    }
}
