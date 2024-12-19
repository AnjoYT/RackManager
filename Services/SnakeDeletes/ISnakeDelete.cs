using RackManager.Models;

namespace RackManager.Services.SnakeDeletes
{
    public interface ISnakeDelete
    {
        public void DeleteSnake(SnakeModel snake);
    }
}
