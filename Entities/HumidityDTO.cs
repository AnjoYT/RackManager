using RackManager.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Humidity")]
    public class HumidityDTO : IMinMaxValue<int>
    {
        [Key]
        public Guid Id { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public bool Conflict()
        {
            return true;
        }
    }
}