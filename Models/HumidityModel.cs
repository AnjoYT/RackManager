namespace RackManager.Models
{
    class HumidityModel : MinMaxValue<int>
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public HumidityModel(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public bool Conflict()
        {
            if (MinValue > MaxValue)
            {
                return true;
            }
            return false;
        }
    }
}
