using System.ComponentModel.DataAnnotations.Schema;

namespace RackManager.Entities
{
    [Table("Images")]
    public class ImageEntity
    {
        public string? Image { get; set; }
    }
}