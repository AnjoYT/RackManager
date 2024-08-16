using RackManager.Enums;
using RackManager.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RackManager.ViewModels
{
    partial class AddAnimalViewModel : ViewModelBase
    {
        private SnakeModel snakeModel;
        //private readonly EnclousureModel enclousure;
        public ObservableCollection<SexEnum> SexComboBox { get; set; }
        private SexEnum? sex;
        public SexEnum? SelectedSex
        {
            get => this.sex;
            set
            {
                this.sex = value;
                OnPropertyChanged(nameof(sex));
            }
        }
        public ICommand CancelCommand { get; set; }
        public ICommand CreateCommand { get; set; }
        private string name;
        public string AnimalName
        {
            get => this.name;
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(name));
            }
        }
        private float? weight;
        public float? AnimalWeight
        {
            get => this.weight;
            set
            {
                this.weight = value;
                OnPropertyChanged(nameof(weight));
            }
        }
        private DateTime? birthDate;
        public DateTime? AnimalBirthDate
        {
            get => this.birthDate;
            set
            {
                this.birthDate = value;
                OnPropertyChanged(nameof(birthDate));
            }
        }
        private DateTime? feedingDate;
        public DateTime? AnimalFeedingDate
        {
            get => this.feedingDate;
            set
            {
                this.feedingDate = value;
                OnPropertyChanged(nameof(feedingDate));
            }
        }
        private DateTime? waterReplacementDate;
        public DateTime? AnimalWaterReplacementDate
        {
            get => this.waterReplacementDate;
            set
            {
                this.waterReplacementDate = value;
                OnPropertyChanged(nameof(waterReplacementDate));
            }
        }
        private string subspecies;
        public string AnimalSubspecies
        {
            get => this.subspecies;
            set
            {
                this.subspecies = value;
                OnPropertyChanged(nameof(subspecies));
            }
        }
        private bool venomous;
        public bool AnimalVenomous
        {
            get => this.venomous;
            set
            {
                this.venomous = value;
                OnPropertyChanged(nameof(venomous));
            }
        }
        public int? AnimalMinTemp { get; set; }
        public int? AnimalMaxTemp { get; set; }
        public int? AnimalMinHum { get; set; }
        public int? AnimalMaxHum { get; set; }
        public float? AnimalLength { get; set; }
        public EnclousureModel? Enclousure { get; set; }
        public string? AddInformation { get; set; }


    }
}
