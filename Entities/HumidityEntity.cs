using RackManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Humidity")]
    public class HumidityEntity : IMinMaxValue<int>
    {
        public int Id { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public bool Conflict()
        {
            return true;
        }
    }
}