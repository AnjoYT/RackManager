using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Services.SnakeProviders
{
    public interface ISnakeProvider
    {
        Task<IEnumerable<SnakeModel>> RetrieveAllSnakes();
        SnakeModel ToSnakeModel(SnakeDTO snake);
    }
}
