using RackManager.Enums;
using RackManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RackManager.ViewModels
{
    public partial class ViewAnimalViewModel : ViewModelBase

    {
        public ICommand ModifyCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand GetImageCommand { get; set; }
        public ICommand ConnectArduinoCommand { get; set; }

        private TempModel tempModel;

        private HumidityModel humidityModel;
        public ObservableCollection<SexEnum> SexComboBox { get; set; }

        private SexEnum sex;

        public SexEnum SelectedSex
        {
            get => sex;
            set
            {
                sex = value;
                OnPropertyChanged(nameof(SelectedSex));
            }
        }
        private string currentTemp = "-";
        public string CurrentTemp
        {
            get => currentTemp; set
            {
                currentTemp = value;
                OnPropertyChanged(nameof(CurrentTemp));
            }
        }
        private string currentHum = "-";
        public string CurrentHum
        {
            get => currentHum; set
            {
                currentHum = value;
                OnPropertyChanged(nameof(CurrentHum));
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

        private DateTime? feedingDate = DateTime.Today;

        public DateTime? AnimalFeedingDate
        {
            get => feedingDate;
            set
            {
                feedingDate = value;
                OnPropertyChanged(nameof(AnimalFeedingDate));
            }
        }

        private DateTime? waterReplacementDate = DateTime.Today;

        public DateTime? AnimalWaterReplacementDate
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
        public float? AnimalLength { get; set; }
        public ObservableCollection<EnclosureModel> EnclosureOptions
        {
            get;
            set;
        }

        private EnclosureModel selectedEnclosure;
        public EnclosureModel SelectedEnclosure
        {
            get => selectedEnclosure;
            set
            {
                selectedEnclosure = value;
                OnPropertyChanged(nameof(SelectedEnclosure));
            }
        }
        public string AddInformation { get; set; }



    }
}
