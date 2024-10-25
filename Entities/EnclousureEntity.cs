using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Enclousure")]
    public class EnclousureEntity
    {
        public int Id { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }
    }
}