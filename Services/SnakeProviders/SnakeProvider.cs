using Microsoft.EntityFrameworkCore;
using RackManager.Data;
using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Services.SnakeProviders
{
    public class SnakeProvider : ISnakeProvider
    {
        private readonly IDbContextFactory _dbContextFactory;

        public SnakeProvider(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<SnakeModel>> RetrieveAllSnakes()
        {
            using (ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<SnakeDTO> snakeDTOs = await dbContext.Snakes
                    .Include(item => item.Temp)
                    .Include(item => item.Humidity)
                    .Include(item => item.Enclousure)
                    .ToListAsync();

                return snakeDTOs.Select(snake => ToSnakeModel(snake));
            }
        }
        public SnakeModel ToSnakeModel(SnakeDTO snake)
        {
            return new SnakeModel()
            {
                Id = snake.Id,
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
                Enclosure = new EnclosureModel()
                {
                    Width = snake.Enclousure.Width,
                    Height = snake.Enclousure.Height,
                    Length = snake.Enclousure.Length
                },
                ArduinoIdentifier = snake.ArduinoIdentifier,
                AddInformation = snake.AddInformation
            };
        }
    }
}
