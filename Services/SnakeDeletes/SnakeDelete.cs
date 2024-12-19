using RackManager.Data;
using RackManager.Entities;
using RackManager.Models;
using System.Diagnostics;

namespace RackManager.Services.SnakeDeletes
{
    public class SnakeDelete : ISnakeDelete
    {
        private readonly IDbContextFactory _dbContextFactory;
        public SnakeDelete(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void DeleteSnake(SnakeModel snake)
        {
            using (ApplicationDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                var entity = dbContext.Snakes.FirstOrDefault(x => x.Id == snake.Id) ?? throw new ArgumentNullException();
                dbContext.Snakes.Remove(entity);
                dbContext.SaveChanges();
                Debug.WriteLine("Task completed");
            }
        }
        public SnakeDTO ToSnakeDTO(SnakeModel snake) => new SnakeDTO()
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
                Width = snake.Enclosure.Width,
                Height = snake.Enclosure.Height,
                Length = snake.Enclosure.Length
            },
            ArduinoIdentifier = snake.ArduinoIdentifier,
            AddInformation = snake.AddInformation
        };
    }
}
