namespace RackManager.Models
{
    interface MinMaxValue<T>
    {
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
        bool Conflict();

    }
}
