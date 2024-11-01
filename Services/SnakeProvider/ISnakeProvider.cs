using RackManager.Models;

namespace RackManager.Services.SnakeProvider
{
    interface ISnakeProvider
    {
        Task<IEnumerable<SnakeModel>> RetrieveAllSnakes();
    }
}
