using Microsoft.EntityFrameworkCore;
using RackManager.Data;
using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Services.SnakeProvider
{
    public class SnakeProvider : ISnakeProvider
    {
        private readonly ApplicationDbContext dbContext;

        public SnakeProvider(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<SnakeModel>> RetrieveAllSnakes()
        {
            IEnumerable<SnakeDTO> snakeDTOs = await dbContext.Snakes.ToListAsync();
            IEnumerable<SnakeModel> snakeModels;
            return snakeDTOs.Select(snake => Convert(snake));
        }
        public SnakeModel Convert(SnakeDTO snake)
        {
            SnakeModel model = new SnakeModel()
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
                Temp = new TempModel()
                {
                    MinValue = snake.Temp.MinValue,
                    MaxValue = snake.Temp.MaxValue
                },
                Humidity = new HumidityModel()
                {
                    MinValue = snake.Humidity.MinValue,
                    MaxValue = snake.Humidity.MaxValue
                },
                Enclousure = new EnclousureModel()
                {
                    Width = snake.Enclousure.Width,
                    Height = snake.Enclousure.Height,
                    Length = snake.Enclousure.Length,
                }
            };
            return model;
        }
    }
}
