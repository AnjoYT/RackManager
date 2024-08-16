namespace RackManager.Models
{
    public class SnakeModel : MainAnimalModel
    {
        public string Subspecies { get; set; }
        public bool IsVenomous { get; set; }
        public DateTime? LastFeedingDate { get; set; }
        public DateTime? WaterReplacementDate { get; set; }
        public float? Length { get; set; }
        //public EnclousureModel Enclousure { get; set; }
    }
}
