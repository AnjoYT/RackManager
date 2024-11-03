using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Services.SnakeProvide
{
    interface ISnakeProvider
    {
        Task<IEnumerable<SnakeModel>> RetrieveAllSnakes();
        SnakeModel ToSnakeModel(SnakeDTO snake);
    }
}
