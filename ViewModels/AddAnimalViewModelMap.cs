using RackManager.Enums;
using RackManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RackManager.ViewModels
{
    partial class AddAnimalViewModel : ViewModelBase
    {
        public ICommand CancelCommand { get; set; }

        public ICommand CreateCommand { get; set; }

        public ICommand GetImageCommand { get; set; }

        private IMinMaxValue<float?> tempModel;

        private IMinMaxValue<int?> humidityModel;
        public ObservableCollection<SexEnum> SexComboBox { get; set; }

        private SexEnum sex = SexEnum.Male;

        public SexEnum SelectedSex
        {
            get => sex;
            set
            {
                sex = value;
                OnPropertyChanged(nameof(SelectedSex));
            }
        }

        private string name;

        public string AnimalName
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(AnimalName));

            }
        }

        private float weight;

        public float AnimalWeight
        {
            get => weight;
            set
            {
                weight = value;
                OnPropertyChanged(nameof(AnimalWeight));
            }
        }

        private DateTime birthDate = DateTime.Today;

        public DateTime AnimalBirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(AnimalBirthDate));
            }
        }

        private DateTime feedingDate = DateTime.Today;

        public DateTime AnimalFeedingDate
        {
            get => feedingDate;
            set
            {
                feedingDate = value;
                OnPropertyChanged(nameof(AnimalFeedingDate));
            }
        }

        private DateTime waterReplacementDate = DateTime.Today;

        public DateTime AnimalWaterReplacementDate
        {
            get => waterReplacementDate;
            set
            {
                waterReplacementDate = value;
                OnPropertyChanged(nameof(AnimalWaterReplacementDate));
            }
        }

        private string subspecies;

        public string AnimalSubspecies
        {
            get => subspecies;
            set
            {
                subspecies = value;
                OnPropertyChanged(nameof(AnimalSubspecies));
            }
        }

        private bool venomous = false;

        public bool AnimalVenomous
        {
            get => venomous;
            set
            {
                venomous = value;
                OnPropertyChanged(nameof(AnimalVenomous));
            }
        }
        private string image = "E:\\REPOS\\PLIKI_TESTOWE\\testImage.png";
        public string Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public float AnimalMinTemp { get; set; } = 18f;
        public float AnimalMaxTemp { get; set; } = 32f;
        public int AnimalMinHum { get; set; } = 40;
        public int AnimalMaxHum { get; set; } = 60;
        public float AnimalLength { get; set; }
        public EnclousureModel? Enclousure { get; set; }
        public string AddInformation { get; set; }


    }
}
