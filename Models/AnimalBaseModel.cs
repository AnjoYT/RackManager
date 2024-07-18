namespace RackManager.Models
{
    public class AnimalBaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public float Weight { get; set; }
        public enum Sex { get;set; }
    }
}
