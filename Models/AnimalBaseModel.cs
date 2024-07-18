using RackManager.Enums;

namespace RackManager.Models
{
    public class AnimalBaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public float Weight { get; set; }
        public SexEnum Sex { get;set; }
    }
}
