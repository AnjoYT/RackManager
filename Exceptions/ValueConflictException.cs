namespace RackManager.Exceptions
{
    class ValueConflictException : Exception
    {
        float minValue { get; set; }
        float maxValue { get; set; }

        public ValueConflictException(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
    }
}
