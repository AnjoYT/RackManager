using System.Collections.ObjectModel;

namespace RackManager.Models
{
    public class SnakeModel : MainAnimalModel
    {
        public string Species { get; set; }
        public ObservableCollection<string>? Genes { get; set; }
        public bool IsVenomous { get; set; }
        public double? Humidity { get; set; }
        public double? Temperature { get; set; }
    }
}
