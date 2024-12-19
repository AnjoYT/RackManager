using RackManager.Entities;
using RackManager.Models;

namespace RackManager.Utils
{
    public static class UpdateDTOExtension
    {
        public static void UpdateDTO(this SnakeDTO snakeDTO, SnakeModel snake)
        {
            snakeDTO.Id = snake.Id;
            snakeDTO.Image = snake.Image;
            snakeDTO.Name = snake.Name;
            snakeDTO.DateOfBirth = snake.DateOfBirth;
            snakeDTO.Weight = snake.Weight;
            snakeDTO.Sex = snake.Sex;
            snakeDTO.Subspecies = snake.Subspecies;
            snakeDTO.IsVenomous = snake.IsVenomous;
            snakeDTO.LastFeedingDate = snake.LastFeedingDate;
            snakeDTO.WaterReplacementDate = snake.WaterReplacementDate;
            snakeDTO.Temp = new TempDTO()
            {
                MinValue = snake.Temp.MinValue,
                MaxValue = snake.Temp.MaxValue
            };
            snakeDTO.Humidity = new HumidityDTO()
            {
                MinValue = snake.Humidity.MinValue,
                MaxValue = snake.Humidity.MaxValue
            };
            snakeDTO.Enclousure = new EnclousureDTO()
            {
                Width = snake.Enclosure.Width,
                Height = snake.Enclosure.Height,
                Length = snake.Enclosure.Length
            };
            snakeDTO.ArduinoIdentifier = snake.ArduinoIdentifier;
            snakeDTO.AddInformation = snake.AddInformation;
        }
    }
}
