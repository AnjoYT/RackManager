using RackManager.Services;
using RackManager.Stores;
using RackManager.ViewModels;
using System.Windows;

namespace RackManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore store;
        public static AnimalService animalService;
        public App()
        {
            store = new NavigationStore();
            animalService = new AnimalService();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            store.CurrentViewModel = new AnimalsViewModel(store, animalService);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(store)
            };
            MainWindow.Show();
        }
    }

}

