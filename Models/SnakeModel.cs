using System.Collections.ObjectModel;

namespace RackManager.Models
{
    public class SnakeModel : AnimalBaseModel
    {
        public string species { get; set; }
        public ObservableCollection<string> Genes { get; set; }
        public bool IsVenomous { get; set; }
    }
}
