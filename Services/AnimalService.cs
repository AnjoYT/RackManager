using RackManager.Models;
using RackManager.Utils;
using System.Collections.ObjectModel;

namespace RackManager.Services
{
    public class AnimalService
    {
        public ObservableCollection<BaseCardModel> Cards { get; private set; }
        public AnimalService()
        {
            Cards = new ObservableCollection<BaseCardModel>() {
                 new BaseCardModel()
                {
                    Image = PathFinder.RelativePath(@"Assets\Images\", "AddAnimal.png"),
                    IsAddCard = true
                },

                new SnakeModel()
                {
                    Name = "Dave",
                    Image ="E:\\REPOS\\PLIKI_TESTOWE\\testImage.png",
                    Subspecies = "Corn Snake",
                },
                new SnakeModel()
                {
                    Name = "George",
                    Image ="E:\\REPOS\\PLIKI_TESTOWE\\testImage.png",
                    Subspecies = "Corn Snake",
                    IsVenomous = false
                },
                new SnakeModel()
                {
                    Name = "George",
                    Image ="E:\\REPOS\\PLIKI_TESTOWE\\testImage.png",
                    Subspecies = "Corn Snake",
                    IsVenomous = false
                }


            };
        }
        public void AddAnimal(MainAnimalModel animal)
        {
            Cards.Add(animal);
        }

    }
}
