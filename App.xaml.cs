using ArduinoCOMLibrary;
using RackManager.Data;
using RackManager.Services;
using RackManager.Services.Modifiers;
using RackManager.Services.SnakeCreators;
using RackManager.Services.SnakeDeletes;
using RackManager.Services.SnakeProviders;
using RackManager.Stores;
using RackManager.ViewModels;
using System.Configuration;
using System.Windows;

namespace RackManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _store;
        private readonly AnimalService _animalService;
        private readonly IDbContextFactory _dbContextFactory;
        private readonly ISnakeProvider _snakeProvider;
        private readonly ISnakeCreator _snakeCreator;
        private readonly ISnakeDelete _snakeDelete;
        private readonly ISnakeModifier _snakeModifier;
        private readonly ArduinoConnectorFactory _connectorFactory;
        private readonly EnclosureService _enclosureService;

        public App()
        {
            _dbContextFactory = new DbContextFactory(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
            _snakeProvider = new SnakeProvider(_dbContextFactory);
            _snakeCreator = new SnakeCreator(_dbContextFactory);
            _snakeDelete = new SnakeDelete(_dbContextFactory);
            _snakeModifier = new SnakeModifier(_dbContextFactory);
            _store = new NavigationStore();
            _connectorFactory = new ArduinoConnectorFactory();
            _animalService = new AnimalService(_snakeCreator, _snakeProvider, _snakeDelete, _snakeModifier);
            _enclosureService = new EnclosureService();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _store.CurrentViewModel = new AnimalsViewModel(_store, _animalService, _connectorFactory);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_store, _animalService, _connectorFactory, _enclosureService)
            };
            MainWindow.Show();
        }
    }

}

