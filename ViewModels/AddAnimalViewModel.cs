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
    public partial class AddAnimalViewModel : ViewModelBase, IArduinoConnection, IGetImage
    {
        public readonly ImageService _imageService;
        private readonly NavigationStore _store;
        private readonly NavigationStore _navigationStore;
        private ArduinoConnectorFactory _connectionFactory;
        public event Action<string> DataReceived;
        private ArduinoConnector _connector;
        private AnimalService _animalService;
        public AddAnimalViewModel(NavigationStore store, AnimalService animalService, ArduinoConnectorFactory connectorFactory)
        {
            _connectionFactory = connectorFactory;

            _animalService = animalService;
            _imageService = new ImageService();
            EnclosureOptions = new ObservableCollection<EnclosureModel>();
            EnclosureOptions.Add(new EnclosureModel()
            {
                Height = 50,
                Width = 50,
                Length = 100
            });
            SexComboBox = new ObservableCollection<SexEnum>(Enum.GetValues(typeof(SexEnum)) as SexEnum[]);

            CancelCommand = new NavigationCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService, connectorFactory));

            CreateCommand = new CrudCommand<AnimalsViewModel>(store, () => new AnimalsViewModel(store, animalService, connectorFactory), AddAnimal);

            GetImageCommand = new GetImageCommand<AddAnimalViewModel>(_imageService, this);

            ConnectArduinoCommand = new GetPortCommand<AddAnimalViewModel>(this);
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
            SelectedPort = selectedPort;
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

        private void AddAnimal()
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
            if (selectedEnclosure is null)
            {
                throw new EnclosureNotSetException();
            }
            SnakeModel animal = new SnakeModel()
            {
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
            _animalService.AddAnimal(animal);
        }
        private string TempCommandParsed()
        {
            return new string($"{AnimalMinTemp};{AnimalMaxTemp};");
        }
    }
}
