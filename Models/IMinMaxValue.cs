namespace RackManager.Models
{
    interface IMinMaxValue<T>
    {
        public T MinValue { get; set; }
        public T MaxValue { get; set; }
        bool Conflict();

    }
}
