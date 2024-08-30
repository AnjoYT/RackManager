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

        private SexEnum sex;

        public SexEnum SelectedSex
        {
            get => this.sex;
            set
            {
                this.sex = value;
                OnPropertyChanged(nameof(SelectedSex));
            }
        }

        private string name;

        public string AnimalName
        {
            get => this.name;
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(AnimalName));

            }
        }

        private float? weight;

        public float? AnimalWeight
        {
            get => this.weight;
            set
            {
                this.weight = value;
                OnPropertyChanged(nameof(AnimalWeight));
            }
        }

        private DateTime? birthDate;

        public DateTime? AnimalBirthDate
        {
            get => this.birthDate;
            set
            {
                this.birthDate = value;
                OnPropertyChanged(nameof(AnimalBirthDate));
            }
        }

        private DateTime? feedingDate;

        public DateTime? AnimalFeedingDate
        {
            get => this.feedingDate;
            set
            {
                this.feedingDate = value;
                OnPropertyChanged(nameof(AnimalFeedingDate));
            }
        }

        private DateTime? waterReplacementDate;

        public DateTime? AnimalWaterReplacementDate
        {
            get => this.waterReplacementDate;
            set
            {
                this.waterReplacementDate = value;
                OnPropertyChanged(nameof(AnimalWaterReplacementDate));
            }
        }

        private string subspecies;

        public string AnimalSubspecies
        {
            get => this.subspecies;
            set
            {
                this.subspecies = value;
                OnPropertyChanged(nameof(AnimalSubspecies));
            }
        }

        private bool venomous;

        public bool AnimalVenomous
        {
            get => this.venomous;
            set
            {
                this.venomous = value;
                OnPropertyChanged(nameof(AnimalVenomous));
            }
        }
        private string image = "E:\\REPOS\\PLIKI_TESTOWE\\testImage.png";
        public string Image
        {
            get => this.image;
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public float? AnimalMinTemp { get; set; }
        public float? AnimalMaxTemp { get; set; }
        public int? AnimalMinHum { get; set; }
        public int? AnimalMaxHum { get; set; }
        public float? AnimalLength { get; set; }
        public EnclousureModel? Enclousure { get; set; }
        public string? AddInformation { get; set; }


    }
}
