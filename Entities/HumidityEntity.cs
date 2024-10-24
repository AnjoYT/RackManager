using RackManager.Models;
namespace RackManager.Entities
{
    public class HumidityEntity : IMinMaxValue<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public bool Conflict()
        {
            return true;
        }
    }
}