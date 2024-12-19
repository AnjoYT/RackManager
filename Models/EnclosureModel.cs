namespace RackManager.Models
{
    public class EnclosureModel
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public float Length { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EnclosureModel))
                return false;

            var other = (EnclosureModel)obj;
            return this.Height == other.Height && this.Width == other.Width && this.Length == other.Length;
        }


        public override int GetHashCode()
        {
            return (Height, Width, Length).GetHashCode();
        }
    }
}
