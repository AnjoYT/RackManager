using RackManager.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Temperature")]
    public class TempDTO : IMinMaxValue<float>
    {
        public Guid Id { get; set; }
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public bool Conflict()
        {
            return true;
        }
        //public TempModel Convert()
        //{
        //    TempModel temp = new TempModel()
        //    {
        //        MinValue = this.MinValue,
        //        MaxValue = this.MaxValue

        //    };
        //}
    }
}