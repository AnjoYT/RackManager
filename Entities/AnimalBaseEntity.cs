using RackManager.Enums;

namespace RackManager.Entities
{
    public class AnimalBaseEntity : ImageEntity
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public float? Weight { get; set; }
        public SexEnum? Sex { get; set; }
    }
}
