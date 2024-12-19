namespace RackManager.Models
{
    public class SnakeModel : MainAnimalModel
    {
        public string Subspecies { get; set; }
        public bool IsVenomous { get; set; }
        public DateTime? LastFeedingDate { get; set; }
        public DateTime? WaterReplacementDate { get; set; }
        public float? Length { get; set; }
        public TempModel? Temp { get; set; }
        public HumidityModel? Humidity { get; set; }
        public EnclosureModel? Enclosure { get; set; }
        public string? ArduinoIdentifier { get; set; }
        public string AddInformation { get; set; }
    }
}
