using RackManager.Models;

namespace RackManager.Services.SnakeCreators
{
    public interface ISnakeCreator
    {
        public Task CreateSnake(SnakeModel snake);
    }
}
