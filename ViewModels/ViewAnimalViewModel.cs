using ArduinoCOMLibrary;
using RackManager.Commands;
using RackManager.Enums;
using RackManager.Exceptions;
using RackManager.Models;
using RackManager.Services;
using RackManager.Stores;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace RackManager.ViewModels
{
    public partial class ViewAnimalViewModel : ViewModelBase, IArduinoConnection, IGetImage
    {
        private readonly ImageService _imageService;
        private readonly AnimalService _animalService;
        private readonly SnakeModel _currentSnake;
        private readonly NavigationStore _store;
        private ArduinoConnectorFactory _connectionFactory;
        public event Action<string> DataReceived;
        private ArduinoConnector _connector;

        public ViewAnimalViewModel(NavigationStore store, AnimalService animalService, SnakeModel currentSnake, ArduinoConnectorFactory connectorFactory)
        {
            _connectionFactory = connectorFactory;
            _currentSnake = currentSnake;
            _animalService = animalService;
            UpdateForm();
            CreateArduinoConnection(selectedPort);
            SexComboBox = new ObservableCollection<SexEnum>(Enum.GetValues(typeof(SexEnum)) as SexEnum[]);
            EnclosureOptions = new ObservableCollection<EnclosureModel>();
            EnclosureOptions.Add(new EnclosureModel()
            {
                Height = 50,
                Width = 50,
                Length = 100
            });
            CancelCommand = new NavigationCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService, connectorFactory));
            ModifyCommand = new CrudCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService, connectorFactory), ModifyAnimal);
            DeleteCommand = new CrudCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService, connectorFactory), DeleteAnimal);
            ConnectArduinoCommand = new GetPortCommand<ViewAnimalViewModel>(this);
            GetImageCommand = new GetImageCommand<ViewAnimalViewModel>(_imageService, this);
        }
        private string selectedPort;

        public string SelectedPort
        {
            get => selectedPort;
            set
            {
                selectedPort = value;
                OnPropertyChanged(nameof(SelectedPort));
            }
        }
        public void CreateArduinoConnection(string selectedPort)
        {
            if (selectedPort == null) { return; }
            _connector = _connectionFactory.CreateArduinoConnector(selectedPort);
            _connector.DataReceived += OnDataReceived;
            _connector.Open();
        }
        public void OnDataReceived(string data)
        {
            if (_connector == null) return;
            Debug.WriteLine($"Data received: {data}");
            Dictionary<string, float> arduinoValues = ParseArduinoData(data);
            arduinoValues.TryGetValue("Humidity", out float humidity);
            arduinoValues.TryGetValue("Temperature", out float temperature);
            CurrentHum = humidity.ToString();
            CurrentTemp = temperature.ToString();
            DataReceived?.Invoke(data);
        }

        public Dictionary<string, float> ParseArduinoData(string data)
        {
            Dictionary<string, float> values = new Dictionary<string, float>();

            try
            {
                string[]? readings = data.Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var reading in readings)
                {
                    string[]? keyValue = reading.Split(">>", StringSplitOptions.RemoveEmptyEntries);
                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0].Trim();
                        string value = keyValue[1].Trim();

                        if (float.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float numericValue))
                        {
                            values[key] = numericValue;
                        }
                        else
                        {
                            Debug.WriteLine($"Failed to parse {key}: {value}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error parsing Arduino values: {ex.Message}");
            }

            return values;
        }
        public void UpdateForm()
        {

            image = _currentSnake.Image;
            name = _currentSnake.Name;
            SelectedSex = _currentSnake.Sex;
            AnimalLength = _currentSnake.Length;
            weight = _currentSnake.Weight;
            birthDate = _currentSnake.DateOfBirth;
            feedingDate = _currentSnake.LastFeedingDate;
            waterReplacementDate = _currentSnake.WaterReplacementDate;
            subspecies = _currentSnake.Subspecies;
            venomous = _currentSnake.IsVenomous;
            AnimalMinTemp = _currentSnake.Temp.MinValue;
            AnimalMaxTemp = _currentSnake.Temp.MaxValue;
            AnimalMinHum = _currentSnake.Humidity.MinValue;
            AnimalMaxHum = _currentSnake.Humidity.MaxValue;
            selectedEnclosure = _currentSnake.Enclosure;
            selectedPort = _currentSnake.ArduinoIdentifier;
            AddInformation = _currentSnake.AddInformation;
        }
        private void DeleteAnimal()
        {
            _animalService.DeleteAnimal(_currentSnake);
        }
        private void ModifyAnimal()
        {
            tempModel = new TempModel()
            {
                MinValue = AnimalMinTemp,
                MaxValue = AnimalMaxTemp
            };

            humidityModel = new HumidityModel()
            {
                MinValue = AnimalMinHum,
                MaxValue = AnimalMaxHum
            };
            if (tempModel.Conflict() || humidityModel.Conflict())
            {
                throw new ValueConflictException();
            }
            SnakeModel animal = new SnakeModel()
            {
                Id = _currentSnake.Id,
                Image = this.Image,
                Name = AnimalName,
                DateOfBirth = AnimalBirthDate,
                Weight = AnimalWeight,
                Sex = SelectedSex,
                Subspecies = AnimalSubspecies,
                IsVenomous = AnimalVenomous,
                LastFeedingDate = AnimalFeedingDate,
                WaterReplacementDate = waterReplacementDate,
                Length = AnimalLength,
                Temp = tempModel,
                Humidity = humidityModel,
                Enclosure = selectedEnclosure,
                ArduinoIdentifier = selectedPort,
                AddInformation = AddInformation
            };
            if (_connector != null)
            {
                _connector.SendCommand(TempCommandParsed());
                _connector.Dispose();
            }
            _animalService.ModifyAnimal(animal);
        }
        private string TempCommandParsed()
        {
            return new string($"{AnimalMinTemp};{AnimalMaxTemp};");
        }
    }
}
