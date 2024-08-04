using RackManager.Models;
using RackManager.Utils;
using System.Collections.ObjectModel;

namespace RackManager.ViewModels
{
    public class AnimalsViewModel : ViewModelBase
    {
        public ObservableCollection<BaseCardModel> Animals { get; set; }
        public AnimalsViewModel()
        {
            Animals = new ObservableCollection<BaseCardModel>()
            {
                new SnakeModel()
                {
                    Name = "Dave",
                    Image =PathFinder.RelativePath(@"Assets\Images\","AddAnimal.png"),
                    Species = "Corn Snake",
                    IsVenomous = false
                },
                new SnakeModel()
                {
                    Name = "Dave",
                    Image ="E:\\REPOS\\PLIKI_TESTOWE\\testImage.png",
                    Species = "Corn Snake",
                    IsVenomous = false
                },
                new SnakeModel()
                {
                    Name = "George",
                    Image ="E:\\REPOS\\PLIKI_TESTOWE\\testImage.png",
                    Species = "Corn Snake",
                    IsVenomous = false
                }
            };
        }
    }
}
