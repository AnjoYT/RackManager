using System.ComponentModel.DataAnnotations.Schema;
namespace RackManager.Entities
{
    [Table("Snakes")]
    public class SnakeEntity : AnimalEntity
    {
        public string Subspecies { get; set; }
        public bool IsVenomous { get; set; }
        public DateTime? LastFeedingDate { get; set; }
        public DateTime? WaterReplacementDate { get; set; }
        public float? Length { get; set; }
        public TempEntity? Temp { get; set; }
        public HumidityEntity? Humidity { get; set; }
        public EnclousureEntity? Enclousure { get; set; }
    }
}
