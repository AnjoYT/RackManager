using RackManager.Data;
using RackManager.Models;
using RackManager.Utils;
using System.Diagnostics;

namespace RackManager.Services.Modifiers
{
    public class SnakeModifier : ISnakeModifier
    {
        IDbContextFactory _dbContextFactory;
        public SnakeModifier(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void ModifySnake(SnakeModel snake)
        {
            using (ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    var snakeDTO = dbContext.Snakes.FirstOrDefault(x => x.Id == snake.Id) ?? throw new ArgumentNullException();
                    UpdateDTOExtension.UpdateDTO(snakeDTO, snake);
                    dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error appeared while modifing entity: {ex.Message}");
                }
            }
        }

    }
}
