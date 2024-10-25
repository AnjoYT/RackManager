namespace RackManager.Entities
{
    public class SnakeEntity : AnimalBaseEntity
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
