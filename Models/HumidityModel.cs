namespace RackManager.Models
{
    public class HumidityModel : IMinMaxValue<int?>
    {
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public HumidityModel(int? minValue, int? maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public bool Conflict()
        {
            return MinValue > MaxValue;
        }
    }
}
