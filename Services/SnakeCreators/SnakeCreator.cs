using RackManager.Data;
using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Services.SnakeCreators
{
    class SnakeCreator : ISnakeCreator
    {
        private readonly ApplicationDbContext dbContext;
        public SnakeCreator(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateSnake(SnakeModel snake)
        {
            dbContext.Snakes.Add(ToSnakeDTO(snake));
            await dbContext.SaveChangesAsync();
        }

        public SnakeDTO ToSnakeDTO(SnakeModel snake)
        {
            return new SnakeDTO()
            {
                Image = snake.Image,
                Name = snake.Name,
                DateOfBirth = snake.DateOfBirth,
                Weight = snake.Weight,
                Sex = snake.Sex,
                Subspecies = snake.Subspecies,
                IsVenomous = snake.IsVenomous,
                LastFeedingDate = snake.LastFeedingDate,
                WaterReplacementDate = snake.WaterReplacementDate,
                Length = snake.Length,
                Temp = new TempDTO()
                {
                    MinValue = snake.Temp.MinValue,
                    MaxValue = snake.Temp.MaxValue
                },
                Humidity = new HumidityDTO()
                {
                    MinValue = snake.Humidity.MinValue,
                    MaxValue = snake.Humidity.MaxValue
                },
                Enclousure = new EnclousureDTO()
                {
                    Width = snake.Enclousure.Width,
                    Height = snake.Enclousure.Height,
                    Length = snake.Enclousure.Length
                }
            };

        }
    }

}

