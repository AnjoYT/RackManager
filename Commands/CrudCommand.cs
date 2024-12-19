using RackManager.Exceptions;
using RackManager.Stores;
using RackManager.ViewModels;
using System.Windows;

namespace RackManager.Commands
{
    public class CrudCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly Func<TViewModel> viewModel;
        private readonly NavigationStore navigationStore;
        private readonly Action action;
        public CrudCommand(NavigationStore navigationStore, Func<TViewModel> viewModel, Action action)
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
                MessageBox.Show("Operation completed successfully", "Success", MessageBoxButton.OK);
                navigationStore.CurrentViewModel = this.viewModel();
            }
            catch (ValueConflictException)
            {
                MessageBox.Show("Cannot complete operation, incorrect values", "Error", MessageBoxButton.OK);
            }
            catch (EnclosureNotSetException)
            {
                MessageBox.Show("Cannot complete operation, enclosure is not set");
            }

        }
    }
}
