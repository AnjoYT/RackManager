namespace RackManager.Models
{
    public class TempModel : IMinMaxValue<float>
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public bool Conflict()
        {
            return MinValue > MaxValue;
        }
    }
}
