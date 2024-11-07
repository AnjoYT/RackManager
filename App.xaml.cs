using RackManager.Data;
using RackManager.Services;
using RackManager.Services.SnakeCreators;
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
        public App()
        {
            _dbContextFactory = new DbContextFactory(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString);
            _snakeProvider = new SnakeProvider(_dbContextFactory);
            _snakeCreator = new SnakeCreator(_dbContextFactory);
            _store = new NavigationStore();
            _animalService = new AnimalService(_snakeCreator, _snakeProvider);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _store.CurrentViewModel = new AnimalsViewModel(_store, _animalService);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_store)
            };
            MainWindow.Show();
        }
    }

}

