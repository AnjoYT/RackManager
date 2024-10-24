using RackManager.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Animals")]
    public class AnimalBaseEntity : ImageEntity
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public float? Weight { get; set; }
        public SexEnum? Sex { get; set; }
    }
}
