using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Enclousure")]
    public class EnclousureDTO
    {
        [Key]
        public Guid Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
    }
}