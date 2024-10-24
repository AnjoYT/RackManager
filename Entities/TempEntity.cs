using RackManager.Models;

namespace RackManager.Entities
{
    public abstract class TempEntity : IMinMaxValue<float>
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public bool Conflict()
        {
            return true;
        }
    }
}