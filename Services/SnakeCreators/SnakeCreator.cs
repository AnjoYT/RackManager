using RackManager.Data;
using RackManager.Entities;
using RackManager.Models;
using System.Diagnostics;

namespace RackManager.Services.SnakeCreators
{
    class SnakeCreator : ISnakeCreator
    {
        private readonly IDbContextFactory _dbContextFactory;
        public SnakeCreator(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateSnake(SnakeModel snake)
        {
            using (ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext())
            {

                dbContext.Snakes.Add(ToSnakeDTO(snake));
                await dbContext.SaveChangesAsync();
                Debug.WriteLine("Task completed");
            }
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

