using RackManager.Enums;

namespace RackManager.Models
{
    public class MainAnimalModel : BaseCardModel
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public float? Weight { get; set; }
        public SexEnum? Sex { get; set; }

    }
}
