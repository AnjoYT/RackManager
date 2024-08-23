using RackManager.Exceptions;
using RackManager.Stores;
using RackManager.ViewModels;
using System.Windows;

namespace RackManager.Commands
{
    class CreateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly Func<TViewModel> viewModel;
        private readonly NavigationStore navigationStore;
        private readonly Action action;
        public CreateCommand(NavigationStore navigationStore, Func<TViewModel> viewModel, Action action)
        {
            this.action = action;
            this.viewModel = viewModel;
            this.navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                action?.Invoke();
                MessageBox.Show("Object created successfully", "Success", MessageBoxButton.OK);
            }
            catch (ValueConflictException)
            {
                MessageBox.Show("Cannot create object, incorrect values", "Error", MessageBoxButton.OK);
            }

            navigationStore.CurrentViewModel = this.viewModel();
        }
    }
}
