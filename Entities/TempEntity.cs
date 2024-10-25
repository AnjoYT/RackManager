using RackManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Temperature")]
    public class TempEntity : IMinMaxValue<float>
    {
        public int Id { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public bool Conflict()
        {
            return true;
        }
    }
}