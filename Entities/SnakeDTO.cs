namespace RackManager.Entities
{
    public class SnakeDTO : MainAnimalDTO
    {
        public string Subspecies { get; set; }
        public bool IsVenomous { get; set; }
        public DateTime? LastFeedingDate { get; set; }
        public DateTime? WaterReplacementDate { get; set; }
        public float? Length { get; set; }
        public TempDTO? Temp { get; set; }
        public HumidityDTO? Humidity { get; set; }
        public EnclousureDTO? Enclousure { get; set; }
    }
}
